using System;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    [Obsolete("Use the StripeSourceService instead.")]
    public class Stripe3DSecureService : StripeBasicService<Stripe3DSecure>
    {
        public Stripe3DSecureService(string apiKey = null) : base(apiKey) { }

        // Sync
        public Stripe3DSecure Create(Stripe3DSecureCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(createOptions, requestOptions, CancellationToken.None).Result;
        }

        // Async
        public Task<Stripe3DSecure> CreateAsync(Stripe3DSecureCreateOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/3d_secure", requestOptions, cancellationToken, createOptions);
        }
    }
}
