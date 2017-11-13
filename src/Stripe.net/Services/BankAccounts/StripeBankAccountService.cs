using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeBankAccountService : StripeService
    {
        public StripeBankAccountService(string apiKey = null) : base(apiKey) { }

        public bool ExpandCustomer { get; set; }



        //Sync
        public virtual StripeBankAccount Create(string customerId, StripeBankAccountCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return Mapper<StripeBankAccount>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(createOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts"),
                    SetupRequestOptions(requestOptions)
                )
            );
        }

        public virtual StripeBankAccount Get(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null)
        {
            return Mapper<StripeBankAccount>.MapFromJson(
                Requestor.GetString(
                    this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    SetupRequestOptions(requestOptions)
                )
            );
        }

        public virtual StripeBankAccount Update(string customerId, string bankAccountId, StripeBankAccountUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return Mapper<StripeBankAccount>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(updateOptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    SetupRequestOptions(requestOptions)
                )
            );
        }

        public virtual StripeDeleted Delete(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null)
        {
            return Mapper<StripeDeleted>.MapFromJson(
                Requestor.Delete(
                    this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    SetupRequestOptions(requestOptions)
                )
            );
        }

        public virtual StripeList<StripeBankAccount> List(string customerId, StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return Mapper<StripeList<StripeBankAccount>>.MapFromJson(
                Requestor.GetString(
                    this.ApplyAllParameters(listOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts", true),
                    SetupRequestOptions(requestOptions)
                )
            );
        }

        public virtual StripeBankAccount Verify(string customerId, string bankAccountId, StripeBankAccountVerifyOptions verifyoptions, StripeRequestOptions requestOptions = null)
        {
            return Mapper<StripeBankAccount>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(verifyoptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}/verify"),
                    SetupRequestOptions(requestOptions)
                )
            );
        }



        //Async
        public virtual async Task<StripeBankAccount> CreateAsync(string customerId, StripeBankAccountCreateOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<StripeBankAccount>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(createOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts"),
                    SetupRequestOptions(requestOptions),
                    cancellationToken
                )
            );
        }

        public virtual async Task<StripeBankAccount> GetAsync(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<StripeBankAccount>.MapFromJson(
                await Requestor.GetStringAsync(
                    this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    SetupRequestOptions(requestOptions),
                    cancellationToken
                )
            );
        }

        public virtual async Task<StripeBankAccount> UpdateAsync(string customerId, string bankAccountId, StripeBankAccountUpdateOptions updateOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<StripeBankAccount>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(updateOptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    SetupRequestOptions(requestOptions),
                    cancellationToken
                )
            );
        }

        public virtual async Task<StripeDeleted> DeleteAsync(string customerId, string bankAccountId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<StripeDeleted>.MapFromJson(
                await Requestor.DeleteAsync(
                    this.ApplyAllParameters(null, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}"),
                    SetupRequestOptions(requestOptions),
                    cancellationToken
                )
            );
        }

        public virtual async Task<StripeList<StripeBankAccount>> ListAsync(string customerId, StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<StripeList<StripeBankAccount>>.MapFromJson(
                await Requestor.GetStringAsync(
                    this.ApplyAllParameters(listOptions, $"{Urls.BaseUrl}/customers/{customerId}/bank_accounts", true),
                    SetupRequestOptions(requestOptions),
                    cancellationToken
                )
            );
        }

        public virtual async Task<StripeBankAccount> VerifyAsync(string customerId, string bankAccountId, StripeBankAccountVerifyOptions verifyoptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mapper<StripeBankAccount>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(verifyoptions, $"{Urls.BaseUrl}/customers/{customerId}/sources/{bankAccountId}/verify"),
                    SetupRequestOptions(requestOptions),
                    cancellationToken
                )
            );
        }
    }
}
