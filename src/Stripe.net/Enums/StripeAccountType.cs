using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Stripe
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StripeAccountType
    {
        [EnumMember(Value = "custom")]
        Custom,

        [EnumMember(Value = "express")]
        Express,

        [EnumMember(Value = "standard")]
        Standard,
    }
}
