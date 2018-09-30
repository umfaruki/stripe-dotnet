namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class DisputeService : Service<Dispute>,
        IListable<Dispute, DisputeListOptions>,
        IRetrievable<Dispute>,
        IUpdatable<Dispute, DisputeUpdateOptions>
    {
        public DisputeService()
            : base(null)
        {
        }

        public DisputeService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/disputes";

        public bool ExpandCharge { get; set; }

        public virtual Dispute Close(string disputeId, RequestOptions requestOptions = null)
        {
            return this.PostRequest<Dispute>($"{this.InstanceUrl(disputeId)}/close", null, requestOptions);
        }

        public virtual Task<Dispute> CloseAsync(string disputeId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.PostRequestAsync<Dispute>($"{this.InstanceUrl(disputeId)}/close", null, requestOptions, cancellationToken);
        }

        public virtual Dispute Get(string disputeId, RequestOptions requestOptions = null)
        {
            return this.GetEntity(disputeId, null, requestOptions);
        }

        public virtual Task<Dispute> GetAsync(string disputeId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsync(disputeId, null, requestOptions, cancellationToken);
        }

        public virtual StripeList<Dispute> List(DisputeListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<StripeList<Dispute>> ListAsync(DisputeListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        public virtual Dispute Update(string disputeId, DisputeUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(disputeId, options, requestOptions);
        }

        public virtual Task<Dispute> UpdateAsync(string disputeId, DisputeUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.UpdateEntityAsync(disputeId, options, requestOptions, cancellationToken);
        }
    }
}
