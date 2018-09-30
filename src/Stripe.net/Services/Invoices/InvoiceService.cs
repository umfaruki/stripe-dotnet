namespace Stripe
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class InvoiceService : Service<Invoice>,
        ICreatable<Invoice, InvoiceCreateOptions>,
        IListable<Invoice, InvoiceListOptions>,
        IRetrievable<Invoice>,
        IUpdatable<Invoice, InvoiceUpdateOptions>
    {
        public InvoiceService()
            : base(null)
        {
        }

        public InvoiceService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/invoices";

        public bool ExpandCharge { get; set; }

        public bool ExpandCustomer { get; set; }

        public bool ExpandSubscription { get; set; }

        public virtual Invoice Create(InvoiceCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        public virtual Task<Invoice> CreateAsync(InvoiceCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }

        public virtual Invoice Get(string invoiceId, RequestOptions requestOptions = null)
        {
            return this.GetEntity(invoiceId, null, requestOptions);
        }

        public virtual Task<Invoice> GetAsync(string invoiceId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsync(invoiceId, null, requestOptions, cancellationToken);
        }

        public virtual StripeList<Invoice> List(InvoiceListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        public virtual Task<StripeList<Invoice>> ListAsync(InvoiceListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        public virtual StripeList<InvoiceLineItem> ListLineItems(string invoiceId, InvoiceListLineItemsOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetRequest<StripeList<InvoiceLineItem>>($"{this.InstanceUrl(invoiceId)}/lines", options, requestOptions);
        }

        public virtual Task<StripeList<InvoiceLineItem>> ListLineItemsAsync(string invoiceId, InvoiceListLineItemsOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetRequestAsync<StripeList<InvoiceLineItem>>($"{this.InstanceUrl(invoiceId)}/lines", options, requestOptions, cancellationToken);
        }

        public virtual StripeList<InvoiceLineItem> ListUpcomingLineItems(UpcomingInvoiceOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetRequest<StripeList<InvoiceLineItem>>($"{this.InstanceUrl("upcoming")}/lines", options, requestOptions);
        }

        public virtual Task<StripeList<InvoiceLineItem>> ListUpcomingLineItemsAsync(UpcomingInvoiceOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetRequestAsync<StripeList<InvoiceLineItem>>($"{this.InstanceUrl("upcoming")}/lines", options, requestOptions, cancellationToken);
        }

        public virtual Invoice Pay(string invoiceId, InvoicePayOptions options, RequestOptions requestOptions = null)
        {
            return this.PostRequest<Invoice>($"{this.InstanceUrl(invoiceId)}/pay", options, requestOptions);
        }

        public virtual Task<Invoice> PayAsync(string invoiceId, InvoicePayOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.PostRequestAsync<Invoice>($"{this.InstanceUrl(invoiceId)}/pay", options, requestOptions, cancellationToken);
        }

        public virtual Invoice Upcoming(UpcomingInvoiceOptions options, RequestOptions requestOptions = null)
        {
            return this.GetRequest<Invoice>($"{this.InstanceUrl("upcoming")}", options, requestOptions);
        }

        public virtual Task<Invoice> UpcomingAsync(UpcomingInvoiceOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetRequestAsync<Invoice>($"{this.InstanceUrl("upcoming")}", options, requestOptions, cancellationToken);
        }

        public virtual Invoice Update(string invoiceId, InvoiceUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.UpdateEntity(invoiceId, options, requestOptions);
        }

        public virtual Task<Invoice> UpdateAsync(string invoiceId, InvoiceUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.UpdateEntityAsync(invoiceId, options, requestOptions, cancellationToken);
        }
    }
}
