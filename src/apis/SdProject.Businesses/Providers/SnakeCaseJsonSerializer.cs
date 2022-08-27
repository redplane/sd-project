using SdProject.Businesses.Constants;
using SdProject.Businesses.Providers.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SdProject.Apis.Providers.Implementations
{
    public class SnakeCaseJsonSerializer : IJsonSerializer
    {
        #region Constructor

        public SnakeCaseJsonSerializer()
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };
        }

        #endregion

        #region Properties

        public string Name => JsonSerializerNames.SnakeCase;

        private readonly JsonSerializerSettings _jsonSerializerSettings;

        #endregion

        #region Methods

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings);
        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSerializerSettings);
        }

        #endregion
    }
}
