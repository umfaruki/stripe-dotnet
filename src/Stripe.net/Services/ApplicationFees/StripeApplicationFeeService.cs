using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeApplicationFeeService : StripeBasicService<StripeApplicationFee>
    {
        public StripeApplicationFeeService(string apiKey = null) : base(apiKey) { }

        public bool ExpandAccount { get; set; }
        public bool ExpandApplication { get; set; }
        public bool ExpandBalanceTransaction { get; set; }
        public bool ExpandCharge { get; set; }

        //Sync
        public StripeApplicationFee Get(string applicationFeeId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(applicationFeeId, requestOptions, CancellationToken.None).Result;
        }

        public StripeApplicationFee Refund(string applicationFeeId, int? refundAmount = null, StripeRequestOptions requestOptions = null)
        {
            return RefundAsync(applicationFeeId, refundAmount, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeApplicationFee> List(StripeApplicationFeeListOptions listOptions, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;
        }

        //Async
        public Task<StripeApplicationFee> GetAsync(string applicationFeeId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.ApplicationFees}/{applicationFeeId}", requestOptions, cancellationToken);
        }

        public Task<StripeApplicationFee> RefundAsync(string applicationFeeId, int? refundAmount = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = this.ApplyAllParameters(null, $"{Urls.ApplicationFees}/{applicationFeeId}/refund");
            if (refundAmount.HasValue)
                url = ParameterBuilder.ApplyParameterToUrl(url, "amount", refundAmount.Value.ToString());

            return PostEntityAsync(url, requestOptions, cancellationToken);
        }

        public Task<StripeList<StripeApplicationFee>> ListAsync(StripeApplicationFeeListOptions listOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.ApplicationFees}", requestOptions, cancellationToken, listOptions);
        }
    }
}
