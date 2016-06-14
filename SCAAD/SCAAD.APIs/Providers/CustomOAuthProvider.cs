using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SCAAD.APIs.Data;
using SCAAD.APIs.Data.Implementations;
using SCAAD.APIs.Infrastructure;
using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SCAAD.APIs.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            Usuario user = await userManager.FindAsync(context.UserName, context.Password);
            


            if (user == null)
            {
                context.SetError("acceso inválido", "El usuario o la contraseña son incorrectos.");
                return;
            }

            if (user.Docente_Id == null)
            {
                
                context.SetError("DocenteInfoRequerido", "El usuario debera de llenar los campos de Docente correctos");
                return;
            }

            if (!user.Activo)
            {
                context.SetError("acceso inválido", "Usuario no Activo en el sistema. Comuniquese con Admin");
                return;
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");

            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);

        }
    }
}