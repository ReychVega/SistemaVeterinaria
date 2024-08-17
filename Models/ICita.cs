using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVeterinaria.Models
{
    public interface ICita
    {
        string Descripcion { get; set; }

        DateTime Fecha { get; set; }  

        int ProgramarCita(DateTime dateTime, string Descripcion, String tipoCita, int idPet, int clienteId);

    }
}