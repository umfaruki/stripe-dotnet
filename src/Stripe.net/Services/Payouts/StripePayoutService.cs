using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripePayoutService : StripeBasicService<StripePayout>
    {
        public StripePayoutService(string apiKey = null) : base(apiKey) { }

        public bool ExpandBalanceTransaction { get; set; }
        public bool ExpandFailureBalanceTransaction { get; set; }
        public bool ExpandDestination { get; set; }

        // Sync
        public StripePayout Create(StripePayoutCreateOptions options, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(options, requestOptions, CancellationToken.None).Result;
        }

        public StripePayout Get(string payoutId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(payoutId, requestOptions, CancellationToken.None).Result;
        }

        public StripePayout Update(string payoutId, StripePayoutUpdateOptions options, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(payoutId, options, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripePayout> List(StripePayoutListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripePayout Cancel(string payoutId, StripeRequestOptions requestOptions = null)
        {
            return CancelAsync(payoutId, requestOptions, CancellationToken.None).Result;
        }

        // Async
        public Task<StripePayout> CreateAsync(StripePayoutCreateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/payouts", requestOptions, cancellationToken, options);
        }

        public Task<StripePayout> GetAsync(string payoutId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.BaseUrl}/payouts/{payoutId}", requestOptions, cancellationToken);
        }

        public Task<StripePayout> UpdateAsync(string payoutId, StripePayoutUpdateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/payouts/{payoutId}", requestOptions, cancellationToken, options);
        }

        public Task<StripeList<StripePayout>> ListAsync(StripePayoutListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.BaseUrl}/payouts", requestOptions, cancellationToken, listOptions);
        }

        public Task<StripePayout> CancelAsync(string payoutId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/payouts/{payoutId}/cancel", requestOptions, cancellationToken);
        }
    }
}
