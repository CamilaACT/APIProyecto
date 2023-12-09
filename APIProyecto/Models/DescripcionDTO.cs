using System.ComponentModel.DataAnnotations;

namespace APIProyecto.Models
{
    public class DescripcionDTO
    {
        
        public int IdDescripcion { get; set; }
        public int Cantidad { get; set; }
        public double PrecioTotal { get; set; }
        public bool Status {get;set;}
        // Clave foránea para la relación uno a muchos con Cliente
        public int ProductoColorTallaIdProductoColorTalla { get; set; }
        // Clave foránea para la relación uno a muchos con Cliente
        public int FacturaIdFactura { get; set; }

    }
}
