using Microsoft.EntityFrameworkCore;
using ZengoApi.Infrastructure;
using ZengoApi.Infrastructure.ErrorHandling;
using ZengoApi.Infrastructure.Repositories;

namespace ZengoApi.Start
{
    public static class ConfigureExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, string[] allowedOrigins)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        public static void ConfigureMSSQL(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddDbContext<CityDbContext>(options =>
                options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("connection")));
        }

        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });
        }

        public static void ConfigureTransients(this IServiceCollection services)
        {
            services.AddTransient<IRegionsRepository, RegionsRepository>();
            services.AddTransient<ICitiesRepository, CitiesRepository>();
        }

        public static void ConfigureExceptionHandler(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalErrorHandler>();
            services.AddProblemDetails();
        }
    }
}
