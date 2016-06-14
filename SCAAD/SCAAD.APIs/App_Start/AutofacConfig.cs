using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SCAAD.APIs.Controllers;
using SCAAD.APIs.Data;
using SCAAD.APIs.Filters;
using SCAAD.APIs.Infrastructure;
using SCAAD.APIs.Logic;
using SCAAD.APIs.Modules;
using SCAAD.APIs.Providers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Cors;

namespace SCAAD.APIs.App_Start
{
    public class AutofacConfig
    {
        private static CorsOptions AllowAll;

        public static IContainer Container { get; set; }

        public static void ConfigureContainer(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            //var config = new HttpConfiguration();

            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterType<NotCatchedExceptionFilterAttribute>().AsWebApiExceptionFilterFor<CustomBaseController>().InstancePerRequest();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new DataModule());
            builder.RegisterModule(new LogicModule());
            builder.RegisterModule(new BusinessRulesModule());
            builder.RegisterModule(new Log4NetModule());
            builder.RegisterModule(new ControllerModule());
            

            Container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);

            ConfigureOAuthTokenConsumption(app);
            ConfigureOAuthTokenGeneration(app);

            WebApiConfig.Register(config);
            app.UseAutofacMiddleware(Container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
            

        }




        public static void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            app.CreatePerOwinContext(SCAAD_DbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);



            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat("http://localhost:55460")
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
        }


        private static void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {

            var issuer = "http://localhost:55460";
            string audienceId = ConfigurationManager.AppSettings["AudienceId"];
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["AudienceSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                    }
                });
        }
    }
}