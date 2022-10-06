using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace lesson4_exercice.Exceptions
{
    public class UserExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;

        public UserExceptionFilter(IHostEnvironment hostEnvironment) =>
            _hostEnvironment = hostEnvironment;

        public void OnException(ExceptionContext context)
        {
            if (!_hostEnvironment.IsDevelopment())
            {
                // Don't display exception details unless running in Development.
                return;
            }

            if (context.Exception is ArgumentOutOfRangeException)
            {
                context.Result = new ContentResult
                {
                    Content = context.Exception.ToString(),
                    StatusCode = StatusCodes.Status400BadRequest,
                };
                return;
            }
            else if (context.Exception is ArgumentException)
            {
                context.Result = new ContentResult
                {
                    Content = context.Exception.ToString(),
                    StatusCode = StatusCodes.Status400BadRequest,
                };
                return;
            }

            context.Result = new ContentResult
            {
                Content = context.Exception.ToString()
            };
        }
    }

}
