namespace StripeTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Stripe;
    using Xunit;

    public class SourceServiceTest : BaseStripeTest
    {
        private const string CustomerId = "cus_123";
        private const string SourceId = "src_123";

        private SourceService service;
        private SourceCreateOptions createOptions;
        private SourceUpdateOptions updateOptions;
        private SourceListOptions listOptions;

        public SourceServiceTest()
        {
            this.service = new SourceService();

            this.createOptions = new SourceCreateOptions
            {
                Type = SourceType.AchCreditTransfer,
                Currency = "usd",
                Mandate = new SourceMandateOptions
                {
                    Acceptance = new SourceMandateAcceptanceOptions
                    {
                        Date = DateTime.Parse("Mon, 01 Jan 2001 00:00:00Z"),
                        Ip = "127.0.0.1",
                        NotificationMethod = "manual",
                        Status = "accepted",
                        UserAgent = "User-Agent",
                    },
                },
                Owner = new SourceOwnerOptions
                {
                    Address = new AddressOptions
                    {
                        State = "CA",
                        City = "City",
                        Line1 = "Line1",
                        Line2 = "Line2",
                        PostalCode = "90210",
                        Country = "US",
                    },
                    Email = "email@stripe.com",
                    Name = "Owner Name",
                    Phone = "5555555555",
                },
                Receiver = new SourceReceiverOptions
                {
                    RefundAttributesMethod = "manual",
                },
            };

            this.updateOptions = new SourceUpdateOptions
            {
                Metadata = new Dictionary<string, string>()
                {
                    { "key", "value" },
                },
            };

            this.listOptions = new SourceListOptions()
            {
                Limit = 1,
            };
        }

        [Fact]
        public void Create()
        {
            var source = this.service.Create(this.createOptions);
            Assert.NotNull(source);
            Assert.Equal("source", source.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var source = await this.service.CreateAsync(this.createOptions);
            Assert.NotNull(source);
            Assert.Equal("source", source.Object);
        }

        [Fact]
        public void Detach()
        {
            var source = this.service.Detach(CustomerId, SourceId);
            Assert.NotNull(source);
            Assert.Equal("source", source.Object);
        }

        [Fact]
        public async Task DetachAsync()
        {
            var source = await this.service.DetachAsync(CustomerId, SourceId);
            Assert.NotNull(source);
            Assert.Equal("source", source.Object);
        }

        [Fact]
        public void Get()
        {
            var source = this.service.Get(SourceId);
            Assert.NotNull(source);
            Assert.Equal("source", source.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var source = await this.service.GetAsync(SourceId);
            Assert.NotNull(source);
            Assert.Equal("source", source.Object);
        }

        [Fact]
        public void List()
        {
            var sources = this.service.List(CustomerId, this.listOptions);
            Assert.NotNull(sources);
            Assert.Equal("list", sources.Object);
            Assert.Single(sources.Data);
            Assert.Equal("source", sources.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var sources = await this.service.ListAsync(CustomerId, this.listOptions);
            Assert.NotNull(sources);
            Assert.Equal("list", sources.Object);
            Assert.Single(sources.Data);
            Assert.Equal("source", sources.Data[0].Object);
        }

        [Fact]
        public void Update()
        {
            var source = this.service.Update(SourceId, this.updateOptions);
            Assert.NotNull(source);
            Assert.Equal("source", source.Object);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var source = await this.service.UpdateAsync(SourceId, this.updateOptions);
            Assert.NotNull(source);
            Assert.Equal("source", source.Object);
        }
    }
}