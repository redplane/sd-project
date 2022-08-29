namespace SdProject.Apis.Models
{
    public class CorsOptions
    {
        #region Properties

        public string Name { get; set; }

        public string[] Headers { get; set; }

        public string[] Methods { get; set; }

        public string[] Origins { get; set; }

        public string[] ExposedHeaders { get; set; }

        public bool AllowCredentials { get; set; }

        public bool Enabled { get; set; }

        #endregion
    }
}