using GeoApi.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoApi.Application.Contracts
{
    public interface IGeoLocalizationService
    {
        Task<Geocode> GeocodeAddress(string address);
    }
}
