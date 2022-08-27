using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SdProject.Core.DbContexts;

namespace SdProject.Apis.Extensions
{
    public static class DatabaseServiceExtensions
    {
        #region Methods

        public static IServiceCollection AddApplicationDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SdPDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<SdPDbContext>();
            return services;
        }

        #endregion
    }
}