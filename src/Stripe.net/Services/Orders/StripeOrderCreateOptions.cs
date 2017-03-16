using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stripe
{
    public class StripeOrderCreateOptions
    {
        /// <summary>
        /// REQUIRED: 3-letter ISO code representing the currency in which the order should be made. Stripe will validate that all entries in items match the currency specified here.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}