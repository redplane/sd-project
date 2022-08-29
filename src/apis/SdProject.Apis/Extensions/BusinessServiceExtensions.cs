using System.Linq;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SdProject.Apis.Cqrs.Pipelines;
using SdProject.Businesses.Providers;
using SdProject.Businesses.Services;
using SdProject.Businesses.Services.Abstractions;

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
            services.AddScoped<IUserBookService, UserBookService>();
            services.AddScoped<IJsonSerializer, SnakeCaseJsonSerializer>();
            services.AddScoped<IJsonSerializer, CamelCaseJsonSerializer>();

            services.AddApplicationValidator();
            return services;
        }

        public static void AddApplicationValidator(this IServiceCollection serviceCollection)
        {
            // All the validator object should be added into DI
            var assemblyType = typeof(Startup).GetTypeInfo();
            var validators = assemblyType.Assembly.DefinedTypes
                .Where(x => x.IsClass && !x.IsAbstract && typeof(IValidator).IsAssignableFrom(x)).ToArray();

            foreach (var validator in validators)
                // Validator is an instance of abstract validator.
                if (validator.BaseType != null && validator.BaseType.IsGenericType &&
                    validator.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>))
                {
                    var validatorType =
                        typeof(IValidator<>).MakeGenericType(validator.BaseType.GetGenericArguments()[0]);
                    serviceCollection.AddSingleton(validatorType, validator);
                }
        }

        #endregion
    }
}