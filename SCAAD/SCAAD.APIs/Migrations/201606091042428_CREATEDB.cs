namespace SCAAD.APIs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CREATEDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_ActividadEstatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_Cargos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_DescripcionesCargo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cargo_Id = c.Int(nullable: false),
                        Rango_Id = c.Int(nullable: false),
                        TiempoCargo_Id = c.Int(nullable: false),
                        TipoCargo_Id = c.Int(nullable: false),
                        OpcionesCargo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Cargos", t => t.Cargo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_OpcionesCargo", t => t.OpcionesCargo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_Rangos", t => t.Rango_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_TiempoCargo", t => t.TiempoCargo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_TiposCargo", t => t.TipoCargo_Id, cascadeDelete: true)
                .Index(t => t.Cargo_Id)
                .Index(t => t.Rango_Id)
                .Index(t => t.TiempoCargo_Id)
                .Index(t => t.TipoCargo_Id)
                .Index(t => t.OpcionesCargo_Id);
            
            CreateTable(
                "dbo.Tbl_OpcionesCargo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_PAADs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Docente_Id = c.String(maxLength: 128),
                        Periodo_Id = c.Int(nullable: false),
                        DescripcionesCargo_Id = c.Int(nullable: false),
                        VigenciaSNI_Id = c.Int(nullable: false),
                        VigenciaPRODEP = c.DateTime(storeType: "date"),
                        HorasLicenciaturas = c.Int(nullable: false),
                        HorasClase = c.Int(nullable: false),
                        HorasPosgrado = c.Int(nullable: false),
                        HorasGestion = c.Int(nullable: false),
                        HorasInvestigacion = c.Int(nullable: false),
                        HorasTutorias = c.Int(nullable: false),
                        PAADEstatus_Id = c.Int(nullable: false),
                        NombreActividadGestion = c.String(nullable: false),
                        Completado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_DescripcionesCargo", t => t.DescripcionesCargo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_Docentes", t => t.Docente_Id)
                .ForeignKey("dbo.Tbl_PAADEstatus", t => t.PAADEstatus_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_Periodos", t => t.Periodo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_VigenciasSNI", t => t.VigenciaSNI_Id, cascadeDelete: true)
                .Index(t => t.Docente_Id)
                .Index(t => t.Periodo_Id)
                .Index(t => t.DescripcionesCargo_Id)
                .Index(t => t.VigenciaSNI_Id)
                .Index(t => t.PAADEstatus_Id);
            
            CreateTable(
                "dbo.Tbl_Docentes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NumeroEmplado = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Apellido = c.String(nullable: false, maxLength: 100),
                        Carrera_Id = c.Int(nullable: false),
                        InformacionActualizada = c.Boolean(nullable: false),
                        idUsuario = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Carrera", t => t.Carrera_Id, cascadeDelete: true)
                .Index(t => t.Carrera_Id);
            
            CreateTable(
                "dbo.Tbl_Carrera",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_JustificacionesPAAD",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PAAD_Id = c.Int(nullable: false),
                        TipoCambio_Id = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        Aprobado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_PAADs", t => t.PAAD_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_TiposCambio", t => t.TipoCambio_Id, cascadeDelete: true)
                .Index(t => t.PAAD_Id)
                .Index(t => t.TipoCambio_Id);
            
            CreateTable(
                "dbo.Tbl_TiposCambio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_JustificacionesPAADActividades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PAADActividad_Id = c.Int(nullable: false),
                        TipoCambio_Id = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        Aprobado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_PAADActividades", t => t.PAADActividad_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_TiposCambio", t => t.TipoCambio_Id, cascadeDelete: true)
                .Index(t => t.PAADActividad_Id)
                .Index(t => t.TipoCambio_Id);
            
            CreateTable(
                "dbo.Tbl_PAADActividades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PAAD_Id = c.Int(nullable: false),
                        Categoria_id = c.Int(nullable: false),
                        Inicio = c.DateTime(nullable: false, storeType: "date"),
                        Finalizacion = c.DateTime(nullable: false, storeType: "date"),
                        Produccion = c.String(nullable: false, maxLength: 50),
                        CACEI_CIEES = c.Boolean(nullable: false),
                        CuerpoAcademico = c.Boolean(nullable: false),
                        PorcentajeAvance = c.Int(nullable: false),
                        ActividadEstatus_Id = c.Int(nullable: false),
                        Completada = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_ActividadEstatus", t => t.ActividadEstatus_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_Categorias", t => t.Categoria_id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_PAADs", t => t.PAAD_Id, cascadeDelete: true)
                .Index(t => t.PAAD_Id)
                .Index(t => t.Categoria_id)
                .Index(t => t.ActividadEstatus_Id);
            
            CreateTable(
                "dbo.Tbl_Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_Evidencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PAADActividad_Id = c.Int(nullable: false),
                        Descripcion = c.String(),
                        RutaDocumento = c.String(nullable: false),
                        FechaAgregado = c.DateTime(nullable: false, storeType: "date"),
                        PorcentajeEvaluacion = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_PAADActividades", t => t.PAADActividad_Id, cascadeDelete: true)
                .Index(t => t.PAADActividad_Id);
            
            CreateTable(
                "dbo.Tbl_PAADEstatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_Periodos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ciclo = c.String(nullable: false),
                        FechaInicio = c.DateTime(nullable: false, storeType: "date"),
                        FechaFin = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_DiasNoHabiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                        Motivo = c.String(maxLength: 50),
                        Periodo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Periodos", t => t.Periodo_Id, cascadeDelete: true)
                .Index(t => t.Periodo_Id);
            
            CreateTable(
                "dbo.Tbl_VigenciasSNI",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                        SNI_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_SNIs", t => t.SNI_Id, cascadeDelete: true)
                .Index(t => t.SNI_Id);
            
            CreateTable(
                "dbo.Tbl_SNIs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nivel = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_Rangos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_TiempoCargo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_TiposCargo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_EstadoModificacionActividad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tbl_PAADModificado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PAADOriginal_Id = c.Int(nullable: false),
                        Docente_Id = c.String(nullable: false, maxLength: 128),
                        Periodo_Id = c.Int(nullable: false),
                        DescripcionCargo_Id = c.Int(nullable: false),
                        VigenciaSNI_Id = c.Int(nullable: false),
                        VigenciaPRODEP = c.DateTime(nullable: false),
                        HorasLicenciatura = c.Int(nullable: false),
                        HorasClase = c.Int(nullable: false),
                        HorasPosgrado = c.Int(nullable: false),
                        HorasGestion = c.Int(nullable: false),
                        HorasInvestigacion = c.Int(nullable: false),
                        HorasTutorias = c.Int(nullable: false),
                        PAADEstatus_Id = c.Int(nullable: false),
                        NombreActividadGestion = c.String(nullable: false),
                        MotivoModificacion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_DescripcionesCargo", t => t.DescripcionCargo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_Docentes", t => t.Docente_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_PAADEstatus", t => t.PAADEstatus_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_PAADs", t => t.PAADOriginal_Id, cascadeDelete: false)
                .ForeignKey("dbo.Tbl_Periodos", t => t.Periodo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_VigenciasSNI", t => t.VigenciaSNI_Id, cascadeDelete: true)
                .Index(t => t.PAADOriginal_Id)
                .Index(t => t.Docente_Id)
                .Index(t => t.Periodo_Id)
                .Index(t => t.DescripcionCargo_Id)
                .Index(t => t.VigenciaSNI_Id)
                .Index(t => t.PAADEstatus_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Activo = c.Boolean(nullable: false),
                        Docente_Id = c.String(maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_Docentes", t => t.Docente_Id)
                .Index(t => t.Docente_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Docente_Id", "dbo.Tbl_Docentes");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Tbl_PAADModificado", "VigenciaSNI_Id", "dbo.Tbl_VigenciasSNI");
            DropForeignKey("dbo.Tbl_PAADModificado", "Periodo_Id", "dbo.Tbl_Periodos");
            DropForeignKey("dbo.Tbl_PAADModificado", "PAADOriginal_Id", "dbo.Tbl_PAADs");
            DropForeignKey("dbo.Tbl_PAADModificado", "PAADEstatus_Id", "dbo.Tbl_PAADEstatus");
            DropForeignKey("dbo.Tbl_PAADModificado", "Docente_Id", "dbo.Tbl_Docentes");
            DropForeignKey("dbo.Tbl_PAADModificado", "DescripcionCargo_Id", "dbo.Tbl_DescripcionesCargo");
            DropForeignKey("dbo.Tbl_DescripcionesCargo", "TipoCargo_Id", "dbo.Tbl_TiposCargo");
            DropForeignKey("dbo.Tbl_DescripcionesCargo", "TiempoCargo_Id", "dbo.Tbl_TiempoCargo");
            DropForeignKey("dbo.Tbl_DescripcionesCargo", "Rango_Id", "dbo.Tbl_Rangos");
            DropForeignKey("dbo.Tbl_VigenciasSNI", "SNI_Id", "dbo.Tbl_SNIs");
            DropForeignKey("dbo.Tbl_PAADs", "VigenciaSNI_Id", "dbo.Tbl_VigenciasSNI");
            DropForeignKey("dbo.Tbl_PAADs", "Periodo_Id", "dbo.Tbl_Periodos");
            DropForeignKey("dbo.Tbl_DiasNoHabiles", "Periodo_Id", "dbo.Tbl_Periodos");
            DropForeignKey("dbo.Tbl_PAADs", "PAADEstatus_Id", "dbo.Tbl_PAADEstatus");
            DropForeignKey("dbo.Tbl_JustificacionesPAADActividades", "TipoCambio_Id", "dbo.Tbl_TiposCambio");
            DropForeignKey("dbo.Tbl_PAADActividades", "PAAD_Id", "dbo.Tbl_PAADs");
            DropForeignKey("dbo.Tbl_JustificacionesPAADActividades", "PAADActividad_Id", "dbo.Tbl_PAADActividades");
            DropForeignKey("dbo.Tbl_Evidencias", "PAADActividad_Id", "dbo.Tbl_PAADActividades");
            DropForeignKey("dbo.Tbl_PAADActividades", "Categoria_id", "dbo.Tbl_Categorias");
            DropForeignKey("dbo.Tbl_PAADActividades", "ActividadEstatus_Id", "dbo.Tbl_ActividadEstatus");
            DropForeignKey("dbo.Tbl_JustificacionesPAAD", "TipoCambio_Id", "dbo.Tbl_TiposCambio");
            DropForeignKey("dbo.Tbl_JustificacionesPAAD", "PAAD_Id", "dbo.Tbl_PAADs");
            DropForeignKey("dbo.Tbl_PAADs", "Docente_Id", "dbo.Tbl_Docentes");
            DropForeignKey("dbo.Tbl_Docentes", "Carrera_Id", "dbo.Tbl_Carrera");
            DropForeignKey("dbo.Tbl_PAADs", "DescripcionesCargo_Id", "dbo.Tbl_DescripcionesCargo");
            DropForeignKey("dbo.Tbl_DescripcionesCargo", "OpcionesCargo_Id", "dbo.Tbl_OpcionesCargo");
            DropForeignKey("dbo.Tbl_DescripcionesCargo", "Cargo_Id", "dbo.Tbl_Cargos");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "Docente_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Tbl_PAADModificado", new[] { "PAADEstatus_Id" });
            DropIndex("dbo.Tbl_PAADModificado", new[] { "VigenciaSNI_Id" });
            DropIndex("dbo.Tbl_PAADModificado", new[] { "DescripcionCargo_Id" });
            DropIndex("dbo.Tbl_PAADModificado", new[] { "Periodo_Id" });
            DropIndex("dbo.Tbl_PAADModificado", new[] { "Docente_Id" });
            DropIndex("dbo.Tbl_PAADModificado", new[] { "PAADOriginal_Id" });
            DropIndex("dbo.Tbl_VigenciasSNI", new[] { "SNI_Id" });
            DropIndex("dbo.Tbl_DiasNoHabiles", new[] { "Periodo_Id" });
            DropIndex("dbo.Tbl_Evidencias", new[] { "PAADActividad_Id" });
            DropIndex("dbo.Tbl_PAADActividades", new[] { "ActividadEstatus_Id" });
            DropIndex("dbo.Tbl_PAADActividades", new[] { "Categoria_id" });
            DropIndex("dbo.Tbl_PAADActividades", new[] { "PAAD_Id" });
            DropIndex("dbo.Tbl_JustificacionesPAADActividades", new[] { "TipoCambio_Id" });
            DropIndex("dbo.Tbl_JustificacionesPAADActividades", new[] { "PAADActividad_Id" });
            DropIndex("dbo.Tbl_JustificacionesPAAD", new[] { "TipoCambio_Id" });
            DropIndex("dbo.Tbl_JustificacionesPAAD", new[] { "PAAD_Id" });
            DropIndex("dbo.Tbl_Docentes", new[] { "Carrera_Id" });
            DropIndex("dbo.Tbl_PAADs", new[] { "PAADEstatus_Id" });
            DropIndex("dbo.Tbl_PAADs", new[] { "VigenciaSNI_Id" });
            DropIndex("dbo.Tbl_PAADs", new[] { "DescripcionesCargo_Id" });
            DropIndex("dbo.Tbl_PAADs", new[] { "Periodo_Id" });
            DropIndex("dbo.Tbl_PAADs", new[] { "Docente_Id" });
            DropIndex("dbo.Tbl_DescripcionesCargo", new[] { "OpcionesCargo_Id" });
            DropIndex("dbo.Tbl_DescripcionesCargo", new[] { "TipoCargo_Id" });
            DropIndex("dbo.Tbl_DescripcionesCargo", new[] { "TiempoCargo_Id" });
            DropIndex("dbo.Tbl_DescripcionesCargo", new[] { "Rango_Id" });
            DropIndex("dbo.Tbl_DescripcionesCargo", new[] { "Cargo_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tbl_PAADModificado");
            DropTable("dbo.Tbl_EstadoModificacionActividad");
            DropTable("dbo.Tbl_TiposCargo");
            DropTable("dbo.Tbl_TiempoCargo");
            DropTable("dbo.Tbl_Rangos");
            DropTable("dbo.Tbl_SNIs");
            DropTable("dbo.Tbl_VigenciasSNI");
            DropTable("dbo.Tbl_DiasNoHabiles");
            DropTable("dbo.Tbl_Periodos");
            DropTable("dbo.Tbl_PAADEstatus");
            DropTable("dbo.Tbl_Evidencias");
            DropTable("dbo.Tbl_Categorias");
            DropTable("dbo.Tbl_PAADActividades");
            DropTable("dbo.Tbl_JustificacionesPAADActividades");
            DropTable("dbo.Tbl_TiposCambio");
            DropTable("dbo.Tbl_JustificacionesPAAD");
            DropTable("dbo.Tbl_Carrera");
            DropTable("dbo.Tbl_Docentes");
            DropTable("dbo.Tbl_PAADs");
            DropTable("dbo.Tbl_OpcionesCargo");
            DropTable("dbo.Tbl_DescripcionesCargo");
            DropTable("dbo.Tbl_Cargos");
            DropTable("dbo.Tbl_ActividadEstatus");
        }
    }
}
