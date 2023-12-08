using System.ComponentModel.DataAnnotations;

namespace APIProyecto.Models
{
    public class Descripcion
    {
        [Key]
        public int IdDescripcion { get; set; }
        public int Cantidad { get; set; }
        public float PrecioTotal { get; set; }
        public bool Status {get;set;}
        // Clave foránea para la relación uno a muchos con Cliente
        public int ProductoColorTallaIdProductoColorTalla { get; set; }
        public virtual ProductoColorTalla ProductoColorTalla { get; set; }
        // Clave foránea para la relación uno a muchos con Cliente
        public int FacturaIdFactura { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
