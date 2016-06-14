namespace SCAAD.APIs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TABLASActividades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_PAADActividades", "Cancelada", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.Tbl_PAADActividades", "Cancelada");
        }
    }
}
