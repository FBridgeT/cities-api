using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Build.Framework;
using ZengoApi.Domain.Models;
using ZengoApi.Infrastructure.Repositories;

namespace ZengoApi.Application.Cities.Queries.GetCitiesByRegionId
{
    public class GetCitiesByRegionIdQueryHandler(
        ICitiesRepository citiesRepository)
        : IRequestHandler<GetCitiesByRegionIdQuery, List<City>>
    {
        private readonly ICitiesRepository _citiesRepository = citiesRepository;
        public Task<List<City>> Handle(GetCitiesByRegionIdQuery query, CancellationToken cancellationToken)
        {
            if (query.RegionId < 0)
            {
                throw new BadHttpRequestException($"Invalid RegionId: {query.RegionId}");
            }

            var cities = _citiesRepository.GetCitiesByRegionId(query.RegionId, cancellationToken);
            return cities;
        }
    }
}
