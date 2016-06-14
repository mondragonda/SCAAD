using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SCAAD.APIs.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using SCAAD.APIs.App_Start;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(SCAAD.APIs.Startup))]

namespace SCAAD.APIs
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutofacConfig.ConfigureContainer(app);
            AutoMapperConfig.ConfigureMapper(); 

          
        }
    }
}



