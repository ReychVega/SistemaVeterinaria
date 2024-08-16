using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVeterinaria.Models
{
    public class VacunacionFactory : CitaFactory
    {
        public override ICita CrearCita()
        {
            return new CitaVacunacion();
        }
    }
}