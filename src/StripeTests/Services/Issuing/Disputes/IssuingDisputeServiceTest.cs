namespace StripeTests.Issuing
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Stripe.Issuing;
    using Xunit;

    public class IssuingDisputeServiceTest : BaseStripeTest
    {
        private const string DisputeId = "idp_123";

        private DisputeService service;
        private DisputeCreateOptions createOptions;
        private DisputeUpdateOptions updateOptions;
        private DisputeListOptions listOptions;

        public IssuingDisputeServiceTest()
        {
            this.service = new DisputeService();

            this.createOptions = new DisputeCreateOptions()
            {
                DisputedTransactionId = "ipi_123",
                Evidence = new EvidenceOptions
                {
                    Fraudulent = new EvidenceDetailsOptions
                    {
                        DisputeExplanation = "Explanation",
                        UncategorizedFile = "file_123",
                    }
                },
                Reason = "fraudulent",
            };

            this.updateOptions = new DisputeUpdateOptions()
            {
                Metadata = new Dictionary<string, string>()
                {
                    { "key", "value" },
                },
            };

            this.listOptions = new DisputeListOptions()
            {
                Limit = 1,
            };
        }

        [Fact]
        public void Create()
        {
            var dispute = this.service.Create(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/disputes");
            Assert.NotNull(dispute);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var dispute = await this.service.CreateAsync(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/disputes");
            Assert.NotNull(dispute);
        }

        [Fact]
        public void Get()
        {
            var dispute = this.service.Get(DisputeId);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/disputes/idp_123");
            Assert.NotNull(dispute);
        }

        [Fact]
        public async Task GetAsync()
        {
            var dispute = await this.service.GetAsync(DisputeId);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/disputes/idp_123");
            Assert.NotNull(dispute);
        }

        [Fact]
        public void List()
        {
            var disputes = this.service.List(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/disputes");
            Assert.NotNull(disputes);
        }

        [Fact]
        public async Task ListAsync()
        {
            var disputes = await this.service.ListAsync(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/disputes");
            Assert.NotNull(disputes);
        }

        [Fact]
        public void Update()
        {
            var dispute = this.service.Update(DisputeId, this.updateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/disputes/idp_123");
            Assert.NotNull(dispute);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var dispute = await this.service.UpdateAsync(DisputeId, this.updateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/disputes/idp_123");
            Assert.NotNull(dispute);
        }
    }
}
