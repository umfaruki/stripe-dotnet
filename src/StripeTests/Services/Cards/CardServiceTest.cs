namespace StripeTests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Stripe;
    using Xunit;

    /*
     * We do not test the object property on returned values for most methods
     * as stripe-mock returns a Bank Account for those.
     */
    public class CardServiceTest : BaseStripeTest
    {
        private const string CardId = "card_123";
        private const string CustomerId = "cus_123";

        private CardService service;
        private CardCreateOptions createOptions;
        private CardUpdateOptions updateOptions;
        private CardListOptions listOptions;

        public CardServiceTest()
        {
            this.service = new CardService();

            this.createOptions = new CardCreateOptions()
            {
                SourceToken = "tok_123",
            };

            this.updateOptions = new CardUpdateOptions()
            {
                Metadata = new Dictionary<string, string>()
                {
                    { "key", "value" },
                },
            };

            this.listOptions = new CardListOptions()
            {
                Limit = 1,
            };
        }

        [Fact]
        public void Create()
        {
            var card = this.service.Create(CustomerId, this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/customers/cus_123/sources");
            Assert.NotNull(card);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var card = await this.service.CreateAsync(CustomerId, this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/customers/cus_123/sources");
            Assert.NotNull(card);
        }

        [Fact]
        public void Delete()
        {
            var deleted = this.service.Delete(CustomerId, CardId);
            this.AssertRequest(HttpMethod.Delete, "/v1/customers/cus_123/sources/card_123");
            Assert.NotNull(deleted);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var deleted = await this.service.DeleteAsync(CustomerId, CardId);
            this.AssertRequest(HttpMethod.Delete, "/v1/customers/cus_123/sources/card_123");
            Assert.NotNull(deleted);
        }

        [Fact]
        public void Get()
        {
            var card = this.service.Get(CustomerId, CardId);
            this.AssertRequest(HttpMethod.Get, "/v1/customers/cus_123/sources/card_123");
            Assert.NotNull(card);
        }

        [Fact]
        public async Task GetAsync()
        {
            var card = await this.service.GetAsync(CustomerId, CardId);
            this.AssertRequest(HttpMethod.Get, "/v1/customers/cus_123/sources/card_123");
            Assert.NotNull(card);
        }

        [Fact]
        public void List()
        {
            var cards = this.service.List(CustomerId, this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/customers/cus_123/sources");
            Assert.NotNull(cards);
            Assert.Equal("list", cards.Object);
            Assert.Single(cards.Data);
        }

        [Fact]
        public async Task ListAsync()
        {
            var cards = await this.service.ListAsync(CustomerId, this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/customers/cus_123/sources");
            Assert.NotNull(cards);
            Assert.Equal("list", cards.Object);
            Assert.Single(cards.Data);
        }

        [Fact]
        public void Update()
        {
            var card = this.service.Update(CustomerId, CardId, this.updateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/customers/cus_123/sources/card_123");
            Assert.NotNull(card);
            Assert.Equal("card", card.Object);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var card = await this.service.UpdateAsync(CustomerId, CardId, this.updateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/customers/cus_123/sources/card_123");
            Assert.NotNull(card);
            Assert.Equal("card", card.Object);
        }
    }
}
