using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SdProject.Apis.Extensions;
using SdProject.Apis.Models.Swaggers;
using SdProject.Apis.Providers.Implementations;
using SdProject.Businesses.Providers.Abstractions;
using SdProject.Commons.Extensions;
using SdProject.Providers.Implementations;
using System.Reflection;

namespace SdProject.Apis
{
    public class Startup
    {
        #region Constructor

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Properties

        public IConfiguration Configuration { get; }

        #endregion

        #region Methods

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add swagger document definition.
            services.AddSwaggerDefinitions(Configuration);

            // Database registration.
            services.AddApplicationDatabase(Configuration);

            // Business services registration.
            services.AddBusinessServices(Configuration);

            // Cors
            services.AddApplicationCors(Configuration);

            services.AddAuthorization();
            services.AddScoped<IJsonSerializer, CamelCaseJsonSerializer>();
            services.AddScoped<IJsonSerializer, SnakeCaseJsonSerializer>();
            services.AddValidatorsFromAssembly(typeof(Startup).GetTypeInfo().Assembly);
            services.AddControllers(options =>
            {
                options.Filters.AddApplicationExceptionFilters();
            })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.AddApplicationJsonConverters();

                    var camelCasePropertyNamesContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ContractResolver = camelCasePropertyNamesContractResolver;
                    options.SerializerSettings.ConstructorHandling =
                        ConstructorHandling.AllowNonPublicDefaultConstructor;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // Authentication & authorization.
            app.UseRouting();
            app.UseApplicationCors();
            app.UseAuthentication();
            app.UseAuthorization();

            // Enable swagger documentation.
            var apiDocumentSettingsOptions = app.ApplicationServices.GetRequiredService<IOptions<ApiDocument>>();
            if (apiDocumentSettingsOptions?.Value.Enabled == true)
            {
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        #endregion
    }
}