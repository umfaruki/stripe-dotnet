using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeRefundService : StripeBasicService<StripeRefund>
    {
        public StripeRefundService(string apiKey = null) : base(apiKey) { }

        public bool ExpandBalanceTransaction { get; set; }
        public bool ExpandCharge { get; set; }

        //Sync
        public StripeRefund Create(string chargeId, StripeRefundCreateOptions createOptions = null, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(chargeId, createOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeRefund Get(string refundId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(refundId, requestOptions, CancellationToken.None).Result;
        }

        public StripeRefund Update(string refundId, StripeRefundUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(refundId, updateOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeRefund> List(StripeRefundListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;
        }

        //Async
        public Task<StripeRefund> CreateAsync(string chargeId, StripeRefundCreateOptions createOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.Charges}/{chargeId}/refunds", requestOptions, cancellationToken, createOptions);
        }

        public Task<StripeRefund> GetAsync(string refundId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.BaseUrl}/refunds/{refundId}", requestOptions, cancellationToken);
        }

        public Task<StripeRefund> UpdateAsync(string refundId, StripeRefundUpdateOptions updateOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/refunds/{refundId}", requestOptions, cancellationToken, updateOptions);
        }

        public Task<StripeList<StripeRefund>> ListAsync(StripeRefundListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.BaseUrl}/refunds", requestOptions, cancellationToken, listOptions);
        }
    }
}
