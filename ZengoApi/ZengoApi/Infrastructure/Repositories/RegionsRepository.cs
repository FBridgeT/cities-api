using ZengoApi.Domain.Models;

namespace ZengoApi.Infrastructure.Repositories
{
    public class RegionsRepository : IRegionsRepository
    {
        private readonly List<Region> regions = new()
        {
            new() { Id = 1, Name = "Győr-Moson-Sopron" },
            new() { Id = 2, Name = "Vas" },
            new() { Id = 3, Name = "Zala" },
            new() { Id = 4, Name = "Somogy" },
            new() { Id = 5, Name = "Veszprém" },
            new() { Id = 6, Name = "Komárom-Esztergom" },
            new() { Id = 7, Name = "Fejér" },
            new() { Id = 8, Name = "Tolna" },
            new() { Id = 9, Name = "Baranya" },
            new() { Id = 10, Name = "Bács-Kiskun" },
            new() { Id = 11, Name = "Pest" },
            new() { Id = 12, Name = "Nógrád" },
            new() { Id = 13, Name = "Heves" },
            new() { Id = 14, Name = "Jász-Nagykun-Szolnok" },
            new() { Id = 15, Name = "Csongrád" },
            new() { Id = 16, Name = "Békés" },
            new() { Id = 17, Name = "Hajdú-Bihar" },
            new() { Id = 18, Name = "Borsod-Abaúj-Zemplén" },
            new() { Id = 19, Name = "Szabolcs-Szatmár-Bereg" },
        };

        public Task<List<Region>> GetAllRegionsAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(regions);
        }

        public async Task<bool> IsRegionExists(int regionId, CancellationToken cancellationToken)
        {
            var isExists = regions.Any(x => x.Id == regionId);
            return isExists;
        }
    }
}
