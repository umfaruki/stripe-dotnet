using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeSourceService : StripeBasicService<StripeSource>
    {
        public StripeSourceService(string apiKey = null) : base(apiKey) { }

        // Sync
        public StripeSource Create(StripeSourceCreateOptions options, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(options, requestOptions, CancellationToken.None).Result;
        }

        public StripeSource Get(string sourceId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(sourceId, requestOptions, CancellationToken.None).Result;
        }

        public StripeSource Update(string sourceId, StripeSourceUpdateOptions options, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(sourceId, options, requestOptions, CancellationToken.None).Result;
        }

        // Async
        public Task<StripeSource> CreateAsync(StripeSourceCreateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/sources", requestOptions, cancellationToken, options);
        }

        public Task<StripeSource> GetAsync(string sourceId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.BaseUrl}/sources/{sourceId}", requestOptions, cancellationToken);
        }

        public Task<StripeSource> UpdateAsync(string sourceId, StripeSourceUpdateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/sources/{sourceId}", requestOptions, cancellationToken, options);
        }

    }
}
