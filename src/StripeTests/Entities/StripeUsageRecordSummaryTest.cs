namespace StripeTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using Stripe;
    using Xunit;

    public class StripeUsageRecordSummaryTest : BaseStripeTest
    {
        [Fact]
        public void Deserialize()
        {
            string json = GetFixture("/v1/subscription_items/si_123/usage_record_summaries");
            var summaries = Mapper<StripeList<StripeUsageRecordSummary>>.MapFromJson(json);
            Assert.NotNull(summaries);

            var summary = summaries.Data[0];
            Assert.NotNull(summary);
            Assert.IsType<StripeUsageRecordSummary>(summary);
            Assert.NotNull(summary.Id);
            Assert.Equal("usage_record_summary", summary.Object);
        }
    }
}
