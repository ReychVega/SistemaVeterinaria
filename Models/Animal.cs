using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaVeterinaria.Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string HistorialClinico { get; set; }

        private static List<Animal> animales = new List<Animal>();

    }
}
