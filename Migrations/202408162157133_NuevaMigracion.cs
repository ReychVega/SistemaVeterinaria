namespace SistemaVeterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevaMigracion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "UpdateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "UpdateDate", c => c.DateTime(nullable: false));
        }
    }
}
