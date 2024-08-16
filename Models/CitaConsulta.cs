using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVeterinaria.Models
{
    public class CitaConsulta : ICita
    {

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }
        
        public void Programar()
        {

        }

    }
}