namespace Stripe
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    using Stripe.Infrastructure;

    public abstract class Service<EntityReturned>
        where EntityReturned : StripeEntity
    {
        protected Service()
        {
        }

        protected Service(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        public string ApiKey { get; set; }

        // TODO: make abstract to force services to implement this
        public virtual string BasePath { get; }

        public virtual EntityReturned DeleteEntity(string url, RequestOptions requestOptions, BaseOptions options = null)
        {
            return this.DeleteRequest<EntityReturned>(url, options, requestOptions);
        }

        public Task<EntityReturned> DeleteEntityAsync(string url, RequestOptions requestOptions, CancellationToken cancellationToken, BaseOptions options = null)
        {
            return this.DeleteRequestAsync<EntityReturned>(url, options, requestOptions, cancellationToken);
        }

        public EntityReturned GetEntity(string url, RequestOptions requestOptions, BaseOptions options = null)
        {
            return this.GetRequest<EntityReturned>(url, options, requestOptions);
        }

        public Task<EntityReturned> GetEntityAsync(string url, RequestOptions requestOptions, CancellationToken cancellationToken, BaseOptions options = null)
        {
            return this.GetRequestAsync<EntityReturned>(url, options, requestOptions, cancellationToken);
        }

        public StripeList<EntityReturned> GetEntityList(string url, RequestOptions requestOptions, BaseOptions options = null)
        {
            return this.GetRequest<StripeList<EntityReturned>>(url, options, requestOptions);
        }

        public Task<StripeList<EntityReturned>> GetEntityListAsync(string url, RequestOptions requestOptions, CancellationToken cancellationToken, BaseOptions options = null)
        {
            return this.GetRequestAsync<StripeList<EntityReturned>>(url, options, requestOptions, cancellationToken);
        }

        public EntityReturned Post(string url, RequestOptions requestOptions, BaseOptions options = null)
        {
            return this.PostRequest<EntityReturned>(url, options, requestOptions);
        }

        public Task<EntityReturned> PostAsync(string url, RequestOptions requestOptions, CancellationToken cancellationToken, BaseOptions options = null)
        {
            return this.PostRequestAsync<EntityReturned>(url, options, requestOptions, cancellationToken);
        }

        protected EntityReturned CreateEntity(BaseOptions options = null, RequestOptions requestOptions = null)
        {
            return this.PostRequest<EntityReturned>(this.ClassUrl(), options, requestOptions);
        }

        protected Task<EntityReturned> CreateEntityAsync(BaseOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.PostRequestAsync<EntityReturned>(this.ClassUrl(), options, requestOptions, cancellationToken);
        }

        // TODO: rename to DeleteEntity
        protected EntityReturned DeleteEntityNew(string id, RequestOptions requestOptions = null)
        {
            return this.DeleteEntityNew(id, null, requestOptions);
        }

        // TODO: rename to DeleteEntity
        protected EntityReturned DeleteEntityNew(string id, BaseOptions options = null, RequestOptions requestOptions = null)
        {
            return this.DeleteRequest<EntityReturned>(this.InstanceUrl(id), options, requestOptions);
        }

        // TODO: rename to DeleteEntityAsync
        protected Task<EntityReturned> DeleteEntityAsyncNew(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.DeleteEntityAsyncNew(id, null, requestOptions, cancellationToken);
        }

        // TODO: rename to DeleteEntityAsync
        protected Task<EntityReturned> DeleteEntityAsyncNew(string id, BaseOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.DeleteRequestAsync<EntityReturned>(this.InstanceUrl(id), options, requestOptions, cancellationToken);
        }

        // TODO: rename to GetEntity
        protected EntityReturned GetEntityNew(string id, RequestOptions requestOptions = null)
        {
            return this.GetEntityNew(id, null, requestOptions);
        }

        // TODO: rename to GetEntity
        protected EntityReturned GetEntityNew(string id, BaseOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetRequest<EntityReturned>(this.InstanceUrl(id), options, requestOptions);
        }

        // TODO: rename to GetEntityAsync
        protected Task<EntityReturned> GetEntityAsyncNew(string id, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsyncNew(id, null, requestOptions, cancellationToken);
        }

        // TODO: rename to GetEntityAsync
        protected Task<EntityReturned> GetEntityAsyncNew(string id, BaseOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetRequestAsync<EntityReturned>(this.InstanceUrl(id), options, requestOptions, cancellationToken);
        }

        protected StripeList<EntityReturned> ListEntities(ListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetRequest<StripeList<EntityReturned>>(this.ClassUrl(), options, requestOptions);
        }

        protected Task<StripeList<EntityReturned>> ListEntitiesAsync(ListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetRequestAsync<StripeList<EntityReturned>>(this.ClassUrl(), options, requestOptions, cancellationToken);
        }

        protected EntityReturned UpdateEntity(string id, BaseOptions options = null, RequestOptions requestOptions = null)
        {
            return this.PostRequest<EntityReturned>(this.InstanceUrl(id), options, requestOptions);
        }

        protected Task<EntityReturned> UpdateEntityAsync(string id, BaseOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.PostRequestAsync<EntityReturned>(this.InstanceUrl(id), options, requestOptions, cancellationToken);
        }

        protected T DeleteRequest<T>(string url, BaseOptions options, RequestOptions requestOptions)
        {
            return Mapper<T>.MapFromJson(
                Requestor.Delete(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions)));
        }

        protected async Task<T> DeleteRequestAsync<T>(string url, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return Mapper<T>.MapFromJson(
                await Requestor.DeleteAsync(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }

        protected T GetRequest<T>(string url, BaseOptions options, RequestOptions requestOptions)
        {
            return Mapper<T>.MapFromJson(
                Requestor.GetString(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions)));
        }

        protected async Task<T> GetRequestAsync<T>(string url, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return Mapper<T>.MapFromJson(
                await Requestor.GetStringAsync(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }

        protected T PostRequest<T>(string url, BaseOptions options, RequestOptions requestOptions)
        {
            return Mapper<T>.MapFromJson(
                Requestor.PostString(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions)));
        }

        protected async Task<T> PostRequestAsync<T>(string url, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return Mapper<T>.MapFromJson(
                await Requestor.PostStringAsync(
                    this.ApplyAllParameters(options, url),
                    this.SetupRequestOptions(requestOptions),
                    cancellationToken).ConfigureAwait(false));
        }

        protected RequestOptions SetupRequestOptions(RequestOptions requestOptions)
        {
            if (requestOptions == null)
            {
                requestOptions = new RequestOptions();
            }

            if (!string.IsNullOrEmpty(this.ApiKey))
            {
                requestOptions.ApiKey = this.ApiKey;
            }

            return requestOptions;
        }

        protected virtual string ClassUrl(string baseUrl = null)
        {
            baseUrl = baseUrl ?? StripeConfiguration.GetApiBase();
            return $"{baseUrl}{this.BasePath}";
        }

        protected virtual string InstanceUrl(string id, string baseUrl = null)
        {
            return $"{this.ClassUrl(baseUrl)}/{WebUtility.UrlEncode(id)}";
        }
    }
}
