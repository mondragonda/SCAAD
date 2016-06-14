using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SCAAD.APIs.Models
{
    public class Usuario : IdentityUser
    {

        [DefaultValue(true)]
        public bool Activo { get; set; }
        public string Docente_Id { get; set; }
        [ForeignKey("Docente_Id")]
        public virtual Docente  Docente { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}