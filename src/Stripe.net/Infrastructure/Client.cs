using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json;

namespace Stripe.Infrastructure
{
    internal class Client
    {
        private HttpRequestMessage RequestMessage { get; set; }

        public Client(HttpRequestMessage requestMessage)
        {
            RequestMessage = requestMessage;
        }

        public void ApplyUserAgent()
        {
            RequestMessage.Headers.UserAgent.ParseAdd($"Stripe/v1 .NetBindings/{StripeConfiguration.StripeNetVersion}");
        }

        public void ApplyClientData()
        {
            RequestMessage.Headers.Add("X-Stripe-Client-User-Agent", GetClientUserAgentString());
        }

        private string GetClientUserAgentString()
        {
            var langVersion = "4.5";

#if NET45
            langVersion = typeof(object).GetTypeInfo().Assembly.ImageRuntimeVersion;
#endif

            var mono = testForMono();
            if (!string.IsNullOrEmpty(mono)) langVersion = mono;

            var values = new Dictionary<string, string>
            {
                { "bindings_version", StripeConfiguration.StripeNetVersion },
                { "lang", ".net" },
                { "publisher", "Jayme Davis" },
                { "lang_version", WebUtility.HtmlEncode(langVersion) },
                { "uname", WebUtility.HtmlEncode(getSystemInformation()) }
            };

            return JsonConvert.SerializeObject(values);
        }

        private string testForMono()
        {
            var type = Type.GetType("Mono.Runtime");
            var getDisplayName = type?.GetTypeInfo().GetDeclaredMethod("GetDisplayName");

            return getDisplayName?.Invoke(null, null).ToString();
        }

        private string getSystemInformation()
        {
            var result = string.Empty;

#if NET45
            result += $"net45.platform: { Environment.OSVersion.Platform }";
            result += $", net45.service_pack: { Environment.OSVersion.ServicePack }";
            result += $", net45.version: { Environment.OSVersion.Version }";
            result += $", net45.version_string: { Environment.OSVersion.VersionString }";
#else
            result += "portable.platform: ";

            try
            {
                result += typeof(object).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyProductAttribute>().Product;
            }
            catch
            {
                result += "unknown";
            }
#endif

            return result;
        }
    }
}