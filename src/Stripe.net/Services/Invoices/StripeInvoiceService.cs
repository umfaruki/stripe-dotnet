using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeInvoiceService : StripeBasicService<StripeInvoice>
    {
        public StripeInvoiceService(string apiKey = null) : base(apiKey) { }

        public bool ExpandCharge { get; set; }
        public bool ExpandCustomer { get; set; }

        //Sync
        public StripeInvoice Get(string invoiceId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(invoiceId, requestOptions, CancellationToken.None).Result;
        }

        public StripeInvoice Upcoming(string customerId, StripeUpcomingInvoiceOptions upcomingOptions = null, StripeRequestOptions requestOptions = null)
        {
            return UpcomingAsync(customerId, upcomingOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeInvoice Update(string invoiceId, StripeInvoiceUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(invoiceId, updateOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeInvoice Pay(string invoiceId, StripeRequestOptions requestOptions = null)
        {
            return PayAsync(invoiceId, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeInvoice> List(StripeInvoiceListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeInvoiceLineItem> ListLineItems(string invoiceId, StripeInvoiceListLineItemsOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListLineItemsAsync(invoiceId, listOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeInvoiceLineItem> ListUpcomingLineItems(string customerId, StripeUpcomingInvoiceOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListUpcomingLineItemsAsync(customerId, listOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeInvoice Create(string customerId, StripeInvoiceCreateOptions createOptions = null, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(customerId, createOptions, requestOptions, CancellationToken.None).Result;
        }



        //Async
        public Task<StripeInvoice> GetAsync(string invoiceId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.Invoices}/{invoiceId}", requestOptions, cancellationToken);
        }

        public Task<StripeInvoice> UpcomingAsync(string customerId, StripeUpcomingInvoiceOptions upcomingOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = ParameterBuilder.ApplyParameterToUrl($"{Urls.Invoices}/upcoming", "customer", customerId);
            return GetEntityAsync(url, requestOptions, cancellationToken, upcomingOptions);
        }

        public Task<StripeInvoice> UpdateAsync(string invoiceId, StripeInvoiceUpdateOptions updateOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.Invoices}/{invoiceId}", requestOptions, cancellationToken, updateOptions);
        }

        public Task<StripeInvoice> PayAsync(string invoiceId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.Invoices}/{invoiceId}/pay", requestOptions, cancellationToken);
        }

        public Task<StripeList<StripeInvoice>> ListAsync(StripeInvoiceListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.Invoices}", requestOptions, cancellationToken, listOptions);
        }

        public async Task<StripeList<StripeInvoiceLineItem>> ListLineItemsAsync(string invoiceId, StripeInvoiceListLineItemsOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // TODO: This should be merged into the generic parent class, but has a different return type.
            return Mapper<StripeList<StripeInvoiceLineItem>>.MapFromJson(
                await Requestor.GetStringAsync(
                    this.ApplyAllParameters(listOptions, $"{Urls.Invoices}/{invoiceId}/lines", true),
                    SetupRequestOptions(requestOptions),
                    cancellationToken)
            );
        }

        public async Task<StripeList<StripeInvoiceLineItem>> ListUpcomingLineItemsAsync(string customerId, StripeUpcomingInvoiceOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // TODO: This should be merged into the generic parent class, but has a different return type.
            var url = ParameterBuilder.ApplyParameterToUrl($"{Urls.Invoices}/upcoming/lines", "customer", customerId);
            return Mapper<StripeList<StripeInvoiceLineItem>>.MapFromJson(
                await Requestor.GetStringAsync(this.ApplyAllParameters(listOptions, url, true),
                SetupRequestOptions(requestOptions),
                cancellationToken)
            );
        }

        public Task<StripeInvoice> CreateAsync(string customerId, StripeInvoiceCreateOptions createOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = ParameterBuilder.ApplyParameterToUrl(Urls.Invoices, "customer", customerId);
            return PostEntityAsync(url, requestOptions, cancellationToken, createOptions);
        }
    }
}
