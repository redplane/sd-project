using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SdProject.Apis.Constants;
using SmartSensor.Cores.Models.Cors;

namespace SdProject.Apis.Extensions
{
    //
    public static class CorsExtensions
    {
        #region Methods

        internal static IServiceCollection AddApplicationCors(this IServiceCollection services,
            IConfiguration configuration)
        {
            var corsConfigurations = configuration.GetSection(ConfigurationKeys.Cors)
                .Get<CorsOptions[]>();

            foreach (var corsConfiguration in corsConfigurations)
            {
                if (!corsConfiguration.Enabled)
                    continue;

                services.AddCors(options => options.AddPolicy(corsConfiguration.Name,
                    builder =>
                    {
                        // Headers
                        var headers = corsConfiguration.Headers;
                        if (headers.Any())
                        {
                            if (headers.Any(x => x.Equals("*")))
                                builder.AllowAnyHeader();
                            else
                                builder.WithHeaders(headers);
                        }

                        // Methods
                        var methods = corsConfiguration.Methods;
                        if (methods.Any())
                        {
                            if (methods.Any(x => x.Equals("*")))
                                builder.AllowAnyMethod();
                            else
                                builder.WithMethods(methods);
                        }

                        var exposedHeaders = corsConfiguration.ExposedHeaders;
                        if (exposedHeaders.Any())
                            builder.WithExposedHeaders(exposedHeaders);

                        var origins = corsConfiguration.Origins;
                        if (origins.Any())
                            builder.SetIsOriginAllowed(host =>
                            {
                                return origins.Any(origin => new Regex(origin).IsMatch(host));
                            });

                        if (corsConfiguration.AllowCredentials)
                            builder.AllowCredentials();
                    }));
            }

            return services;
        }

        internal static IApplicationBuilder UseApplicationCors(this IApplicationBuilder app)
        {
            var configuration = app.ApplicationServices.GetRequiredService<IConfiguration>();
            if (configuration == null)
                return app;

            var corsConfigurations = configuration.GetSection(ConfigurationKeys.Cors)
                .Get<CorsOptions[]>();

            foreach (var corsConfiguration in corsConfigurations)
            {
                if (!corsConfiguration.Enabled)
                    continue;

                app.UseCors(corsConfiguration.Name);
            }

            return app;
        }

        #endregion
    }
}