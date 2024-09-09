using GeoApi.Infrastructure.Services.ApiSettings;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoApi.Infrastructure.Services.BaseApiService
{
    public class BaseApiService
    {
        protected readonly ExternalAPISettingsItem _apiSettings;
        protected readonly RestClient _client;

        public BaseApiService(ExternalAPISettingsItem externalApiSettings, RestClient client)
        {
            _apiSettings = externalApiSettings;
            _client = client;
            //TODO: Add Logger
        }

        protected async Task<T?> GetAsync<T>(string url)
        {
            var request = new RestRequest(url);
            var response = await _client.GetAsync<T>(request);
            return response;
        }
    }
}
