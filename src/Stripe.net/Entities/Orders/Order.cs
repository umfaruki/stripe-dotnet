namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class Order : StripeEntityWithId, ISupportMetadata
    {
        [JsonProperty("object")]
        public string Object => "order";

        /// <summary>
        /// A positive integer in the smallest currency unit (that is, 100 cents for $1.00, or 1 for ¥1, Japanese Yen being a 0-decimal currency) representing the total amount for the order.
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("amount_returned")]
        public int? AmountReturned { get; set; }

        /// <summary>
        /// ID of the Connect Application that created the order.
        /// </summary>
        [JsonProperty("application")]
        public string Application { get; set; }

        [JsonProperty("application_fee")]
        public int? ApplicationFee { get; set; }

        #region Expandable Charge

        /// <summary>
        /// <para>The ID of the payment used to pay for the order. Present if the order status is paid, fulfilled, or refunded.</para>
        /// <para>Expandable</para>
        /// </summary>
        public string ChargeId { get; set; }

        [JsonIgnore]
        public Charge Charge { get; set; }

        [JsonProperty("charge")]
        internal object InternalCharge
        {
            set
            {
                StringOrObject<Charge>.Map(value, s => this.ChargeId = s, o => this.Charge = o);
            }
        }
        #endregion

        /// <summary>
        /// Time at which the object was created.
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// 3-letter ISO code representing the currency in which the order was made.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        #region Expandable Customer

        /// <summary>
        /// The customer used for the order.
        /// </summary>
        public string CustomerId { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }

        [JsonProperty("customer")]
        internal object InternalCustomer
        {
            set
            {
                StringOrObject<Customer>.Map(value, s => this.CustomerId = s, o => this.Customer = o);
            }
        }
        #endregion

        /// <summary>
        /// The email address of the customer placing the order.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("external_coupon_code")]
        public string ExternalCouponCode { get; set; }

        /// <summary>
        /// List of items constituting the order.
        /// </summary>
        [JsonProperty("items")]
        public List<OrderItem> OrderItems { get; set; }

        [JsonProperty("livemode")]
        public bool Livemode { get; set; }

        /// <summary>
        /// A set of key/value pairs that you can attach to an order object. It can be useful for storing additional information about the order in a structured format.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("returns")]
        public StripeList<OrderReturn> Returns { get; set; }

        /// <summary>
        /// The shipping method that is currently selected for this order, if any. If present, it is equal to one of the ids of shipping methods in the shipping_methods array. At order creation time, if there are multiple shipping methods, Stripe will automatically selected the first method.
        /// </summary>
        [JsonProperty("selected_shipping_method")]
        public string SelectedShippingMethod { get; set; }

        /// <summary>
        /// The shipping address for the order. Present if the order is for goods to be shipped.
        /// </summary>
        [JsonProperty("shipping")]
        public Shipping Shipping { get; set; }

        /// <summary>
        /// A list of supported shipping methods for this order. The desired shipping method can be specified either by updating the order, or when paying it.
        /// </summary>
        [JsonProperty("shipping_methods")]
        public List<ShippingMethod> ShippingMethods { get; set; }

        /// <summary>
        /// Current order status. One of created, paid, canceled, fulfilled, or returned.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The timestamps at which the order status was updated.
        /// </summary>
        [JsonProperty("status_transitions")]
        public StatusTransitions StatusTransitions { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        /// <summary>
        /// The merchant’s order ID if it is different from the Stripe order ID.
        /// </summary>
        [JsonProperty("upstream_id")]
        public string UpstreamId { get; set; }
    }
}
