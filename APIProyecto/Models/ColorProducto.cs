using System.ComponentModel.DataAnnotations;

namespace APIProyecto.Models
{
    public class ColorProducto
    {
        [Key]
        public int IdColorProducto { get; set; }
        [Required]
        public string Nombre { get; set; }

        // Propiedad de navegación para la relación uno a muchos con ProductoColorTalla
        public ICollection<ProductoColorTalla> ProductosColoresTallas { get; set; }

    }
}
