// Importamos las librerías necesarias
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaVeterinaria.Models
{
    // Definimos la interfaz ICita que establece el contrato para las clases que la implementen
    public interface ICita
    {
        // Propiedades que deben ser implementadas por las clases que implementen esta interfaz
        string Descripcion { get; set; }
        string TipoCita { get; set; }
        string DNI { get; set; }
        string PrimerApellido { get; set; }
        string SegundoApellido { get; set; }
        string Nombre { get; set; }
        string Email { get; set; }
        string Telefono { get; set; }
        string MascotaNombre { get; set; }
        DateTime Fecha { get; set; }

        // Método que debe ser implementado por las clases que implementen esta interfaz
        // Este método se utiliza para programar una cita con los detalles proporcionados
        int ProgramarCita(
            string descripcion,
            string tipoCita,
            string dni,
            string primerApellido,
            string segundoApellido,
            string nombre,
            string email,
            string telefono,
            string mascotaNombre,
            DateTime fecha);
    }
}



