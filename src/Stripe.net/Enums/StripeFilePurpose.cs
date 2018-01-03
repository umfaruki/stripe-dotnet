using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Stripe
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StripeFilePurpose
    {
        [EnumMember(Value = "business_logo")]
        BusinessLogo,

        [EnumMember(Value = "dispute_evidence")]
        DisputeEvidence,

        [EnumMember(Value = "identity_document")]
        IdentityDocument,

        [EnumMember(Value = "incorporation_article")]
        IncorporationArticle,

        [EnumMember(Value = "incorporation_document")]
        IncorporationDocument,

        [EnumMember(Value = "payment_provider_transfer")]
        PaymentProviderTransfer,

        [EnumMember(Value = "product_feed")]
        ProductFeed,
    }
}
