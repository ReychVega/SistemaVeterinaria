namespace SistemaVeterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namePet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Citas", "MascotaNombre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Citas", "MascotaNombre");
        }
    }
}
