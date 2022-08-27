using SdProject.Commons.Models.Exceptions;
using SdProject.Commons.Models.HttpResponses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SdProject.Commons.ExceptionFilters
{
    public class BusinessExceptionFilter : IExceptionFilter
    {
        #region Methods

        public virtual void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled)
                return;

            var exception = context.Exception;
            if (exception is not BusinessException businessException)
                return;

            var httpFailureResponse = new BusinessExceptionResponse(
                businessException.MessageCode, businessException.Message,
                businessException.StatusCode);
            httpFailureResponse.AdditionalData = businessException.AdditionalData;
            context.Result = new ObjectResult(httpFailureResponse)
            {
                StatusCode = (int) businessException.StatusCode
            };

            context.ExceptionHandled = true;
        }

        #endregion
    }
}