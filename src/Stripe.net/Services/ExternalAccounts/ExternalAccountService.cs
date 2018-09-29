namespace Stripe
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class ExternalAccountService : Service<ExternalAccount>,
        INestedCreatable<ExternalAccount, ExternalAccountCreateOptions>,
        INestedDeletable<ExternalAccount>,
        INestedListable<ExternalAccount, ExternalAccountListOptions>,
        INestedRetrievable<ExternalAccount>,
        INestedUpdatable<ExternalAccount, ExternalAccountUpdateOptions>
    {
        public ExternalAccountService()
            : base(null)
        {
        }

        public ExternalAccountService(string apiKey)
            : base(apiKey)
        {
        }

        public virtual ExternalAccount Create(string accountId, ExternalAccountCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.Post($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts", requestOptions, options);
        }

        public virtual Task<ExternalAccount> CreateAsync(string accountId, ExternalAccountCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.PostAsync($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts", requestOptions, cancellationToken, options);
        }

        public virtual ExternalAccount Delete(string accountId, string externalAccountId, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts/{externalAccountId}", requestOptions);
        }

        public virtual Task<ExternalAccount> DeleteAsync(string accountId, string externalAccountId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.DeleteEntityAsync($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts/{externalAccountId}", requestOptions, cancellationToken);
        }

        public virtual ExternalAccount Get(string accountId, string externalAccountId, RequestOptions requestOptions = null)
        {
            return this.GetEntity($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts/{externalAccountId}", requestOptions);
        }

        public virtual StripeList<ExternalAccount> List(string accountId, ExternalAccountListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntityList($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts", requestOptions, options);
        }

        public virtual Task<StripeList<ExternalAccount>> ListAsync(string accountId, ExternalAccountListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityListAsync($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts", requestOptions, cancellationToken, options);
        }

        public virtual ExternalAccount Update(string accountId, string externalAccountId, ExternalAccountUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.Post($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts/{externalAccountId}", requestOptions, options);
        }

        public virtual Task<ExternalAccount> UpdateAsync(string accountId, string externalAccountId, ExternalAccountUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.PostAsync($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts/{externalAccountId}", requestOptions, cancellationToken, options);
        }

        public virtual Task<ExternalAccount> GetAsync(string accountId, string externalAccountId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsync($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts/{externalAccountId}", requestOptions, cancellationToken);
        }
    }
}
