using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeDiscountService : StripeBasicService<StripeDiscount>
    {
        public StripeDiscountService(string apiKey = null) : base(apiKey) { }

        // Sync
        public StripeDeleted DeleteCustomerDiscount(string customerId, StripeRequestOptions requestOptions = null)
        {
            return DeleteCustomerDiscountAsync(customerId, requestOptions, CancellationToken.None).Result;
        }

        public StripeDeleted DeleteSubscriptionDiscount(string subscriptionId, StripeRequestOptions requestOptions = null)
        {
            return DeleteSubscriptionDiscountAsync(subscriptionId, requestOptions, CancellationToken.None).Result;
        }

        // Async
        public Task<StripeDeleted> DeleteCustomerDiscountAsync(string customerId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteEntityAsync($"{Urls.BaseUrl}/customers/{customerId}/discount", requestOptions, cancellationToken);
        }

        public Task<StripeDeleted> DeleteSubscriptionDiscountAsync(string subscriptionId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteEntityAsync($"{Urls.BaseUrl}/subscriptions/{subscriptionId}/discount", requestOptions, cancellationToken);
        }
    }
}
