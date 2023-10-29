using System.ComponentModel.DataAnnotations;

namespace APIProyecto.Models
{
    public class Producto
    {
        [Key]
        public int IdProduto { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // Clave foránea para la relación uno a muchos con TipoProducto
        public int TipoProductoIdTipoProducto { get; set; }
        public virtual TipoProducto TipoProducto { get; set; }

        // Propiedad de navegación para la relación uno a muchos con ProductoColorTalla
        public ICollection<ProductoColorTalla> ProductosColoresTallas { get; set; }
    }
}
