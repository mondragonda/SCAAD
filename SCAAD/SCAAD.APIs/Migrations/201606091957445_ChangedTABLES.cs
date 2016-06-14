namespace SCAAD.APIs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTABLES : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_PAADActividadModificada",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PAADActividadOriginal_Id = c.Int(nullable: false),
                        Categoria_id = c.Int(nullable: false),
                        Inicio = c.DateTime(nullable: false, storeType: "date"),
                        Finalizacion = c.DateTime(nullable: false, storeType: "date"),
                        Produccion = c.String(nullable: false, maxLength: 50),
                        CACEI_CIEES = c.Boolean(nullable: false),
                        CuerpoAcademico = c.Boolean(nullable: false),
                        ActividadEstatus_Id = c.Int(nullable: false),
                        MotivoModificacion = c.String()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tbl_ActividadEstatus", t => t.ActividadEstatus_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_Categorias", t => t.Categoria_id, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_PAADActividades", t => t.PAADActividadOriginal_Id)
                .Index(t => t.Categoria_id)
                .Index(t => t.ActividadEstatus_Id)
                .Index(t => t.PAADActividadOriginal_Id);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Tbl_PAADActividadModificada", "PAADActividadOriginal_Id1", "dbo.Tbl_PAADActividades");
            //DropForeignKey("dbo.Tbl_PAADActividadModificada", "Categoria_id", "dbo.Tbl_Categorias");
            //DropForeignKey("dbo.Tbl_PAADActividadModificada", "ActividadEstatus_Id", "dbo.Tbl_ActividadEstatus");
            //DropIndex("dbo.Tbl_PAADActividadModificada", new[] { "PAADActividadOriginal_Id1" });
            //DropIndex("dbo.Tbl_PAADActividadModificada", new[] { "ActividadEstatus_Id" });
            //DropIndex("dbo.Tbl_PAADActividadModificada", new[] { "Categoria_id" });
            //DropTable("dbo.Tbl_PAADActividadModificada");
        }
    }
}
