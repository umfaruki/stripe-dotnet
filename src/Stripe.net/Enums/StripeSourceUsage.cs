using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Stripe
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StripeSourceUsage
    {
        [EnumMember(Value = "reusable")]
        Reusable,

        [EnumMember(Value = "single_use")]
        SingleUse,
    }
}
