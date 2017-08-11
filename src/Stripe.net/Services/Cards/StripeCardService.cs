using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeCardService : StripeBasicService<StripeCard>
    {
        public StripeCardService(string apiKey = null) : base(apiKey) { }

        public bool ExpandCustomer { get; set; }
        public bool ExpandRecipient { get; set; }

        // TODO: Not sure if we even need this recipient stuff.

        //Sync
        public StripeCard Create(string customerId, StripeCardCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(customerId=customerId, createOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeCard Create(string recipientId, StripeCreditCardOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(recipientId=recipientId, createOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeCard Get(string customerOrRecipientId, string cardId, bool isRecipient = false, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(customerOrRecipientId, cardId, isRecipient, requestOptions, CancellationToken.None).Result;
        }

        public StripeCard Update(string customerOrRecipientId, string cardId, StripeCardUpdateOptions updateOptions, bool isRecipient = false, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(customerOrRecipientId, cardId, updateOptions, isRecipient, requestOptions, CancellationToken.None).Result;
        }

        public StripeDeleted Delete(string customerOrRecipientId, string cardId, bool isRecipient = false, StripeRequestOptions requestOptions = null)
        {
            return DeleteAsync(customerOrRecipientId, cardId, isRecipient, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeCard> List(string customerOrRecipientId, StripeListOptions listOptions = null, bool isRecipient = false, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(customerOrRecipientId, listOptions, isRecipient, requestOptions, CancellationToken.None).Result;
        }

        //Async
        public Task<StripeCard> CreateAsync(string customerId, StripeCardCreateOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = BuildRecipientOrCustomerUrl(customerId, false);
            return PostEntityAsync(url, requestOptions, cancellationToken, createOptions);
        }

        public Task<StripeCard> CreateAsync(string recipientId, StripeCreditCardOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = BuildRecipientOrCustomerUrl(recipientId, true);
            return PostEntityAsync(url, requestOptions, cancellationToken, createOptions);
        }

        public Task<StripeCard> GetAsync(string customerOrRecipientId, string cardId, bool isRecipient = false, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = BuildRecipientOrCustomerUrl(customerOrRecipientId, isRecipient, cardId);
            return GetEntityAsync(url, requestOptions, cancellationToken);
        }

        public Task<StripeCard> UpdateAsync(string customerOrRecipientId, string cardId, StripeCardUpdateOptions updateOptions, bool isRecipient = false, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = BuildRecipientOrCustomerUrl(customerOrRecipientId, isRecipient, cardId);
            return PostEntityAsync(url, requestOptions, cancellationToken, updateOptions);
        }

        public Task<StripeDeleted> DeleteAsync(string customerOrRecipientId, string cardId, bool isRecipient = false, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = BuildRecipientOrCustomerUrl(customerOrRecipientId, isRecipient, cardId);
            return DeleteEntityAsync(url, requestOptions, cancellationToken);
        }

        public Task<StripeList<StripeCard>> ListAsync(string customerOrRecipientId, StripeListOptions listOptions = null, bool isRecipient = false, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = BuildRecipientOrCustomerUrl(customerOrRecipientId, isRecipient);
            return GetEntityListAsync(url, requestOptions, cancellationToken, listOptions);
        }

        // Helper Methods
        private string BuildRecipientOrCustomerUrl(string customerOrRecipientId, bool isRecipient, string cardId = null)
        {
            var urlParams = string.Format(Urls.CustomerSources, customerOrRecipientId);

            if (isRecipient)
                urlParams = string.Format(Urls.RecipientCards, customerOrRecipientId);

            if (!String.IsNullOrEmpty(cardId))
                return string.Format("{0}/{1}", urlParams, cardId);

            return urlParams;
        }
    }
}
