using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVeterinaria.Models
{
    public abstract class CitaFactory
    {
        public abstract ICita CrearCita();

    }

}