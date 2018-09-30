namespace Stripe
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public partial class SubscriptionService : Service<Subscription>,
        ICreatable<Subscription, SubscriptionCreateOptions>,
        IListable<Subscription, SubscriptionListOptions>,
        IRetrievable<Subscription>,
        IUpdatable<Subscription, SubscriptionUpdateOptions>
    {
        public SubscriptionService()
            : base(null)
        {
        }

        public SubscriptionService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/subscriptions";

        public bool ExpandCustomer { get; set; }

        public virtual Subscription Cancel(string subscriptionId, SubscriptionCancelOptions options, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(subscriptionId, options, requestOptions);
        }

        public virtual Task<Subscription> CancelAsync(string subscriptionId, SubscriptionCancelOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.DeleteEntityAsync(subscriptionId, options, requestOptions, cancellationToken);
        }

        public virtual Subscription Create(SubscriptionCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        public virtual Task<Subscription> CreateAsync(SubscriptionCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }

        public virtual Subscription Get(string subscriptionId, RequestOptions requestOptions = null)
        {
            return this.GetEntity(subscriptionId, null, requestOptions);
        }

        public virtual Task<Subscription> GetAsync(string subscriptionId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsync(subscriptionId, null, requestOptions, cancellationToken);
        }

        public virtual StripeList<Subscription> List(SubscriptionListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<StripeList<Subscription>> ListAsync(SubscriptionListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        public virtual Subscription Update(string subscriptionId, SubscriptionUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(subscriptionId, options, requestOptions);
        }

        public virtual Task<Subscription> UpdateAsync(string subscriptionId, SubscriptionUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.UpdateEntityAsync(subscriptionId, options, requestOptions, cancellationToken);
        }
    }
}
