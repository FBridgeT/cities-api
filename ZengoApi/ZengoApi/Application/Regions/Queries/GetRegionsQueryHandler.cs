using MediatR;
using ZengoApi.Domain.Models;
using ZengoApi.Infrastructure.Repositories;

namespace ZengoApi.Application.Regions.Queries
{
    public class GetRegionsQueryHandler(
        IRegionsRepository regionsRepository)
        : IRequestHandler<GetRegionsQuery, List<Region>>
    {
        private readonly IRegionsRepository _regionRepository = regionsRepository;

        public Task<List<Region>> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
        {
            var regions = _regionRepository.GetAllRegionsAsync(cancellationToken);
            return regions;
        }
    }
}
