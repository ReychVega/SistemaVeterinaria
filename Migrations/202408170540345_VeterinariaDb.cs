namespace SistemaVeterinaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VeterinariaDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(nullable: false),
                        TipoCita = c.String(nullable: false),
                        DNI = c.String(nullable: false),
                        Nombre = c.String(nullable: false),
                        PrimerApellido = c.String(nullable: false),
                        SegundoApellido = c.String(),
                        Email = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Citas");
        }
    }
}
