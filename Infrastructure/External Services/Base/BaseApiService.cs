using GeoApi.Infrastructure.Services.ApiSettings;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoApi.Infrastructure.Services.Base
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
            var response = await _client.ExecuteAsync<T>(request);
            var apiResponse = JsonConvert.DeserializeObject<T>(response.Content)!;
            //TODO: Add Error handling
            return apiResponse; 
        }
    }
}
