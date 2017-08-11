using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeCustomerService : StripeBasicService<StripeCustomer>
    {
        public StripeCustomerService(string apiKey = null) : base(apiKey) { }

        public bool ExpandDefaultSource { get; set; }
        public bool ExpandDefaultCustomerBankAccount { get; set; }

        //Sync
        public StripeCustomer Create(StripeCustomerCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(createOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeCustomer Get(string customerId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(customerId, requestOptions, CancellationToken.None).Result;
        }

        public StripeCustomer Update(string customerId, StripeCustomerUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(customerId, updateOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeDeleted Delete(string customerId, StripeRequestOptions requestOptions = null)
        {
            return DeleteAsync(customerId, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeCustomer> List(StripeCustomerListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;
        }

        //Async
        public Task<StripeCustomer> CreateAsync(StripeCustomerCreateOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.Customers}", requestOptions, cancellationToken, createOptions);
        }

        public Task<StripeCustomer> GetAsync(string customerId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.Customers}/{customerId}", requestOptions, cancellationToken);
        }

        public Task<StripeCustomer> UpdateAsync(string customerId, StripeCustomerUpdateOptions updateOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.Customers}/{customerId}", requestOptions, cancellationToken, updateOptions);
        }

        public Task<StripeDeleted> DeleteAsync(string customerId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteEntityAsync($"{Urls.Customers}/{customerId}", requestOptions, cancellationToken);
        }

        public Task<StripeList<StripeCustomer>> ListAsync(StripeCustomerListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.Customers}", requestOptions, cancellationToken, listOptions);
        }
    }
}
