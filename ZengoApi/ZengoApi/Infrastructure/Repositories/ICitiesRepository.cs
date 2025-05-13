using ZengoApi.Domain.Models;

namespace ZengoApi.Infrastructure.Repositories
{
    public interface ICitiesRepository
    {
        Task<bool> IsCityExists(string cityName, int regionId, CancellationToken cancellationToken);
        Task<bool> IsOriginCityExists(int id, CancellationToken cancellationToken);
        Task<List<City>> GetCitiesByRegionId(int reginId, CancellationToken cancellationToken);
        Task CreateCity(string name, int regionId, CancellationToken cancellationToken);
        Task UpdateCity(string name, int id, CancellationToken cancellationToken);
        Task DeleteCity(int id, CancellationToken cancellationToken);
    }
}
