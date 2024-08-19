// Definimos el namespace para las migraciones de la base de datos
namespace SistemaVeterinaria.Migrations
{
    // Importamos las librerías necesarias
    using System;
    using System.Data.Entity.Migrations;

    // Definimos una clase parcial para la migración namePet que hereda de DbMigration
    public partial class namePet : DbMigration
    {
        // Método que se ejecuta cuando se aplica la migración
        public override void Up()
        {
            // Agregamos una nueva columna "MascotaNombre" a la tabla "Citas"
            // La columna es de tipo string y no puede ser nula
            AddColumn("dbo.Citas", "MascotaNombre", c => c.String(nullable: false));
        }

        // Método que se ejecuta cuando se revierte la migración
        public override void Down()
        {
            // Eliminamos la columna "MascotaNombre" de la tabla "Citas"
            DropColumn("dbo.Citas", "MascotaNombre");
        }
    }
}

