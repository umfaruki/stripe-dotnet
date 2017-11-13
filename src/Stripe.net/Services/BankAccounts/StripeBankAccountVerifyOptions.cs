using Newtonsoft.Json;

namespace Stripe
{
    public class StripeBankAccountVerifyOptions
    {
        [JsonProperty("amounts[]")]
        public int AmountOne { get; set; }

        [JsonProperty("amounts[]")]
        public int AmountTwo { get; set; }
    }
}
