using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVeterinaria.Models
{
  
        public class CitaVacunacion : ICita
        {
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        public int ProgramarCita(DateTime dateTime, string Descripcion, String tipoCita,int idPet, int clienteId)
        {
            using (var db = new VeterinariaContext())
            {
                var cita = new Cita
                {
                    Fecha = dateTime,
                    Descripcion = Descripcion,
                    TipoCita = tipoCita,
                    ClienteId = clienteId,
                    AnimalId = idPet
                };

                db.Citas.Add(cita);
                db.SaveChanges();

                return cita.Id;
            }
        }
    }

    
}