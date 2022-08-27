using System.Linq;
using System.Net;
using SdProject.Commons.Models.HttpResponses;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SdProject.Commons.ExceptionFilters
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        #region Methods

        public virtual void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled)
                return;

            if (context.Exception is not ValidationException validationException)
                return;

            var messages = validationException.Errors.Select(x => x.ErrorMessage).ToArray();
            var badRequestResponse = new BadRequestResponse(messages);
            context.Result = new ObjectResult(badRequestResponse)
            {
                StatusCode = (int) HttpStatusCode.BadRequest
            };
            context.ExceptionHandled = true;
        }

        #endregion
    }
}