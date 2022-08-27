using SdProject.Businesses.Constants;
using SdProject.Businesses.Providers.Abstractions;
using Newtonsoft.Json;

namespace SdProject.Providers.Implementations
{
    public class CamelCaseJsonSerializer : IJsonSerializer
    {
        #region Constructor

        public CamelCaseJsonSerializer()
        {
            Name = JsonSerializerNames.CamelCase;
        }

        #endregion

        #region Properties

        public string Name { get; }

        #endregion

        #region Methods

        public virtual T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public virtual string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        #endregion
    }
}
