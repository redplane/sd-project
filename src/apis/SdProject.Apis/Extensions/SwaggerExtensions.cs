using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SdProject.Apis.Constants;
using SdProject.Apis.Models.Swaggers;
using NSwag;

namespace SdProject.Apis.Extensions
{
    public static class SwaggerExtensions
    {
        #region Methods

        public static void AddSwaggerDefinitions(this IServiceCollection services, IConfiguration configuration)
        {
            // Load api documentation settings from system.
            var apiDocumentSettings = configuration.GetSection(ConfigurationKeys.Swagger);
            services
                .Configure<ApiDocument>(apiDocumentSettings);

            // Deserialize api document generator.
            var apiDocument = new ApiDocument();
            apiDocumentSettings.Bind(apiDocument);

            // Swagger document.
            services.AddSwaggerDocument(options =>
            {
                options.DocumentName = apiDocument.DocumentName;
                options.Title = apiDocument.Title;
                options.Description = apiDocument.Description;

                options.GenerateEnumMappingDescription = apiDocument.GenerateEnumMappingDescription;

                foreach (var securityDefinition in apiDocument.Securities)
                {
                    var accessTokenSecurityScheme = new OpenApiSecurityScheme();
                    accessTokenSecurityScheme.AuthorizationUrl = securityDefinition.AuthorizationUrl;
                    accessTokenSecurityScheme.Flow = securityDefinition.Flow;
                    accessTokenSecurityScheme.Scheme = securityDefinition.Scheme;
                    accessTokenSecurityScheme.Type = securityDefinition.Type;
                    accessTokenSecurityScheme.In = securityDefinition.AccessTokenLocation;
                    accessTokenSecurityScheme.Name = securityDefinition.AuthorizationHeaderKeyName;
                    accessTokenSecurityScheme.Description = securityDefinition.Description;

                    options.AddSecurity(securityDefinition.Name, securityDefinition.GlobalScopes,
                        accessTokenSecurityScheme);
                }
            });
        }

        #endregion
    }
}