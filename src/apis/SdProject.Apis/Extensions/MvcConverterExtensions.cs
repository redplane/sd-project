using System.Collections.Generic;
using Newtonsoft.Json;

namespace SdProject.Apis.Extensions
{
    public static class MvcConverterExtensions
    {
        #region Methods

        public static IList<JsonConverter> AddApplicationJsonConverters(this IList<JsonConverter> converters)
        {
            return converters;
        }

        #endregion
    }
}