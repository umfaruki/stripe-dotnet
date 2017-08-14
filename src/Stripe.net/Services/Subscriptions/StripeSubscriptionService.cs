using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public partial class StripeSubscriptionService : StripeBasicService<StripeSubscription>
    {
        public StripeSubscriptionService(string apiKey = null) : base(apiKey) { }

        public bool ExpandCustomer { get; set; }

        //Sync
        public StripeSubscription Get(string subscriptionId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(subscriptionId, requestOptions, CancellationToken.None).Result;
        }

        public StripeSubscription Create(string customerId, string planId, StripeSubscriptionCreateOptions createOptions = null, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(customerId, planId, createOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeSubscription Create(string customerId, StripeSubscriptionCreateOptions createOptions = null, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(customerId, createOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeSubscription Update(string subscriptionId, StripeSubscriptionUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(subscriptionId, updateOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeSubscription Cancel(string subscriptionId, bool cancelAtPeriodEnd = false, StripeRequestOptions requestOptions = null)
        {
            return CancelAsync(subscriptionId, cancelAtPeriodEnd, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripeSubscription> List(StripeSubscriptionListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;
        }

        //Async
        public Task<StripeSubscription> GetAsync(string subscriptionId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.Subscriptions}/{subscriptionId}", requestOptions, cancellationToken);
        }

        public Task<StripeSubscription> CreateAsync(string customerId, string planId, StripeSubscriptionCreateOptions createOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = this.ApplyAllParameters(createOptions, Urls.Subscriptions, false);
            createOptions = createOptions ?? new StripeSubscriptionCreateOptions();
            createOptions.CustomerId = customerId;
            createOptions.Items = createOptions.Items ?? new List<StripeSubscriptionItemOption>();
            createOptions.Items.Add(new StripeSubscriptionItemOption() {
              PlanId=planId,
              Quantity=1
            });
            return CreateAsync(createOptions, requestOptions, cancellationToken);
        }

        public Task<StripeSubscription> CreateAsync(string customerId, StripeSubscriptionCreateOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            createOptions.CustomerId = customerId;
            return CreateAsync(createOptions, requestOptions, cancellationToken);
        }

        private Task<StripeSubscription> CreateAsync(StripeSubscriptionCreateOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken)) {
            return PostEntityAsync($"{Urls.Subscriptions}", requestOptions, cancelAtPeriodEnd, createOptions);
        }

        public Task<StripeSubscription> UpdateAsync(string subscriptionId, StripeSubscriptionUpdateOptions updateOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.Subscriptions}/{subscriptionId}", requestOptions, cancellationToken, updateOptions);
        }

        public Task<StripeSubscription> CancelAsync(string subscriptionId, bool cancelAtPeriodEnd = false, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = $"{Urls.Subscriptions}/{subscriptionId}";
            url = ParameterBuilder.ApplyParameterToUrl(url, "at_period_end", cancelAtPeriodEnd.ToString());
            return DeleteEntityAsync(url, requestOptions, cancellationToken);
        }

        public Task<StripeList<StripeSubscription>> ListAsync(StripeSubscriptionListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.Subscriptions}", requestOptions, cancellationToken, listOptions);
        }
    }
}
