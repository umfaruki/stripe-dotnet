namespace Stripe
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class ApplicationFeeRefundService : Service<ApplicationFeeRefund>,
        INestedCreatable<ApplicationFeeRefund, ApplicationFeeRefundCreateOptions>,
        INestedListable<ApplicationFeeRefund, ApplicationFeeRefundListOptions>,
        INestedRetrievable<ApplicationFeeRefund>,
        INestedUpdatable<ApplicationFeeRefund, ApplicationFeeRefundUpdateOptions>
    {
        public ApplicationFeeRefundService()
            : base(null)
        {
        }

        public ApplicationFeeRefundService(string apiKey)
            : base(apiKey)
        {
        }

        public bool ExpandBalanceTransaction { get; set; }

        public bool ExpandFee { get; set; }

        public virtual ApplicationFeeRefund Create(string applicationFeeId, ApplicationFeeRefundCreateOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Post($"{Urls.BaseUrl}/application_fees/{applicationFeeId}/refunds", requestOptions, options);
        }

        public virtual Task<ApplicationFeeRefund> CreateAsync(string applicationFeeId, ApplicationFeeRefundCreateOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.PostAsync($"{Urls.BaseUrl}/application_fees/{applicationFeeId}/refunds", requestOptions, cancellationToken, options);
        }

        public virtual ApplicationFeeRefund Get(string applicationFeeId, string refundId, RequestOptions requestOptions = null)
        {
            return this.GetEntity($"{Urls.BaseUrl}/application_fees/{applicationFeeId}/refunds/{refundId}", requestOptions);
        }

        public virtual Task<ApplicationFeeRefund> GetAsync(string applicationFeeId, string refundId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsync($"{Urls.BaseUrl}/application_fees/{applicationFeeId}/refunds/{refundId}", requestOptions, cancellationToken);
        }

        public virtual StripeList<ApplicationFeeRefund> List(string applicationFeeId, ApplicationFeeRefundListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntityList($"{Urls.BaseUrl}/application_fees/{applicationFeeId}/refunds", requestOptions, options);
        }

        public virtual Task<StripeList<ApplicationFeeRefund>> ListAsync(string applicationFeeId, ApplicationFeeRefundListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityListAsync($"{Urls.BaseUrl}/application_fees/{applicationFeeId}/refunds", requestOptions, cancellationToken, options);
        }

        public virtual ApplicationFeeRefund Update(string applicationFeeId, string refundId, ApplicationFeeRefundUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.Post($"{Urls.BaseUrl}/application_fees/{applicationFeeId}/refunds/{refundId}", requestOptions, options);
        }

        public virtual Task<ApplicationFeeRefund> UpdateAsync(string applicationFeeId, string refundId, ApplicationFeeRefundUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.PostAsync($"{Urls.BaseUrl}/application_fees/{applicationFeeId}/refunds/{refundId}", requestOptions, cancellationToken, options);
        }
    }
}
