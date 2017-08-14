using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeTokenService : StripeBasicService<StripeToken>
    {

        public StripeTokenService(string apiKey = null) : base(apiKey) { }

        //Sync
        public StripeToken Create(StripeTokenCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(createOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeToken Get(string tokenId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(tokenId, requestOptions, CancellationToken.None).Result;
        }

        //Async
        public Task<StripeToken> CreateAsync(StripeTokenCreateOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.Tokens}", requestOptions, cancellationToken, createOptions);
        }

        public Task<StripeToken> GetAsync(string tokenId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.Tokens}/{tokenId}", requestOptions, cancellationToken);
        }
    }
}
