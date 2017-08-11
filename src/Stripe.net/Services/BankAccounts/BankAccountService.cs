using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class BankAccountService : StripeBasicService<CustomerBankAccount>
    {
        public BankAccountService(string apiKey = null) : base(apiKey) { }

        public bool ExpandCustomer { get; set; }

        //Sync
        public CustomerBankAccount Create(string customerId, BankAccountCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(customerId, createOptions, requestOptions, CancellationToken.None).Result;
        }

        public CustomerBankAccount Get(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(customerId, bankAccountId, requestOptions, CancellationToken.None).Result;
        }

        public CustomerBankAccount Update(string customerId, string bankAccountId, BankAccountUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(customerId, bankAccountId, updateOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeDeleted Delete(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null)
        {
            return DeleteAsync(customerId, bankAccountId, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<CustomerBankAccount> List(string customerId, StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(customerId, listOptions, requestOptions, CancellationToken.None).Result;
        }

        public CustomerBankAccount Verify(string customerId, string bankAccountId, BankAccountVerifyOptions verifyOptions, StripeRequestOptions requestOptions = null)
        {
            return VerifyAsync(customerId, bankAccountId, verifyOptions, requestOptions, CancellationToken.None).Result;
        }

        //Async
        public Task<CustomerBankAccount> CreateAsync(string customerId, BankAccountCreateOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/customers/{customerId}/bank_accounts", requestOptions, cancellationToken, createOptions);
        }

        public Task<CustomerBankAccount> GetAsync(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}", requestOptions, cancellationToken);
        }

        public Task<CustomerBankAccount> UpdateAsync(string customerId, string bankAccountId, BankAccountUpdateOptions updateOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}", requestOptions, cancellationToken, updateOptions);
        }

        public Task<StripeDeleted> DeleteAsync(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteEntityAsync($"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}", requestOptions, cancellationToken);
        }

        public Task<StripeList<CustomerBankAccount>> ListAsync(string customerId, StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.BaseUrl}/customers/{customerId}/bank_accounts", requestOptions, cancellationToken, listOptions);
        }

        public Task<CustomerBankAccount> VerifyAsync(string customerId, string bankAccountId, BankAccountVerifyOptions verifyOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}/verify", requestOptions, cancellationToken, verifyOptions);
        }
    }
}
