using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZengoApi.Application.Regions.Queries;
using ZengoApi.Domain.Models;

namespace ZengoApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegion()
        {
            var allRegions = await _sender.Send(new GetRegionsQuery());
            return Ok(allRegions);
        }
    }
}
