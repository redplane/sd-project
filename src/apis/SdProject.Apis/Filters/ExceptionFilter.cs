using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SdProject.Apis.Models;

namespace SdProject.Apis.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        #region Methods

        public virtual void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled)
                return;

            var httpFailureResponse = new BusinessExceptionResponse("internal_server_error", context.Exception.Message);
            context.Result = new ObjectResult(httpFailureResponse)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        #endregion
    }
}