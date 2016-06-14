using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SCAAD.APIs.Data;
using SCAAD.APIs.Models;
using SCAAD.APIs.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Infrastructure
{
    public class ApplicationUserManager : UserManager<Usuario>
    {
        public ApplicationUserManager(IUserStore<Usuario> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<SCAAD_DbContext>();
            var appUserManager = new ApplicationUserManager(new UserStore<Usuario>(appDbContext));
            appUserManager.UserValidator = new MyCustomUserValidator(appUserManager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };
            return appUserManager;
        }
    }
}