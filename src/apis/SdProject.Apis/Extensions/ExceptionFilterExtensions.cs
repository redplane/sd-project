﻿using SdProject.Commons.ExceptionFilters;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace SdProject.Commons.Extensions
{
    public static class ExceptionFilterExtensions
    {
        #region Methods

        public static FilterCollection AddApplicationExceptionFilters(this FilterCollection filters)
        {
            filters.Add<BusinessExceptionFilter>();
            filters.Add<ValidationExceptionFilter>();
            filters.Add<ExceptionFilter>();
            return filters;
        }
        
        #endregion
    }
}