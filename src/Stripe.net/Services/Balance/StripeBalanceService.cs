using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripeBalanceService : StripeBasicService<StripeBalanceTransaction>
    {
        public StripeBalanceService(string apiKey = null) : base(apiKey) { }

        public bool ExpandSource { get; set; }

        //Sync
        public virtual StripeBalance Get(StripeRequestOptions requestOptions = null)
        {

            return GetAsync(requestOptions, CancellationToken.None).Result;

        }

        public virtual StripeBalanceTransaction Get(string balanceTransactionId, StripeRequestOptions requestOptions = null)
        {

            return GetAsync(balanceTransactionId, requestOptions, CancellationToken.None).Result;

        }

        public StripeList<StripeBalanceTransaction> List(StripeBalanceTransactionListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {

            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;

        }


        //Async
        public Task<StripeBalance> GetAsync(StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {

            return GetEntityAsync($"{Urls.Balance}", requestOptions, cancellationToken);

        }

        public Task<StripeBalanceTransaction> GetAsync(string balanceTransactionId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {

            return GetEntityAsync($"{Urls.Balance}/{balanceTransactionId}", requestOptions, cancellationToken);

        }

        public Task<StripeList<StripeBalanceTransaction>> ListAsync(StripeBalanceTransactionListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {

            return GetEntityListAsync($"{Urls.BalanceTransactions}", requestOptions, cancellationToken, listOptions);

        }

    }
}
