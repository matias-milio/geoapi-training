using AutoMapper;
using GeoApi.Application.Contracts;
using GeoApi.Domain.ValueTypes;
using GeoApi.Infrastructure.Services.GoogleMapsApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoApi.Application.Implementations
{
    public class GeoLocalizationService : IGeoLocalizationService
    {
        private readonly IGoogleMapsApiService _googleMapsApiService;
        private readonly IMapper _mapper;


        public GeoLocalizationService(IGoogleMapsApiService googleMapsApiService, IMapper mapper)
        {
           _googleMapsApiService = googleMapsApiService;
           _mapper = mapper;
        }

        public async Task<Geocode> GeocodeAddress(string address)
        {
            var apiResponse = await _googleMapsApiService.GeocodeAddress(address); 
            return _mapper.Map<Geocode>(apiResponse); 
        }

    }
}
