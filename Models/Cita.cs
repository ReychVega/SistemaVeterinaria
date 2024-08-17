using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVeterinaria.Models
{
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string TipoCita { get; set; }
        [Required]
        public string DNI { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string MascotaNombre { get; set; }

    }
}
