using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeEventService : StripeService
    {
        public StripeEventService(string apiKey = null) : base(apiKey) { }

        //Sync
        public StripeEvent Get(string eventId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(eventId, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeEvent> List(StripeEventListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;
        }

        //Async
        public Task<StripeEvent> GetAsync(string eventId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.Events}/{eventId}", requestOptions, cancellationToken);
        }

        public Task<StripeList<StripeEvent>> ListAsync(StripeEventListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.Events}", requestOptions, cancellationToken, listOptions);
        }
    }
}
