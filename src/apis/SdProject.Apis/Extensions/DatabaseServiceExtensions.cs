using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SdProject.Core.DbContexts;

namespace SdProject.Apis.Extensions
{
    public static class DatabaseServiceExtensions
    {
        #region Methods

        public static IServiceCollection AddApplicationDatabase(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<SdProjectDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<SdProjectDbContext>();
            return services;
        }

        #endregion
    }
}