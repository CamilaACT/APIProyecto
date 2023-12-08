using System.ComponentModel.DataAnnotations;

namespace APIProyecto.Models
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        public string Fecha { get; set; }

        // Clave foránea para la relación uno a muchos con Cliente
        public int ClienteIdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

    }
}
