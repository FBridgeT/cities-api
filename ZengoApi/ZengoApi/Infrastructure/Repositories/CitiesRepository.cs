using ZengoApi.Domain.Models;

namespace ZengoApi.Infrastructure.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {
        private static List<City> cities = new()
        {
            new() { Id = 1, Name = "Szeged", RegionId = 15 },
        };

        public Task<bool> IsCityExists(string cityName, int regionId, CancellationToken cancellationToken)
        {
            var isExists = cities.Any(x => x.RegionId == regionId && x.Name == cityName);
            return Task.FromResult(isExists);
        }

        public Task<bool> IsOriginCityExists(int id, CancellationToken cancellationToken)
        {
            var isExists = cities.Any(x => x.Id == id);
            return Task.FromResult(isExists);
        }

        public Task<List<City>> GetCitiesByRegionId(int reginId, CancellationToken cancellationToken)
        {
            var allCities = cities
                .Where(x => x.RegionId == reginId)
                .ToList();

            return Task.FromResult(allCities);
        }

        public async Task CreateCity(string name, int regionId, CancellationToken cancellationToken)
        {
            City newCity = new()
            {
                Id = cities.Count + 1,
                Name = name,
                RegionId = regionId
            };

            cities.Add(newCity);
        }

        public async Task UpdateCity(string name, int id, CancellationToken cancellationToken)
        {
            var city = cities.FirstOrDefault(x => x.Id == id);
            city!.Name = name;
        }

        public async Task DeleteCity(int id, CancellationToken cancellationToken)
        {
            var deletableCity = cities.Find(x => x.Id == id);
            cities.Remove(deletableCity);
        }
    }
}
