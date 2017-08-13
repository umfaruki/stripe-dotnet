using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripePlanService : StripeBasicService<StripePlan>
    {
        public StripePlanService(string apiKey = null) : base(apiKey) { }

        //Sync
        public StripePlan Create(StripePlanCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(createOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripePlan Get(string planId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(planId, requestOptions, CancellationToken.None).Result;
        }

        public StripeDeleted Delete(string planId, StripeRequestOptions requestOptions = null)
        {
            return DeleteAsync(planId, requestOptions, CancellationToken.None).Result;
        }

        public StripePlan Update(string planId, StripePlanUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(planId, updateOptions, requestOptions, CancellationToken.None).Result;
        }

        public StripeList<StripePlan> List(StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions, CancellationToken.None).Result;
        }

        //Async
        public Task<StripePlan> CreateAsync(StripePlanCreateOptions createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.Plans}", requestOptions, cancellationToken, createOptions);
        }

        public Task<StripePlan> GetAsync(string planId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.Plans}/{planId}", requestOptions, cancellationToken);
        }

        public Task<StripeDeleted> DeleteAsync(string planId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteEntityAsync($"{Urls.Plans}/{planId}", requestOptions, cancellationToken);
        }

        public Task<StripePlan> UpdateAsync(string planId, StripePlanUpdateOptions updateOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostEntityAsync($"{Urls.Plans}/{planId}", requestOptions, cancellationToken, updateOptions);
        }

        public Task<StripeList<StripePlan>> ListAsync(StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.Plans}", requestOptions, cancellationToken, listOptions);
        }
    }
}
