// Importamos las librerías necesarias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SistemaVeterinaria.Models
{
    // Definimos la clase VeterinariaContext que hereda de DbContext
    public class VeterinariaContext : DbContext
    {
        // Definimos una propiedad DbSet para la entidad Cita
        // Esto permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en la tabla Citas
        public DbSet<Cita> Citas { get; set; }

        // Constructor de la clase VeterinariaContext
        // Llama al constructor base de DbContext con el nombre de la cadena de conexión
        public VeterinariaContext() : base("name=VeterinariaContext")
        {
        }
    }
}




