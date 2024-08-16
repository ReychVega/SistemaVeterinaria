using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVeterinaria.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public int ClienteID { get; set; }
        public string Especie { get; set; }
        public string HistorialClinico { get; set; }

        private static List<Animal> animales = new List<Animal>();

    }
}
