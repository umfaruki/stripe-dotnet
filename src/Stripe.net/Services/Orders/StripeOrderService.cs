using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeOrderService : StripeBasicService<StripeOrder>
    {
        public StripeOrderService(string apiKey = null) : base(apiKey) { }

        // Sync
        public StripeOrder Create(StripeOrderCreateOptions options, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(options, requestOptions, CancellationToken.None).Result;
        }

        public StripeOrder Get(string orderId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(orderId, requestOptions, CancellationToken.None).Result;
        }

        public StripeOrder Update(string orderId, StripeOrderUpdateOptions options, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(orderId, options, requestOptions, CancellationToken.None).Result;
        }

        public StripeOrder Pay(string orderId, StripeOrderPayOptions options, StripeRequestOptions requestOptions = null)
        {
            return PayAsync(orderId, options, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeOrder> List(StripeOrderListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;
        }

        // Async
        public Task<StripeOrder> CreateAsync(StripeOrderCreateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/orders", requestOptions, cancellationToken, options);
        }

        public Task<StripeOrder> GetAsync(string orderId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.BaseUrl}/orders/{orderId}", requestOptions, cancellationToken);
        }

        public Task<StripeOrder> UpdateAsync(string orderId, StripeOrderUpdateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/orders/{orderId}", requestOptions, cancellationToken, options);
        }

        public Task<StripeOrder> PayAsync(string orderId, StripeOrderPayOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/orders/{orderId}/pay", requestOptions, cancellationToken, options);
        }

        public Task<StripeList<StripeOrder>> ListAsync(StripeOrderListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.BaseUrl}/orders", requestOptions, cancellationToken, listOptions);
        }
    }
}
