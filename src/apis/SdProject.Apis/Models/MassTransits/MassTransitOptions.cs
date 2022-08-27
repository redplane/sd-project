namespace SdProject.Apis.Models.MassTransits
{
    public class MassTransitOptions
    {
        #region Properties

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public string Kind { get; private set; }

        #endregion

        #region Constructor

        public MassTransitOptions()
        {
        }

        public MassTransitOptions(string kind)
        {
            Kind = kind;
        }

        #endregion
    }
}