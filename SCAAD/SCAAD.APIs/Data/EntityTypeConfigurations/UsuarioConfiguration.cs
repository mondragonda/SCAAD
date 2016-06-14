using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Data.EntityTypeConfigurations
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            //HasOptional(u => u.Docente).WithOptionalPrincipal(d => d.Usuario);
        }

    }
}