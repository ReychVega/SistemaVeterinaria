using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace SistemaVeterinaria.Models
{
    public class CitaConsulta : ICita
    {
        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }
        public string TipoCita { get; set; }
        public string DNI { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string MascotaNombre { get; set; }

        public int ProgramarCita(
            string descripcion,
            string tipoCita,
            string dni,
            string primerApellido,
            string segundoApellido,
            string nombre,
            string email,
            string telefono,
            string mascotaNombre,
            DateTime fecha)
        {
            try
            {
                using (var db = new VeterinariaContext())
                {
                    if (string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(tipoCita) ||
                        string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(primerApellido) ||
                        string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) ||
                        string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(mascotaNombre))
                    {
                        throw new ArgumentException("Todos los parámetros deben estar llenos.");
                    }

                    var cita = new Cita
                    {
                        Fecha = fecha, // Fecha y hora se maneja aquí
                        Descripcion = descripcion,
                        TipoCita = tipoCita,
                        DNI = dni,
                        PrimerApellido = primerApellido,
                        SegundoApellido = segundoApellido,
                        Nombre = nombre,
                        Email = email,
                        Telefono = telefono,
                        MascotaNombre = mascotaNombre
                    };

                    db.Citas.Add(cita);
                    db.SaveChanges();

                    return cita.Id;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("No se pudo programar la cita.", ex);
            }
        }
    }
}