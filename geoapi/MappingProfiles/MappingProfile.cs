using AutoMapper;
using GeoApi.Domain.Enums;
using GeoApi.Domain.ValueTypes;
using GeoApi.Infrastructure.Services.GoogleMapsApi.Responses;

namespace GeoApi.API.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GeocodingResponse, Geocode>()
                .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Results))
                .AfterMap((src, dest) =>
                {
                    foreach (var result in src.Results)
                    {
                        var geoCodeResult = dest.Results.FirstOrDefault();
                        if (geoCodeResult != null)
                        {
                            geoCodeResult.Address = BuildAddress(result.AddressComponents);
                            geoCodeResult.StreetNumber = GetStreetNumber(result.AddressComponents);
                            geoCodeResult.Country = GetCountry(result.AddressComponents);
                            geoCodeResult.Province = GetProvince(result.AddressComponents);
                            geoCodeResult.Locality = GetLocality(result.AddressComponents);
                            geoCodeResult.PostalCode = GetPostalCode(result.AddressComponents);
                            geoCodeResult.Latitude = result.Geometry.Location.Latitude;
                            geoCodeResult.Longitude = result.Geometry.Location.Longitude;
                        }
                    }
                });
            CreateMap<Result, Domain.ValueTypes.Location>()
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Geometry.Location.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Geometry.Location.Longitude));
        }

        private string BuildAddress(List<AddressComponent> addressComponents)
        {          
            return addressComponents.FirstOrDefault(ac => ac.Type.Contains(AddressComponentType.Route))?.Name;
        }

        private string GetStreetNumber(List<AddressComponent> addressComponents)
        {
            return addressComponents.FirstOrDefault(ac => ac.Type.Contains(AddressComponentType.StreetNumber))?.Name;
        }

        private string GetCountry(List<AddressComponent> addressComponents)
        {
            return addressComponents.FirstOrDefault(ac => ac.Type.Contains(AddressComponentType.Country))?.Name;
        }

        private string GetProvince(List<AddressComponent> addressComponents)
        {
            return addressComponents.FirstOrDefault(ac => ac.Type.Contains(AddressComponentType.Province))?.Name;
        }

        private string GetLocality(List<AddressComponent> addressComponents)
        {
            return addressComponents.FirstOrDefault(ac => ac.Type.Contains(AddressComponentType.Locality))?.Name;
        }

        private string GetPostalCode(List<AddressComponent> addressComponents)
        {
            return addressComponents.FirstOrDefault(ac => ac.Type.Contains(AddressComponentType.PostalCode))?.Name;
        }
    }
}
