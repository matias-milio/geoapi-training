
namespace GeoApi.Infrastructure.Services.ApiSettings
{
    public class ExternalAPIsSettings
    {
        public required ExternalAPISettingsItem GoogleMapsAPI { get; set; }
    }

    public class ExternalAPISettingsItem
    {
        public string Url { get; set; }
        public string ApiKey { get; set; }
    }
}
