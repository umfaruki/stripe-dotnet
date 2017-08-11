using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeDisputeService : StripeBasicService<StripeDispute>
    {
        public StripeDisputeService(string apiKey = null) : base(apiKey) { }

        public bool ExpandCharge { get; set; }

        // Sync
        public StripeDispute Get(string disputeId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(disputeId, requestOptions, CancellationToken.None).Result;
        }

        public StripeDispute Update(string disputeId, StripeDisputeUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(disputeId, updateOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeDispute Close(string disputeId, StripeRequestOptions requestOptions = null)
        {
            return CloseAsync(disputeId, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeDispute> List(StripeDisputeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;
        }

        // Async
        public Task<StripeDispute> GetAsync(string disputeId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.Disputes}/{disputeId}", requestOptions, cancellationToken);
        }

        public Task<StripeDispute> UpdateAsync(string disputeId, StripeDisputeUpdateOptions updateOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.Disputes}/{disputeId}", requestOptions, cancellationToken, updateOptions);
        }

        public Task<StripeDispute> CloseAsync(string disputeId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.Disputes}/{disputeId}/close", requestOptions, cancellationToken);
        }

        public Task<StripeList<StripeDispute>> ListAsync(StripeDisputeListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync(Urls.Disputes, requestOptions, cancellationToken, listOptions);
        }
    }
}
