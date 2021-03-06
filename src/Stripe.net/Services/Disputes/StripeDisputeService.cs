namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class StripeDisputeService : StripeBasicService<StripeDispute>
    {
        public StripeDisputeService()
            : base(null)
        {
        }

        public StripeDisputeService(string apiKey)
            : base(apiKey)
        {
        }

        public bool ExpandCharge { get; set; }

        public virtual StripeDispute Get(string disputeId, StripeRequestOptions requestOptions = null)
        {
            return this.GetEntity($"{Urls.Disputes}/{disputeId}", requestOptions);
        }

        public virtual StripeDispute Update(string disputeId, StripeDisputeUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return this.Post($"{Urls.Disputes}/{disputeId}", requestOptions, updateOptions);
        }

        public virtual StripeDispute Close(string disputeId, StripeRequestOptions requestOptions = null)
        {
            return this.Post($"{Urls.Disputes}/{disputeId}/close", requestOptions);
        }

        public virtual StripeList<StripeDispute> List(StripeDisputeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return this.GetEntityList(Urls.Disputes, requestOptions, listOptions);
        }

        public virtual Task<StripeDispute> GetAsync(string disputeId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsync($"{Urls.Disputes}/{disputeId}", requestOptions, cancellationToken);
        }

        public virtual Task<StripeDispute> UpdateAsync(string disputeId, StripeDisputeUpdateOptions updateOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.PostAsync($"{Urls.Disputes}/{disputeId}", requestOptions, cancellationToken, updateOptions);
        }

        public virtual Task<StripeDispute> CloseAsync(string disputeId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.PostAsync($"{Urls.Disputes}/{disputeId}/close", requestOptions, cancellationToken);
        }

        public virtual Task<StripeList<StripeDispute>> ListAsync(StripeDisputeListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityListAsync(Urls.Disputes, requestOptions, cancellationToken, listOptions);
        }
    }
}
