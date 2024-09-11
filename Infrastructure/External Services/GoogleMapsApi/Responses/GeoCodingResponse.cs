
using GeoApi.Domain.Enums;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GeoApi.Infrastructure.Services.GoogleMapsApi.Responses
{
    public class GeocodingResponse
    {
        [JsonProperty("status")]
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonProperty("results")]
        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        [JsonProperty("address_components")]
        [JsonPropertyName("address_components")]
        public List<AddressComponent> AddressComponents { get; set; }
        [JsonProperty("geometry")]
        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }
    }

    public class AddressComponent
    {
        [JsonProperty("short_name")]
        [JsonPropertyName("short_name")]
        public string Name { get; set; }
        [JsonProperty("types")]
        [JsonPropertyName("types")]
        public List<AddressComponentType>? Type { get; set; }
    }

    public class Geometry
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; }
    }

    public class Location
    {
        [JsonProperty("lat")]
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lng")]
        [JsonPropertyName("lng")]
        public double Longitude { get; set; }
    }
}
