using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeCouponService : StripeService
    {
        public StripeCouponService(string apiKey = null) : base(apiKey) { }

        //Sync
        public StripeCoupon Create(StripeCouponCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(createOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeCoupon Update(string couponId, StripeCouponUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(couponId, updateOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeCoupon Get(string couponId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(couponId, requestOptions, CancellationToken.None).Result;
        }

        public StripeDeleted Delete(string couponId, StripeRequestOptions requestOptions = null)
        {
            return DeleteAsync(couponId, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeCoupon> List(StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;
        }

        //Async
        public Task<StripeCoupon> CreateAsync(StripeCouponCreateOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.Coupons}", requestOptions, cancellationToken, createOptions);
        }

        public Task<StripeCoupon> UpdateAsync(string couponId, StripeCouponUpdateOptions updateOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.Coupons}/{couponId}", requestOptions, cancellationToken, updateOptions);
        }

        public Task<StripeCoupon> GetAsync(string couponId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.Coupons}/{couponId}", requestOptions, cancellationToken);
        }

        public Task<StripeDeleted> DeleteAsync(string couponId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteEntityAsync($"{Urls.Coupons}/{couponId}", requestOptions, cancellationToken);
        }

        public Task<StripeList<StripeCoupon>> ListAsync(StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.Coupons}", requestOptions, cancellationToken, listOptions);
        }
    }
}
