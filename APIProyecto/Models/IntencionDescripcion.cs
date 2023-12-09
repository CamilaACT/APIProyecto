using System.ComponentModel.DataAnnotations;

namespace APIProyecto.Models
{
    public class IntencionDescripcion
    {
        [Key]
        public int IdIntencionDescripcion { get; set; }
        
        public int Cantidad { get; set; }
        public double PrecioTotal { get; set; }
        public bool Status {get;set;}
        // Clave foránea para la relación uno a muchos con Cliente
        public int ProductoColorTallaIdProductoColorTalla { get; set; }
        public virtual ProductoColorTalla ProductoColorTalla { get; set; }
        // Clave foránea para la relación uno a muchos con Cliente
        public int IntencionCompraIdIntencionCompra { get; set; }
        public virtual IntencionCompra IntencionCompra { get; set; }
    }
}
