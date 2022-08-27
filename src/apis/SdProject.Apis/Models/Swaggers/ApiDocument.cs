using System.Collections.Generic;

namespace SdProject.Apis.Models.Swaggers
{
    public class ApiDocument
    {
        #region Properties

        public string DocumentName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool GenerateEnumMappingDescription { get; set; }

        public List<ApiDocumentSecurity> Securities { get; set; }

        public bool Enabled { get; set; }

        #endregion
    }
}