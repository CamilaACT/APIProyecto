namespace APIProyecto.Models
{
    public class ProductoColorTallaDTO
    {
        public int IdProductoColorTalla { get; set; }
        public int ProductoIdProduto { get; set; }
        public int ColorProductoIdColorProducto { get; set; }
        public int TallaProductoIdTallaProducto { get; set; }

        public int Stock { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public double Precio { get; set; }
    }
}
