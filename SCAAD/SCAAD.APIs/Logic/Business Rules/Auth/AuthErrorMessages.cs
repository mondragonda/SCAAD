using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAAD.APIs.Logic.Business_Rules.Auth
{
    public static class IdentityAuthErrorMessages
    {
        public static string GetAppendedIdentityResultErrors(IdentityResult identityResult)
        {
            var stringBuilder = new StringBuilder();

            foreach(var error in identityResult.Errors)
            {
                stringBuilder.AppendLine(error);
            }

            return stringBuilder.ToString();
        }
    }
}
