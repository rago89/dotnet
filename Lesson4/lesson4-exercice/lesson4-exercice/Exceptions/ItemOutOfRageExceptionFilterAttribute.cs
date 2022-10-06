﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace lesson4_exercice.Exceptions
{
    public class ItemOutOfRageExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ArgumentOutOfRangeException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
    
}
