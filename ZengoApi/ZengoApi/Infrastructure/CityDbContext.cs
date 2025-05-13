using Microsoft.EntityFrameworkCore;
using ZengoApi.Domain.Models;

namespace ZengoApi.Infrastructure
{
    public class CityDbContext(DbContextOptions<CityDbContext> options) : DbContext(options)
    {
        public DbSet<Region> Region { get; set; }

        public DbSet<City> City { get; set; }
    }
}
