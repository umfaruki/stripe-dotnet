namespace Stripe
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class ApplePayDomainService : Service<ApplePayDomain>,
        ICreatable<ApplePayDomain, ApplePayDomainCreateOptions>,
        IDeletable<ApplePayDomain>,
        IListable<ApplePayDomain, ApplePayDomainListOptions>,
        IRetrievable<ApplePayDomain>
    {
        public ApplePayDomainService()
            : base(null)
        {
        }

        public ApplePayDomainService(string apiKey)
            : base(apiKey)
        {
        }

        public override string ObjectName => "apple_pay_domain";

        public virtual ApplePayDomain Create(ApplePayDomainCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        public virtual Task<ApplePayDomain> CreateAsync(ApplePayDomainCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }

        public virtual ApplePayDomain Delete(string domainId, RequestOptions requestOptions = null)
        {
            return this.DeleteEntityNew(domainId, null, requestOptions);
        }

        public virtual Task<ApplePayDomain> DeleteAsync(string domainId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.DeleteEntityAsyncNew(domainId, null, requestOptions, cancellationToken);
        }

        public virtual ApplePayDomain Get(string domainId, RequestOptions requestOptions = null)
        {
            return this.GetEntityNew(domainId, null, requestOptions);
        }

        public virtual Task<ApplePayDomain> GetAsync(string domainId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsyncNew(domainId, null, requestOptions, cancellationToken);
        }

        public virtual StripeList<ApplePayDomain> List(ApplePayDomainListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<StripeList<ApplePayDomain>> ListAsync(ApplePayDomainListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        protected override string ClassUrl(string baseUrl = null)
        {
            baseUrl = baseUrl ?? StripeConfiguration.GetApiBase();

            return $"{baseUrl}/apple_pay/domains";
        }
    }
}
