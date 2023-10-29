using System.ComponentModel.DataAnnotations;

namespace APIProyecto.Models
{
    public class TipoProducto
    {
        [Key]
        public int IdTipoProducto { get; set; }

        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // Propiedad de navegación para la relación uno a muchos con Producto
        //public ICollection<Producto> Productos { get; set; }


    }
}
