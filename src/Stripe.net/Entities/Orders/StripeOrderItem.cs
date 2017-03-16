using Newtonsoft.Json;

namespace Stripe
{
    public class StripeOrderItem : StripeEntity
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// A positive integer in the smallest currency unit (that is, 100 cents for $1.00, or 1 for ¥1, Japanese Yen being a 0-decimal currency) representing the total amount for the line item.
        /// </summary>
        [JsonProperty("amount")]
        public int? Amount { get; set; }

        /// <summary>
        /// 3-letter ISO code representing the currency of the line item.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Description of the line item, meant to be displayable to the user (e.g., "Express shipping").
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The ID of the associated object for this line item. Expandable if not null (e.g., expandable to a SKU).
        /// </summary>
        [JsonProperty("parent")]
        public string ParentId { get; set; }

        /// <summary>
        /// A positive integer representing the number of instances of parent that are included in this order item. Applicable/present only if type is sku.
        /// </summary>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// The type of line item. One of sku, tax, shipping, or discount.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}