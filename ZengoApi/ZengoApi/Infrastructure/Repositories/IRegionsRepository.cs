using ZengoApi.Domain.Models;

namespace ZengoApi.Infrastructure.Repositories
{
    public interface IRegionsRepository
    {
        Task<List<Region>> GetAllRegionsAsync(CancellationToken cancellationToken);

        Task<bool> IsRegionExists(int regionId, CancellationToken cancellationToken);
    }
}
