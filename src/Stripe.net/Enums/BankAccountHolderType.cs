using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Stripe
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BankAccountHolderType
    {
        [EnumMember(Value = "company")]
        Company,

        [EnumMember(Value = "send_invoice")]
        Individual,
    }
}
