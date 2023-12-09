using System.ComponentModel.DataAnnotations;

namespace APIProyecto.Models
{
    public class IntencionDescripcionDTO
    {
        [Key]
        public int IdIntencionDescripcion { get; set; }
        public int Cantidad { get; set; }
        // Clave foránea para la relación uno a muchos con Cliente
        public int ProductoColorTallaIdProductoColorTalla { get; set; }
        // Clave foránea para la relación uno a muchos con Cliente
        public int IntencionCompraIdIntencionCompra { get; set; }

    }
}
