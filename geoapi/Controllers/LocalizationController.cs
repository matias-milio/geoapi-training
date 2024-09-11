using GeoApi.Application.Contracts;
using GeoApi.Domain.ValueTypes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GeoApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizationController : ControllerBase
    {
        private readonly IGeoLocalizationService _geoLocalizationService;

        public LocalizationController(IGeoLocalizationService geoLocalizationService)
        {
                _geoLocalizationService = geoLocalizationService;
        }

        [HttpGet("geocode")]
        [ProducesResponseType(typeof(Geocode), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGeocode([FromQuery] string adress)
        {
            //TODO: Request handling
            return Ok(await _geoLocalizationService.GeocodeAddress(adress));
        }

    }
}
