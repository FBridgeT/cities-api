using MediatR;
using ZengoApi.Domain.Models;

namespace ZengoApi.Application.Cities.Queries.GetCitiesByRegionId
{
    public sealed record GetCitiesByRegionIdQuery(int RegionId) : IRequest<List<City>>;
}
