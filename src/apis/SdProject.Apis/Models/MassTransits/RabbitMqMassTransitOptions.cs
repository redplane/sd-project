using SdProject.Apis.Constants;

namespace SdProject.Apis.Models.MassTransits
{
    public class RabbitMqMassTransitOptions : MassTransitOptions
    {
        #region Constructor

        public RabbitMqMassTransitOptions() : base(MassTransitKinds.RabbitMq)
        {
        }

        #endregion

        #region Properties

        public string Host { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        #endregion
    }
}