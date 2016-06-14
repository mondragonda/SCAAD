using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Models
{
    public class UserReturnModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool Activo { get; set; }
        public IList<string> Roles { get; set; }
        public IList<System.Security.Claims.Claim> Claims { get; set; }
        public string IdDocente { get; set; }
    }
}