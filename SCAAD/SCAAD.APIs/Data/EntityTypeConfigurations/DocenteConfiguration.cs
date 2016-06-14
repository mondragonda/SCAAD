using SCAAD.APIs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace SCAAD.APIs.Data.EntityTypeConfigurations
{
    public class DocenteConfiguration : EntityTypeConfiguration<Docente>
    {
        public DocenteConfiguration()
        {
            HasKey(d => d.Id);
            //HasRequired(d => d.Usuario);
        }
    }
}