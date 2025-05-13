using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZengoApi.Application.Cities.Commands.CreateCity;
using ZengoApi.Application.Cities.Commands.DeleteCity;
using ZengoApi.Application.Cities.Commands.UpdateCity;
using ZengoApi.Application.Cities.Queries.GetCitiesByRegionId;
using ZengoApi.Domain.Models;

namespace ZengoApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        private static List<City> cities = new()
        {
            new() { Id = 1, Name = "Szeged", RegionId = 1 },
        };

        // GET: api/City/5
        [HttpGet("{regionId}")]
        public async Task<ActionResult<List<City>>> GetCities(int regionId)
        {
            var allCities = await _sender.Send(new GetCitiesByRegionIdQuery(regionId));
            return Ok(allCities);
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, City city)
        {
            if (city.Id != id)
            {
                return BadRequest();
            }

            await _sender.Send(new UpdateCityCommand(city.Id, city.Name, city.RegionId));
            return Ok();
        }

        // POST: api/City
        [HttpPost]
        public async Task<IActionResult> PostCity(City city)
        {
            await _sender.Send(new CreateCityCommand(city.Name, city.RegionId));
            return Ok();
        }

        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            await _sender.Send(new DeleteCityCommand(id));
            return Ok();
        }
    }
}
