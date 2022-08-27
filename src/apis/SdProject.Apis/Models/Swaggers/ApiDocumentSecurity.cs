using System.Collections.Generic;
using NSwag;

namespace SdProject.Apis.Models.Swaggers
{
    public class ApiDocumentSecurity
    {
        #region Methods

        public static implicit operator OpenApiSecurityScheme(ApiDocumentSecurity security)
        {
            var accessTokenSecurityScheme = new OpenApiSecurityScheme();
            accessTokenSecurityScheme.AuthorizationUrl = security.AuthorizationUrl;
            accessTokenSecurityScheme.Flow = security.Flow;
            accessTokenSecurityScheme.Scheme = security.Scheme;
            accessTokenSecurityScheme.Type = security.Type;
            accessTokenSecurityScheme.In = security.AccessTokenLocation;
            accessTokenSecurityScheme.Name = security.AuthorizationHeaderKeyName;
            accessTokenSecurityScheme.Description = security.Description;
            accessTokenSecurityScheme.Scopes = security.Scopes;

            return accessTokenSecurityScheme;
        }

        #endregion

        #region Properties

        public string AuthorizationUrl { get; set; }

        public OpenApiOAuth2Flow Flow { get; set; }

        public string Scheme { get; set; }

        public OpenApiSecuritySchemeType Type { get; set; }

        public OpenApiSecurityApiKeyLocation AccessTokenLocation { get; set; }

        public string AuthorizationHeaderKeyName { get; set; }

        public string Description { get; set; }

        public Dictionary<string, string> Scopes { get; set; }

        public List<string> GlobalScopes { get; set; }

        public string Name { get; set; }

        #endregion
    }
}