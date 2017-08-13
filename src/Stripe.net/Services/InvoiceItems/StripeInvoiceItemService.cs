using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeInvoiceItemService : StripeBasicService<StripeInvoiceLineItem>
    {

        public StripeInvoiceItemService(string apiKey = null) : base(apiKey) { }

        public bool ExpandCustomer { get; set; }
        public bool ExpandInvoice { get; set; }

        //Sync
        public StripeInvoiceLineItem Create(StripeInvoiceItemCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(createOptions, requestOptions, CancellationToken.None).Result
        }

        public StripeInvoiceLineItem Get(string invoiceItemId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(invoiceItemId, requestOptions, CancellationToken.None).Result
        }

        public StripeInvoiceLineItem Update(string invoiceItemId, StripeInvoiceItemUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(invoiceItemId, updateOptions, requestOptions, CancellationToken.None).Result
        }

        public StripeDeleted Delete(string invoiceItemId, StripeRequestOptions requestOptions = null)
        {
            return DeleteAsync(invoiceItemId, requestOptions, CancellationToken.None).Result
        }

        public StripeList<StripeInvoiceLineItem> List(StripeInvoiceItemListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result
        }

        //Async
        public Task<StripeInvoiceLineItem> CreateAsync(StripeInvoiceItemCreateOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.InvoiceItems}", requestOptions, cancellationToken, createOptions);
        }

        public Task<StripeInvoiceLineItem> GetAsync(string invoiceItemId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.InvoiceItems}/{invoiceItemId}", requestOptions, cancellationToken);
        }

        public Task<StripeInvoiceLineItem> UpdateAsync(string invoiceItemId, StripeInvoiceItemUpdateOptions updateOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.InvoiceItems}/{invoiceItemId}", requestOptions, cancellationToken, updateOptions);
        }

        public Task<StripeDeleted> DeleteAsync(string invoiceItemId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteEntityAsync($"{Urls.InvoiceItems}/{invoiceItemId}", requestOptions, cancellationToken);
        }

        public Task<StripeList<StripeInvoiceLineItem>> ListAsync(StripeInvoiceItemListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.InvoiceItems}", requestOptions, cancellationToken, listOptions);
        }
    }
}
