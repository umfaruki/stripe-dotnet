function Invoke-Build
{
	Write-Host "Starting Build Script..."

	#$build = (msbuild "src\Stripe.sln" /verbosity:minimal /logger:"C:\Program Files\AppVeyor\BuildAgent\Appveyor.MSBuildLogger.dll" | Out-String) -split "\n"
	msbuild "src\Stripe.sln" /verbosity:minimal /logger:"C:\Program Files\AppVeyor\BuildAgent\Appveyor.MSBuildLogger.dll"
	#Write-Host $build
	#$missing_comments = 0
	#$build | ForEach-Object { if ($_ -contains "warning CS1591") { $global:missing_comments++ } }
	#Write-Host "$($missing_comments) items are missing XML comments"

	#$deprecated_types = 0
	#$build | ForEach-Object { if ($_ -contains "warning CS0618") { $global:deprecated_types++ } }
	#Write-Host "$($deprecated_types) items are deprecated"

	Write-Host "Finished Build Script"
}

function Invoke-NuGetCheck
{
	$headers = @{
	  "Authorization" = "Bearer $env:token"
	  "Content-type" = "application/json"
	}
 
	$url = "https://ci.appveyor.com/api/projects/$env:APPVEYOR_ACCOUNT_NAME/$env:APPVEYOR_PROJECT_SLUG/history?recordsNumber=2"
 
	$history = Invoke-RestMethod -Uri $url -Headers $headers  -Method Get
 
	if ($history.builds.Length -lt 2) {throw "history is not long enough"}
 
	write-host "previous version:"
	$history.builds[1].version
	write-host "current version:"
	$env:APPVEYOR_BUILD_VERSION
 
	$previousVersionSplit = $history.builds[1].version.Split(".")
	if ($previousVersionSplit.Length -lt 3) {throw "previous build version has no enough parts"}
 
	$currentVersionSplit = $env:APPVEYOR_BUILD_VERSION.Split(".")
	if ($currentVersionSplit.Length -lt 3) {throw "current build version has no enough parts"}
 
	$pushNuget = $false
	for ($i = 0; $i -lt 3; $i++) {if ($previousVersionSplit[$i] -ne $currentVersionSplit[$i]) {write-host "at least one part changed, will push nuget"; $pushNuget = $true; break}}
 
	if(!$pushNuget) {
	write-host "all parts are the same, will not push Nuget"
	# do "nuget pack" here
	# do "appveyor PushArtifact <your-nugetpackage.nupkg>" accordig to https://www.appveyor.com/docs/nuget/
	}
}
