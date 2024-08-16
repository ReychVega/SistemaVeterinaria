using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace SistemaVeterinaria.Models
{
    public class VeterinariaContext : DbContext
    {
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Animal> Animales { get; set; }

        public VeterinariaContext() : base("name=VeterinariaContext")
        {
        }
    }
}
