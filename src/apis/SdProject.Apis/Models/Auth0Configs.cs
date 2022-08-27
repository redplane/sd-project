namespace SdProject.Apis.Models
{
    public class Auth0Configs
    {
        #region Properties

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Domain { get; set; }
        public string Identifier { get; set; }

        #endregion
    }
}