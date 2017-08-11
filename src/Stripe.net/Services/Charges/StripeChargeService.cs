using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeChargeService : StripeBasicService<StripeCharge>
    {

        public StripeChargeService(string apiKey = null) : base(apiKey) { }

        public bool ExpandApplicationFee { get; set; }
        public bool ExpandBalanceTransaction { get; set; }
        public bool ExpandCustomer { get; set; }
        public bool ExpandDestination { get; set; }
        public bool ExpandInvoice { get; set; }
        public bool ExpandReview { get; set; }
        public bool ExpandTransfer { get; set; }
        public bool ExpandOnBehalfOf { get; set; }
        public bool ExpandSourceTransfer { get; set; }
        public bool ExpandDispute { get; set; }
        public bool ExpandOutcome { get; set; }

        //Sync
        public StripeCharge Create(StripeChargeCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(createOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeCharge Update(string chargeId, StripeChargeUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {

            return UpdateAsync(chargeId, updateOptions, requestOptions, CancellationToken.None).Result;

        }

        public StripeCharge Get(string chargeId, StripeRequestOptions requestOptions = null)
        {

            return GetAsync(chargeId, requestOptions, CancellationToken.None).Result;

        }

        public StripeList<StripeCharge> List(StripeChargeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {

            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;

        }

        public StripeCharge Capture(string chargeId, int? captureAmount = null, int? applicationFee = null, StripeRequestOptions requestOptions = null)
        {

            return CaptureAsync(chargeId, captureAmount, applicationFee, requestOptions, CancellationToken.None).Result;

        }



        //Async
        public Task<StripeCharge> CreateAsync(StripeChargeCreateOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {

            return PostEntityAsync($"{Urls.Charges}", requestOptions, cancellationToken, createOptions);

        }

        public Task<StripeCharge> UpdateAsync(string chargeId, StripeChargeUpdateOptions updateOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {

            return PostEntityAsync($"{Urls.Charges}/{chargeId}", requestOptions, cancellationToken, updateOptions);

        }

        public Task<StripeCharge> GetAsync(string chargeId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {

            return GetEntityAsync($"{Urls.Charges}/{chargeId}", requestOptions, cancellationToken, null);

        }

        public Task<StripeList<StripeCharge>> ListAsync(StripeChargeListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {

            return GetEntityListAsync($"{Urls.Charges}", requestOptions, cancellationToken, listOptions);

        }

        public Task<StripeCharge> CaptureAsync(string chargeId, int? captureAmount = null, int? applicationFee = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {

            var url = this.ApplyAllParameters(null, $"{Urls.Charges}/{chargeId}/capture");

            if (captureAmount.HasValue)
                url = ParameterBuilder.ApplyParameterToUrl(url, "amount", captureAmount.Value.ToString());
            if (applicationFee.HasValue)
                url = ParameterBuilder.ApplyParameterToUrl(url, "application_fee", applicationFee.Value.ToString());

            return PostEntityAsync(url, requestOptions, cancellationToken, null);

        }
    }
}
