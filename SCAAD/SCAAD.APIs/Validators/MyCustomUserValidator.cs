using Microsoft.AspNet.Identity;
using SCAAD.APIs.Infrastructure;
using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAAD.APIs.Validators
{
    public class MyCustomUserValidator : UserValidator<Usuario>
    {

        List<string> _allowedEmailDomains = new List<string> { Common.Constants.DominoCorreoUABC };

        public MyCustomUserValidator(ApplicationUserManager appUserManager)
            : base(appUserManager)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(Usuario user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            var emailDomain = user.Email.Split('@')[1];

            if (!_allowedEmailDomains.Contains(emailDomain.ToLower()))
            {
                var errors = result.Errors.ToList();

                errors.Add(String.Format("Email domain '{0}' is not allowed", emailDomain));

                result = new IdentityResult(errors);
            }

            return result;
        }
    }
}