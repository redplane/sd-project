using System.Reflection;
using ApiFeatures.Commons.PipelineBehaviors;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SdProject.Apis;
using SdProject.Apis.Providers.Implementations;
using SdProject.Businesses.Providers.Abstractions;
using SdProject.Businesses.Services;
using SdProject.Businesses.Services.Abstractions;
using SdProject.Providers.Implementations;

namespace SdProject.Apis.Extensions
{
    public static class BusinessServiceExtensions
    {
        #region Methods

        public static IServiceCollection AddBusinessServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Mediator registration.
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            // Register command & query handlers.
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IJsonSerializer, SnakeCaseJsonSerializer>();
            services.AddScoped<IJsonSerializer, CamelCaseJsonSerializer>();
            return services;
        }

        #endregion
    }
}