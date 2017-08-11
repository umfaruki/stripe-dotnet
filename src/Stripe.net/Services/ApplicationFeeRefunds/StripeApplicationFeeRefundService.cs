using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeApplicationFeeRefundService : StripeBasicService<StripeApplicationFeeRefund>
    {
        public StripeApplicationFeeRefundService(string apiKey = null) : base(apiKey) { }

        // Sync
        public virtual StripeApplicationFeeRefund Create(string applicationFeeId, StripeApplicationFeeRefundCreateOptions createOptions = null, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(applicationFeeId, createOptions, requestOptions, CancellationToken.None).Result;
        }

        public virtual StripeApplicationFeeRefund Get(string applicationFeeId, string refundId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(applicationFeeId, refundId, requestOptions, CancellationToken.None).Result;
        }

        public virtual StripeApplicationFeeRefund Update(string applicationFeeId, string refundId, StripeApplicationFeeRefundUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(applicationFeeId, refundId, updateOptions, requestOptions, CancellationToken.None).Result;
        }

        public virtual StripeList<StripeApplicationFeeRefund> List(string applicationFeeId, StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(applicationFeeId, listOptions, requestOptions, CancellationToken.None).Result;
        }

        // Async
        public virtual Task<StripeApplicationFeeRefund> CreateAsync(string applicationFeeId, StripeApplicationFeeRefundCreateOptions createOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/application_fees/{applicationFeeId}/refunds", requestOptions, cancellationToken, createOptions);
        }

        public virtual Task<StripeApplicationFeeRefund> GetAsync(string applicationFeeId, string refundId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.BaseUrl}/application_fees/{applicationFeeId}/refunds/{refundId}", requestOptions, cancellationToken);
        }

        public virtual Task<StripeApplicationFeeRefund> UpdateAsync(string applicationFeeId, string refundId, StripeApplicationFeeRefundUpdateOptions updateOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/application_fees/{applicationFeeId}/refunds/{refundId}", requestOptions, cancellationToken, updateOptions);
        }

        public virtual Task<StripeList<StripeApplicationFeeRefund>> ListAsync(string applicationFeeId, StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.BaseUrl}/application_fees/{applicationFeeId}/refunds", requestOptions, cancellationToken, listOptions);
        }
    }
}
