namespace Stripe
{
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class TopupService : Service<Topup>,
        ICreatable<Topup, TopupCreateOptions>,
        IListable<Topup, TopupListOptions>,
        IRetrievable<Topup>,
        IUpdatable<Topup, TopupUpdateOptions>
    {
        public TopupService()
            : base(null)
        {
        }

        public TopupService(string apiKey = null)
            : base(apiKey)
        {
        }

        public override string BasePath => "/topups";

        public bool ExpandBalanceTransaction { get; set; }

        public bool ExpandSource { get; set; }

        public virtual Topup Cancel(string topupId, RequestOptions requestOptions = null)
        {
            return this.PostRequest<Topup>($"{this.InstanceUrl(topupId)}/cancel", null, requestOptions);
        }

        public virtual Task<Topup> CancelAsync(string topupId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.PostRequestAsync<Topup>($"{this.InstanceUrl(topupId)}/cancel", null, requestOptions, cancellationToken);
        }

        public virtual Topup Create(TopupCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        public virtual Task<Topup> CreateAsync(TopupCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }

        public virtual Topup Get(string topupId, RequestOptions requestOptions = null)
        {
            return this.GetEntity(topupId, null, requestOptions);
        }

        public virtual Task<Topup> GetAsync(string topupId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsync(topupId, null, requestOptions, cancellationToken);
        }

        public virtual StripeList<Topup> List(TopupListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<StripeList<Topup>> ListAsync(TopupListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        public virtual Topup Update(string topupId, TopupUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(topupId, options, requestOptions);
        }

        public virtual Task<Topup> UpdateAsync(string topupId, TopupUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.UpdateEntityAsync(topupId, options, requestOptions, cancellationToken);
        }
    }
}
