namespace SistemaVeterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NombrePet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "Nombre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "Nombre");
        }
    }
}
