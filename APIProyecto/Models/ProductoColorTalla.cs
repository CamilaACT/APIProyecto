using System.ComponentModel.DataAnnotations;

namespace APIProyecto.Models
{
    public class ProductoColorTalla
    {
        [Key]
        public int IdProductoColorTalla { get; set; }
       
        public int Stock {  get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public double Precio { get; set; }

        // Clave foránea para la relación uno a muchos con Producto
        public int ProductoIdProduto { get; set; }
        public Producto Producto { get; set; }

        // Clave foránea para la relación uno a muchos con Color
        public int ColorProductoIdColorProducto { get; set; }
        public ColorProducto ColorProducto { get; set; }

        // Clave foránea para la relación uno a muchos con Talla
        public int TallaProductoIdTallaProducto { get; set; }
        public TallaProducto TallaProducto { get; set; }


    }
}
