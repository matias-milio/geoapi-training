using GeoApi.Infrastructure.Services.GoogleMapsApi.Responses;

namespace GeoApi.Infrastructure.Services.GoogleMapsApi.Contracts
{
    public interface IGoogleMapsApiService
    {
        Task<GeocodingResponse> GeocodeAddress(string address);
    }
}
