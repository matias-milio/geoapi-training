using GeoApi.Infrastructure.Services.ApiSettings;
using GeoApi.Infrastructure.Services.Base;
using GeoApi.Infrastructure.Services.Extensions;
using GeoApi.Infrastructure.Services.GoogleMapsApi.Contracts;
using GeoApi.Infrastructure.Services.GoogleMapsApi.Responses;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoApi.Infrastructure.Services.GoogleMapsApi.Implementations
{
    public class GoogleMapsApiService : BaseApiService, IGoogleMapsApiService
    {
        public GoogleMapsApiService(IOptions<ExternalAPIsSettings> googleMapsApiSettings, RestClient client) 
        : base(googleMapsApiSettings.Value.GoogleMapsAPI, client)
        {
        }

        public async Task<GeocodingResponse> GeocodeAddress(string address)
        {
            var relativeUrl = $"geocode/json?address={address}&key={_apiSettings.ApiKey}";
            var url = _apiSettings.Url.AppendUriPath(relativeUrl);
            var response = await GetAsync<GeocodingResponse>(url);
            return response;
        }
    }
}
