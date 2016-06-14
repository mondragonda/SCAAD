using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using Autofac;
using Autofac.Integration.WebApi;

namespace SCAAD.APIs.Filters
{
    public class NotCatchedExceptionFilterAttribute : IAutofacExceptionFilter
    {
        public void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //throw new NotImplementedException();
        }
    }
}