using Newtonsoft.Json;
using SdProject.Businesses.Constants;

namespace SdProject.Businesses.Providers
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