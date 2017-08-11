using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeLoginLinkService : StripeBasicService<StripeLoginLink>
    {
        public StripeLoginLinkService(string apiKey = null) : base(apiKey) { }

        //Sync
        public StripeLoginLink Create(string accountId, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(accountId, requestOptions, CancellationToken.None).Result;
        }

        // Async
        public Task<StripeLoginLink> CreateAsync(string accountId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/accounts/{accountId}/login_links", requestOptions, cancellationToken, null);
        }
    }
}
