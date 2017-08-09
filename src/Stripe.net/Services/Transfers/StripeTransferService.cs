using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeTransferService : StripeBasicService<StripeTransfer>
    {
        public StripeTransferService(string apiKey = null) : base(apiKey) { }

        public bool ExpandBalanceTransaction { get; set; }

        //Sync
        public StripeTransfer Create(StripeTransferCreateOptions options, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(options, requestOptions, CancellationToken.None).Result;
        }

        public StripeTransfer Get(string payoutId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(payoutId, requestOptions, CancellationToken.None).Result;
        }

        public StripeTransfer Update(string transferId, StripeTransferUpdateOptions options, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(transferId, options, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeTransfer> List(StripeTransferListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;
        }

        // Async
        public Task<StripeTransfer> CreateAsync(StripeTransferCreateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/transfers", requestOptions, cancellationToken, options);
        }

        public Task<StripeTransfer> GetAsync(string payoutId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.BaseUrl}/transfers/{payoutId}", requestOptions, cancellationToken, null);
        }

        public Task<StripeTransfer> UpdateAsync(string transferId, StripeTransferUpdateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/transfers/{transferId}", requestOptions, cancellationToken, options);
        }

        public Task<StripeList<StripeTransfer>> ListAsync(StripeTransferListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.BaseUrl}/transfers", requestOptions, cancellationToken, listOptions);
        }
    }
}
