using System.Net;

namespace SdProject.Commons.Models.HttpResponses
{
    public abstract class HttpResponse
    {
        #region Properties

        public HttpStatusCode Status { get; protected set; }

        #endregion
    }
}