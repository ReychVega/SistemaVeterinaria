// Importamos las librerías necesarias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace SistemaVeterinaria.Models
{
    // Definimos la clase CitaConsulta que implementa la interfaz ICita
    public class CitaConsulta : ICita
    {
        // Propiedad Fecha para almacenar la fecha y hora de la cita
        public DateTime Fecha { get; set; }

        // Propiedades para almacenar los detalles de la cita
        public string Descripcion { get; set; }
        public string TipoCita { get; set; }
        public string DNI { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string MascotaNombre { get; set; }

        // Método para programar una cita
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
                // Usamos un contexto de base de datos para interactuar con la base de datos
                using (var db = new VeterinariaContext())
                {
                    // Validamos que todos los parámetros obligatorios estén llenos
                    if (string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(tipoCita) ||
                        string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(primerApellido) ||
                        string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) ||
                        string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(mascotaNombre))
                    {
                        throw new ArgumentException("Todos los parámetros deben estar llenos.");
                    }

                    // Creamos una nueva instancia de Cita con los datos proporcionados
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

                    // Agregamos la nueva cita a la base de datos y guardamos los cambios
                    db.Citas.Add(cita);
                    db.SaveChanges();

                    // Retornamos el Id de la cita recién creada
                    return cita.Id;
                }
            }
            catch (Exception ex)
            {
                // En caso de error, lanzamos una excepción con un mensaje descriptivo
                throw new InvalidOperationException("No se pudo programar la cita.", ex);
            }
        }
    }
}


