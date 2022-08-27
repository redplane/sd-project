using System.Net;
using SdProject.Commons.Models.HttpResponses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SdProject.Commons.ExceptionFilters
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
                StatusCode = (int) HttpStatusCode.InternalServerError
            };
        }

        #endregion
    }
}