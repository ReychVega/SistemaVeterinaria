// Definimos el namespace para las migraciones de la base de datos
namespace SistemaVeterinaria.Migrations
{
    // Importamos las librerías necesarias
    using System;
    using System.Data.Entity.Migrations;

    // Definimos una clase parcial para la migración VeterinariaDb que hereda de DbMigration
    public partial class VeterinariaDb : DbMigration
    {
        // Método que se ejecuta cuando se aplica la migración
        public override void Up()
        {
            // Creación de la tabla "Citas" en la base de datos
            CreateTable(
                "dbo.Citas",
                c => new
                {
                    // Definición de las columnas de la tabla "Citas"
                    Id = c.Int(nullable: false, identity: true), // Columna Id, clave primaria, autoincremental
                    Fecha = c.DateTime(nullable: false), // Columna Fecha, no nula
                    Descripcion = c.String(nullable: false), // Columna Descripcion, no nula
                    TipoCita = c.String(nullable: false), // Columna TipoCita, no nula
                    DNI = c.String(nullable: false), // Columna DNI, no nula
                    Nombre = c.String(nullable: false), // Columna Nombre, no nula
                    PrimerApellido = c.String(nullable: false), // Columna PrimerApellido, no nula
                    SegundoApellido = c.String(), // Columna SegundoApellido, puede ser nula
                    Email = c.String(nullable: false), // Columna Email, no nula
                    Telefono = c.String(nullable: false), // Columna Telefono, no nula
                })
                // Definimos la clave primaria de la tabla "Citas"
                .PrimaryKey(t => t.Id);
        }

        // Método que se ejecuta cuando se revierte la migración
        public override void Down()
        {
            // Eliminación de la tabla "Citas" en caso de revertir la migración
            DropTable("dbo.Citas");
        }
    }
}
