using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVeterinaria.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }

        private static List<Cliente> clientes = new List<Cliente>();

    }
}