using Newtonsoft.Json;

namespace Stripe
{
    public class StripeAccountAdditionalOwner : INestedOptions
    {
        [JsonProperty("[address][city]")]
        public string CityOrTown { get; set; }

        [JsonProperty("[address][country]")]
        public string Country { get; set; }

        [JsonProperty("[address][line1]")]
        public string Line1 { get; set; }

        [JsonProperty("[address][line2]")]
        public string Line2 { get; set; }

        [JsonProperty("[address][postal_code]")]
        public string PostalCode { get; set; }

        [JsonProperty("[address][state]")]
        public string State { get; set; }

        [JsonProperty("[dob][day]")]
        public int? BirthDay { get; set; }

        [JsonProperty("[dob][month]")]
        public int? BirthMonth { get; set; }

        [JsonProperty("[dob][year]")]
        public int? BirthYear { get; set; }

        [JsonProperty("[first_name]")]
        public string FirstName { get; set; }

        [JsonProperty("[last_name]")]
        public string LastName { get; set; }

        /// <summary>
        /// An ID returned by a file upload with the purpose ‘identity_document’. This will be unset if you POST an empty value.
        /// </summary>
        [JsonProperty("[verification][document]")]
        public string DocumentId { get; set; }
    }
}
