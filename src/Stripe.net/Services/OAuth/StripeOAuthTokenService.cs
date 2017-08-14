using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeOAuthTokenService : StripeBasicService<StripeOAuthToken>
    {
        public StripeOAuthTokenService(string apiKey = null) : base(apiKey) { }

        //Sync
        public StripeOAuthToken Create(StripeOAuthTokenCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(createOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeOAuthDeauthorize Deauthorize(string clientId, string stripeUserId, StripeRequestOptions requestOptions = null)
        {
            return DeauthorizeAsync(clientId, stripeUserId, requestOptions, CancellationToken.None).Result;
        }

        //Async
        public Task<StripeOAuthToken> CreateAsync(StripeOAuthTokenCreateOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.OAuthToken}", requestOptions, cancellationToken, createOptions);
        }

        public async Task<StripeOAuthDeauthorize> DeauthorizeAsync(string clientId, string stripeUserId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // TODO: This has a different return type, but could be thrown into the generic parent class I think.
            var url = ParameterBuilder.ApplyParameterToUrl(Urls.OAuthDeauthorize, "client_id", clientId);
            url = ParameterBuilder.ApplyParameterToUrl(url, "stripe_user_id", stripeUserId);

            return Mapper<StripeOAuthDeauthorize>.MapFromJson(
                await Requestor.PostStringAsync(url, SetupRequestOptions(requestOptions),
                cancellationToken)
            );
        }
    }
}
