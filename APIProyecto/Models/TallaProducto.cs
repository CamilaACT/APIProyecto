using System.ComponentModel.DataAnnotations;

namespace APIProyecto.Models
{
    public class TallaProducto
    {
        [Key]
        public int IdTallaProducto { get; set; }
        
        public string Talla { get; set; }

        // Propiedad de navegación para la relación uno a muchos con ProductoColorTalla
        //public ICollection<ProductoColorTalla> ProductosColoresTallas { get; set; }
    }
}
