using Newtonsoft.Json;

namespace Stripe
{
    public class StripeBankAccountCreateOptions
    {
        [JsonProperty("source")]
        public string SourceToken { get; set; }

        [JsonProperty("source")]
        public SourceBankAccount SourceBankAccount { get; set; }
    }
}
