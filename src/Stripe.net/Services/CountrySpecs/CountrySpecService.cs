using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class CountrySpecService : StripeBasicService<CountrySpec>
    {
        public CountrySpecService(string apiKey = null) : base(apiKey) { }

        //Sync
        public CountrySpec Get(string country, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(country, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<CountrySpec> List(StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;
        }

        //Async
        public Task<CountrySpec> GetAsync(string country, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.CountrySpecs}/{country}", requestOptions, cancellationToken);
        }

        public Task<StripeList<CountrySpec>> ListAsync(StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.CountrySpecs}", requestOptions, cancellationToken, listOptions);
        }
    }
}
