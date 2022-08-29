using System.Net;

namespace SdProject.Apis.Models
{
    public abstract class HttpResponse
    {
        #region Properties

        public HttpStatusCode Status { get; protected set; }

        #endregion
    }
}