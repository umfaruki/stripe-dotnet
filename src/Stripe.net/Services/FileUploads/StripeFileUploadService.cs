using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeFileUploadService : StripeBasicService<StripeFileUpload>
    {
        public StripeFileUploadService(string apiKey = null) : base(apiKey) { }

        //Sync
        public StripeFileUpload Create(string fileName, Stream fileStream, string purpose, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(fileName, fileStream, purpose, requestOptions, CancellationToken.None).Result;
        }

        public StripeFileUpload Get(string fileUploadId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(fileUploadId, requestOptions, CancellationToken.None).Result
        }

        public StripeList<StripeFileUpload> List(StripeFileUploadListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result
        }



        //Async
        public async Task<StripeFileUpload> CreateAsync(string fileName, Stream fileStream, string purpose, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // TODO: This should probably be baked in or moved to the parent class; it shouldn't live in the requestor.
            return Mapper<StripeFileUpload>.MapFromJson(
                await Requestor.PostFileAsync(Urls.FileUploads, fileName, fileStream, purpose, SetupRequestOptions(requestOptions), cancellationToken)
            );
        }

        public Task<StripeFileUpload> GetAsync(string fileUploadId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.FileUploads}/{fileUploadId}", requestOptions, cancellationToken);
        }

        public Task<StripeList<StripeFileUpload>> ListAsync(StripeFileUploadListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.FileUploads}", requestOptions, cancellationToken, listOptions);
        }
    }
}
