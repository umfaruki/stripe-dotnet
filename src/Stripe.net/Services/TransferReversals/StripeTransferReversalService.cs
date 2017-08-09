using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeTransferReversalService : StripeBasicService<StripeTransferReversal>
    {
        public StripeTransferReversalService(string apiKey = null) : base(apiKey) { }

        public bool ExpandBalanceTransaction { get; set; }
        public bool ExpandTransfer { get; set; }

        //Sync
        public StripeTransferReversal Create(string transferId, StripeTransferReversalCreateOptions options = null, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(transferId, options, requestOptions, CancellationToken.None).Result;
        }

        public StripeTransferReversal Get(string transferId, string reversalId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(transferId, reversalId, requestOptions, CancellationToken.None).Result;
        }

        public StripeTransferReversal Update(string transferId, string reversalId, StripeTransferReversalUpdateOptions options, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(transferId, reversalId, options, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeTransferReversal> List(string transferId, StripeListOptions options = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(transferId, options, requestOptions, CancellationToken.None).Result;
        }

        // Async
        public Task<StripeTransferReversal> CreateAsync(string transferId, StripeTransferReversalCreateOptions options = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/transfers/{transferId}/reversals", requestOptions, cancellationToken, options);
        }

        public Task<StripeTransferReversal> GetAsync(string transferId, string reversalId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.BaseUrl}/transfers/{transferId}/reversals/{reversalId}", requestOptions, cancellationToken, null);
        }

        public Task<StripeTransferReversal> UpdateAsync(string transferId,  string reversalId, StripeTransferReversalUpdateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/transfers/{transferId}/reversals/{reversalId}", requestOptions, cancellationToken, options);
        }

        public Task<StripeList<StripeTransferReversal>> ListAsync(string transferId, StripeListOptions options = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.BaseUrl}/transfers/{transferId}/reversals", requestOptions, cancellationToken, options);
        }
    }
}
