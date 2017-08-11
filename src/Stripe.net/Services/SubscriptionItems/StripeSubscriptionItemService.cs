using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeSubscriptionItemService : StripeBasicService<StripeSubscriptionItem>
    {
        public StripeSubscriptionItemService(string apiKey = null) : base(apiKey) { }

        // Sync
        public StripeSubscriptionItem Create(StripeSubscriptionItemCreateOptions options, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(options, requestOptions, CancellationToken.None).Result;
        }

        public StripeSubscriptionItem Get(string subscriptionItemId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(subscriptionItemId, requestOptions, CancellationToken.None).Result;
        }

        public StripeSubscriptionItem Update(string subscriptionItemId, StripeSubscriptionItemUpdateOptions options, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(subscriptionItemId, options, requestOptions, CancellationToken.None).Result;
        }

        public StripeDeleted Delete(string subscriptionItemId, StripeRequestOptions requestOptions = null)
        {
            return DeleteAsync(subscriptionItemId, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeSubscriptionItem> List(StripeSubscriptionItemListOptions options = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(options, requestOptions, CancellationToken.None).Result;
        }

        // Async
        public Task<StripeSubscriptionItem> CreateAsync(StripeSubscriptionItemCreateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/subscription_items", requestOptions, cancellationToken, options);
        }

        public Task<StripeSubscriptionItem> GetAsync(string subscriptionItemId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.BaseUrl}/subscription_items/{subscriptionItemId}", requestOptions, cancellationToken, null);
        }

        public Task<StripeSubscriptionItem> UpdateAsync(string subscriptionItemId, StripeSubscriptionItemUpdateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/subscription_items/{subscriptionItemId}", requestOptions, cancellationToken, options);
        }

        public Task<StripeDeleted> DeleteAsync(string subscriptionItemId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteEntityAsync($"{Urls.BaseUrl}/subscription_items/{subscriptionItemId}", requestOptions, cancellationToken);
        }

        public Task<StripeList<StripeSubscriptionItem>> ListAsync(StripeSubscriptionItemListOptions options = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.BaseUrl}/subscription_items", requestOptions, cancellationToken, options);
        }
    }
}
