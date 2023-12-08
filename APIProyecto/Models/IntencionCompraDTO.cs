using System.ComponentModel.DataAnnotations;

namespace APIProyecto.Models
{
    public class IntencionCompraDTO
    {
        
        public int IdIntencionCompra { get; set; }
        public string Fecha { get; set; }

        // Clave foránea para la relación uno a muchos con Cliente
        public int ClienteIdCliente { get; set; }


    }
}
