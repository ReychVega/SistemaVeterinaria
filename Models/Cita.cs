// Importamos las librerías necesarias para las anotaciones de datos y la generación de claves primarias
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVeterinaria.Models
{
    // Definimos la clase Cita que representa una cita en el sistema veterinario
    public class Cita
    {
        // Propiedad Id que actúa como clave primaria y se genera automáticamente
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Propiedad Descripcion que es obligatoria y muestra un mensaje de error si no se proporciona
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; }

        // Propiedad TipoCita que es obligatoria y muestra un mensaje de error si no se proporciona
        [Required(ErrorMessage = "El tipo de cita es obligatorio.")]
        public string TipoCita { get; set; }

        // Propiedad DNI que es obligatoria y muestra un mensaje de error si no se proporciona
        [Required(ErrorMessage = "El DNI es obligatorio.")]
        public string DNI { get; set; }

        // Propiedad PrimerApellido que es obligatoria y muestra un mensaje de error si no se proporciona
        [Required(ErrorMessage = "El primer apellido es obligatorio.")]
        public string PrimerApellido { get; set; }

        // Propiedad SegundoApellido que es opcional
        public string SegundoApellido { get; set; } // Opcional

        // Propiedad Nombre que es obligatoria y muestra un mensaje de error si no se proporciona
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        // Propiedad Email que es obligatoria, debe tener un formato válido y muestra un mensaje de error si no se proporciona o es inválido
        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido.")]
        public string Email { get; set; }

        // Propiedad Telefono que es obligatoria y muestra un mensaje de error si no se proporciona
        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string Telefono { get; set; }

        // Propiedad MascotaNombre que es obligatoria y muestra un mensaje de error si no se proporciona
        [Required(ErrorMessage = "El nombre de la mascota es obligatorio.")]
        public string MascotaNombre { get; set; }

        // Propiedad Fecha que es obligatoria, debe tener un formato de fecha y hora válido y muestra un mensaje de error si no se proporciona o es inválido
        [Required(ErrorMessage = "La fecha y hora son obligatorias.")]
        [DataType(DataType.DateTime, ErrorMessage = "La fecha y hora no son válidas.")]
        public DateTime Fecha { get; set; }
    }
}

