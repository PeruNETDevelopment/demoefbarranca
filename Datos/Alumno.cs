using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datos
{
    [Table("Alumno")]
    public class Alumno
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }

        public int Edad { get; set; }

        [StringLength(250)]
        public string Correo { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}