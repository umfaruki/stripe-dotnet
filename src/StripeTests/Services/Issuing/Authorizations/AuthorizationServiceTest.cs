namespace StripeTests.Issuing
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Stripe.Issuing;
    using Xunit;

    public class AuthorizationServiceTest : BaseStripeTest
    {
        private const string AuthorizationId = "iauth_123";

        private AuthorizationService service;
        private AuthorizationUpdateOptions updateOptions;
        private AuthorizationListOptions listOptions;

        public AuthorizationServiceTest()
        {
            this.service = new AuthorizationService();

            this.updateOptions = new AuthorizationUpdateOptions()
            {
                Metadata = new Dictionary<string, string>()
                {
                    { "key", "value" },
                },
            };

            this.listOptions = new AuthorizationListOptions()
            {
                Limit = 1,
            };
        }

        [Fact]
        public void Approve()
        {
            var authorization = this.service.Approve(AuthorizationId);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/authorizations/iauth_123/approve");
            Assert.NotNull(authorization);
        }

        [Fact]
        public async Task ApproveAsync()
        {
            var authorization = await this.service.ApproveAsync(AuthorizationId);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/authorizations/iauth_123/approve");
            Assert.NotNull(authorization);
        }

        [Fact]
        public void Decline()
        {
            var authorization = this.service.Decline(AuthorizationId);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/authorizations/iauth_123/decline");
            Assert.NotNull(authorization);
        }

        [Fact]
        public async Task DeclineAsync()
        {
            var authorization = await this.service.DeclineAsync(AuthorizationId);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/authorizations/iauth_123/decline");
            Assert.NotNull(authorization);
        }

        [Fact]
        public void Get()
        {
            var authorization = this.service.Get(AuthorizationId);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/authorizations/iauth_123");
            Assert.NotNull(authorization);
        }

        [Fact]
        public async Task GetAsync()
        {
            var authorization = await this.service.GetAsync(AuthorizationId);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/authorizations/iauth_123");
            Assert.NotNull(authorization);
        }

        [Fact]
        public void List()
        {
            var authorizations = this.service.List(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/authorizations");
            Assert.NotNull(authorizations);
        }

        [Fact]
        public async Task ListAsync()
        {
            var authorizations = await this.service.ListAsync(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/authorizations");
            Assert.NotNull(authorizations);
        }

        [Fact]
        public void Update()
        {
            var authorization = this.service.Update(AuthorizationId, this.updateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/authorizations/iauth_123");
            Assert.NotNull(authorization);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var authorization = await this.service.UpdateAsync(AuthorizationId, this.updateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/authorizations/iauth_123");
            Assert.NotNull(authorization);
        }
    }
}
