using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    // the StripeEntityWithId is used here because it can return a card or bank account. this might change when the service is finished - source perhaps?
    public class StripeExternalAccountService : StripeBasicService<StripeEntityWithId>
    {
        public StripeExternalAccountService(string apiKey = null) : base(apiKey) { }

        // Sync
        public StripeDeleted Delete(string accountId, string externalAccountId, StripeRequestOptions requestOptions = null)
        {
            return DeleteAsync(accountId, externalAccountId, requestOptions, CancellationToken.None).Result;
        }

        // Async
        public Task<StripeDeleted> DeleteAsync(string accountId, string externalAccountId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteEntityAsync($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts/{externalAccountId}", requestOptions, cancellationToken);
        }
    }
}
