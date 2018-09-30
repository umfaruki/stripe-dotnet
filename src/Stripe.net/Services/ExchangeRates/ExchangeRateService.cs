namespace Stripe
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class ExchangeRateService : Service<ExchangeRate>,
        IListable<ExchangeRate, ExchangeRateListOptions>,
        IRetrievable<ExchangeRate>
    {
        public ExchangeRateService()
            : base(null)
        {
        }

        public ExchangeRateService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/exchange_rates";

        public virtual ExchangeRate Get(string currency, RequestOptions requestOptions = null)
        {
            return this.GetEntity(currency, null, requestOptions);
        }

        public virtual Task<ExchangeRate> GetAsync(string currency, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsync(currency, null, requestOptions, cancellationToken);
        }

        public virtual StripeList<ExchangeRate> List(ExchangeRateListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<StripeList<ExchangeRate>> ListAsync(ExchangeRateListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }
    }
}
