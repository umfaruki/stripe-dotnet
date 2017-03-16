using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeOrderService : StripeBasicService<StripeOrder>
    {
        public StripeOrderService(string apiKey = null) : base(apiKey) { }



        // Sync
        public virtual StripeOrder Create(StripeOrderCreateOptions options, StripeRequestOptions requestOptions = null)
        {
            return Post($"{Urls.BaseUrl}/orders", requestOptions, options);
        }

        //public virtual StripeOrder Create(StripeOrderCreateOptions createOptions = null, StripeRequestOptions requestOptions = null)
        //{
        //    return Post($"{Urls.BaseUrl}/orders", requestOptions, createOptions);
        //}

        //public virtual StripeOrder Update(string orderId, StripeOrderUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        //{
        //    return Post($"{Urls.BaseUrl}/orders{orderId}", requestOptions, updateOptions);
        //}

        //public virtual StripeOrder Pay(string orderId, StripeOrderPayOptions payOptions, StripeRequestOptions requestOptions = null)
        //{
        //    return Post($"{Urls.BaseUrl}/orders{orderId}/pay", requestOptions, payOptions);
        //}

        //public virtual StripeReturn Return(string orderId, StripeOrderReturnOptions returnOptions, StripeRequestOptions requestOptions = null)
        //{
        //    return Mapper<StripeReturn>.MapFromJson(
        //        Requestor.PostString(this.ApplyAllParameters(returnOptions, $"{Urls.BaseUrl}/orders{orderId}/returns", false),
        //        SetupRequestOptions(requestOptions))
        //    );
        //}

        //public virtual IEnumerable<StripeOrder> List(StripeOrderListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        //{
        //    return GetEntityList(Urls.Orders, requestOptions, listOptions);
        //}



        // Async
        public virtual Task<StripeOrder> CreateAsync(StripeOrderCreateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostAsync($"{Urls.BaseUrl}/orders", requestOptions, cancellationToken, options);
        }
    }
}