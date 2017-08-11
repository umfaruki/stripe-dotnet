using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeProductService : StripeBasicService<StripeProduct>
    {

        public StripeProductService(string apiKey = null) : base(apiKey) { }

        // Sync
        public StripeProduct Create(StripeProductCreateOptions options, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(options, requestOptions, CancellationToken.None).Result;
        }

        public StripeProduct Get(string productId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(productId, requestOptions, CancellationToken.None).Result;
        }

        public StripeProduct Update(string productId, StripeProductUpdateOptions options, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(productId, options, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeProduct> List(StripeProductListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeDeleted Delete(string productId, StripeRequestOptions requestOptions = null)
        {
            return DeleteAsync(productId, requestOptions, CancellationToken.None).Result;
        }

        // Async
        public Task<StripeProduct> CreateAsync(StripeProductCreateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/products", requestOptions, cancellationToken, options);
        }

        public Task<StripeProduct> GetAsync(string productId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.BaseUrl}/products/{productId}", requestOptions, cancellationToken);
        }

        public Task<StripeProduct> UpdateAsync(string productId, StripeProductUpdateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/products/{productId}", requestOptions, cancellationToken, options);
        }

        public Task<StripeList<StripeProduct>> ListAsync(StripeProductListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.BaseUrl}/products", requestOptions, cancellationToken, listOptions);
        }

        public Task<StripeDeleted> DeleteAsync(string productId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteEntityAsync($"{Urls.BaseUrl}/products/{productId}", requestOptions, cancellationToken);
        }
    }
}
