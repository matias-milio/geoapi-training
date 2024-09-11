using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GeoApi.Domain.Enums
{
    //Downside of this approach: Need to map every type that comes from the API response.
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AddressComponentType
    {
        [EnumMember(Value = "street_number")]
        StreetNumber,
        [EnumMember(Value = "route")]
        Route,
        [EnumMember(Value = "locality")]
        Locality,
        [EnumMember(Value = "country")]
        Country,
        [EnumMember(Value = "postal_code")]
        PostalCode,
        [EnumMember(Value = "postal_code_suffix")]
        PostalCodeSuffix,
        [EnumMember(Value = "political")]
        Political,
        [EnumMember(Value = "administrative_area_level_1")]
        Province,
        [EnumMember(Value = "administrative_area_level_2")]
        ProvinceLegalName

    }
}
