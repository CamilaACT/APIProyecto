using System.ComponentModel.DataAnnotations;

namespace APIProyecto.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "La Cedula es un campo obligatorio.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El Nombre es un campo obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es un campo obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Login es un campo obligatorio.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Contrasenia es un campo obligatorio.")]
        public string Contrasenia { get; set; }

        [Required(ErrorMessage = "El Número de Seguridad es un campo obligatorio.")]
        public int NumeroSeguridad { get; set; }
    }
}
