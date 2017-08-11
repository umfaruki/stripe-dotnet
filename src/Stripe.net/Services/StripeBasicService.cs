using System;
﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public abstract class StripeBasicService<EntityReturned> : StripeService
    {
        protected StripeBasicService(string apiKey = null) : base(apiKey) { }

        protected virtual async Task<EntityReturned> GetEntityAsync(string url, StripeRequestOptions requestOptions, CancellationToken cancellationToken, object options = null)
        {
            return Mapper<EntityReturned>.MapFromJson(
                await Requestor.GetStringAsync(
                    this.ApplyAllParameters(options, url),
                    SetupRequestOptions(requestOptions),
                    cancellationToken
                )
            );
        }

        protected virtual async Task<StripeList<EntityReturned>> GetEntityListAsync(string url, StripeRequestOptions requestOptions, CancellationToken cancellationToken, object options = null)
        {
            return Mapper<StripeList<EntityReturned>>.MapFromJson(
                await Requestor.GetStringAsync(
                    this.ApplyAllParameters(options, url),
                    SetupRequestOptions(requestOptions),
                    cancellationToken
                )
            );
        }

        protected virtual async Task<EntityReturned> PostEntityAsync(string url, StripeRequestOptions requestOptions, CancellationToken cancellationToken, object options = null)
        {
            return Mapper<EntityReturned>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(options, url),
                    SetupRequestOptions(requestOptions),
                    cancellationToken
                )
            );
        }

        protected virtual async Task<StripeDeleted> DeleteEntityAsync(string url, StripeRequestOptions requestOptions, CancellationToken cancellationToken, object options = null)
        {
            return Mapper<StripeDeleted>.MapFromJson(
                await Requestor.DeleteAsync(
                    this.ApplyAllParameters(options, url),
                    SetupRequestOptions(requestOptions),
                    cancellationToken
                )
             );
        }


    }
}
