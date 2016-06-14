using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SCAAD.APIs.Models;
using System.Diagnostics;
using System.Data.Entity.ModelConfiguration.Conventions;
using SCAAD.APIs.Data.EntityTypeConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SCAAD.APIs.Data
{
    public class SCAAD_DbContext : IdentityDbContext<Usuario>
    {

        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<DiasNoHabiles> DiasNoHabiles { get; set; }
        public DbSet<PAAD> PAADs { get; set; }
        public DbSet<PAADModificado> PAADsModificados { get; set; }
        public DbSet<PAADActividad> PAADActividades { get; set; }
        public DbSet<PAADActividadModificada> PAADActividadesModificadas { get; set; }
        public DbSet<Evidencia> Evidencias { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<JustificacionPAAD> JustificacionesPAAD { get; set; }
        public DbSet<JustificacionPAADActividades> JustificacionesPAADActividad { get; set; }
        public DbSet<TiposCambio> TiposCambios { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<DescripcionCargo> DescripcionCargos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Rango> Rangos { get; set; }
        public DbSet<TiempoCargo> TiempoCargos { get; set; }
        public DbSet<TiposCargo> TiposCargos { get; set; }
        public DbSet<OpcionesCargo> OpcionesCargos { get; set; }
        public DbSet<VigenciaSNI> VigenciaSNIs { get; set; }
        public DbSet<SNI> SNIs { get; set; }
        public DbSet<EstadoModificacionActividad> EstadoModificacionActividades { get; set; }
        public DbSet<PAADEstatus> PAADEstatus { get; set; }
        public DbSet<ActividadEstatus> ActividadEstatus { get; set; }


        public SCAAD_DbContext() : base("SCAAD_DbContext", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;
            
            Database.Log = message => Debug.WriteLine(message);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new DocenteConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());



            base.OnModelCreating(modelBuilder);


        }


        public static SCAAD_DbContext Create()
        {
            return new SCAAD_DbContext();
        }
    }


}