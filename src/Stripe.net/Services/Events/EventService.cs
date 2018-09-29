namespace Stripe
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class EventService : Service<Event>,
        IListable<Event, EventListOptions>,
        IRetrievable<Event>
    {
        public EventService()
            : base(null)
        {
        }

        public EventService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/events";

        public virtual Event Get(string eventId, RequestOptions requestOptions = null)
        {
            return this.GetEntityNew(eventId, requestOptions);
        }

        public virtual Task<Event> GetAsync(string eventId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsyncNew(eventId, requestOptions, cancellationToken);
        }

        public virtual StripeList<Event> List(EventListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntityList($"{Urls.BaseUrl}/events", requestOptions, options);
        }

        public virtual Task<StripeList<Event>> ListAsync(EventListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityListAsync($"{Urls.BaseUrl}/events", requestOptions, cancellationToken, options);
        }
    }
}
