using APIProyecto.Data;
using APIProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntencionCompraController : ControllerBase
    {
        //Esto se usa como modelo singelton
        private readonly ApplicationDBContext _db; //cuando se pone guion bajo es porque es solo de lectura solo notacion

        public IntencionCompraController(ApplicationDBContext db)
        {
            _db=db;
        }
        // GET: api/<ColorProducto>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                List<IntencionCompra> intencioncompras = await _db.sgc_IntencionCompra
                    .Include(p => p.Cliente)  // Incluir la propiedad de navegación TipoProducto
                    .ToListAsync();

                return Ok(intencioncompras);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            //EL CODIGO EN SQL QUE QUIERO REPRESENTAR ES:
            /*SELECT P.IdProduto, TP.Nombre, P.Nombre, P.Descripcion 
                FROM sgc_ProductoTab P
                INNER JOIN sgc_TipoProducto TP ON P.TipoProductoIdTipoProducto = TP.IdTipoProducto*/

        }

        // GET api/<ColorProducto>/5 //busca por ID
        [HttpGet("{IdIntencionCompra}")]
        public async Task<IActionResult> Get(int IdIntencionCompra)
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                IntencionCompra intencionCompra = await _db.sgc_IntencionCompra
                    .Include(p => p.Cliente)  // Incluir la propiedad de navegación TipoProducto
                    .FirstOrDefaultAsync(x => x.IdIntencionCompra == IdIntencionCompra);

                if (intencionCompra == null)
                {
                    return BadRequest();
                }

                return Ok(intencionCompra);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }




        // POST api/<ColorProducto>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IntencionCompraDTO IntencionCompraDTO)
        {
            IntencionCompra intencion2 = await _db.sgc_IntencionCompra.FirstOrDefaultAsync(x => x.IdIntencionCompra== IntencionCompraDTO.IdIntencionCompra);
            if (intencion2==null && IntencionCompraDTO!=null)
            {
                var IntencionCompra1 = new IntencionCompra
                {
                    
                    ClienteIdCliente = IntencionCompraDTO.ClienteIdCliente,
                    Fecha=IntencionCompraDTO.Fecha,
                };
                await _db.sgc_IntencionCompra.AddAsync(IntencionCompra1);
                await _db.SaveChangesAsync();
                return Ok(IntencionCompra1);
            }
            return BadRequest("El código de intencion de compra ya existe");
        }

        //// PUT api/<ColorProducto>/5
        //[HttpPut("{IdProduto}")]
        //public async Task<IActionResult> Put(int IdProduto, [FromBody] ProductoDTO productoDTO)
        //{
        //    Producto actualaModificar = await _db.sgc_ProductoTab.FirstOrDefaultAsync(x => x.IdProduto==IdProduto);
        //    var nombrequeyatengo = actualaModificar.Nombre;
        //    Producto tallaquequieroponer = await _db.sgc_ProductoTab.FirstOrDefaultAsync(x => x.Nombre.Equals(productoDTO.Nombre));

        //    if ((tallaquequieroponer == null || tallaquequieroponer.Nombre.Equals(nombrequeyatengo)) && productoDTO != null)
        //    {
        //        actualaModificar.Nombre = productoDTO.Nombre != null ? productoDTO.Nombre : actualaModificar.Nombre;
        //        actualaModificar.Descripcion = productoDTO.Descripcion != null ? productoDTO.Descripcion : actualaModificar.Descripcion;
        //        _db.sgc_ProductoTab.Update(actualaModificar);
        //        await _db.SaveChangesAsync();
        //        return Ok(actualaModificar);
        //    }
        //    return BadRequest("El producto ya existe");
        //}

        // DELETE api/<ColorProducto>/5
        [HttpDelete("{IdIntencionCompra}")]
        public async Task<IActionResult> Delete(int IdIntencionCompra)
        {
            IntencionCompra prod = await _db.sgc_IntencionCompra.FirstOrDefaultAsync(x => x.IdIntencionCompra==IdIntencionCompra);
            if (prod != null)
            {
                _db.sgc_IntencionCompra.Remove(prod);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        //METODOS FUNCIONALIDAD DE LA APP
        // GET: api/<ColorProducto>
        [HttpGet("PorCliente/{ClienteIdCliente}")]
        public async Task<IActionResult> GetListaIntencionCompra(int ClienteIdCliente)
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                List<IntencionCompra> intencioncompras = await _db.sgc_IntencionCompra
                    .Include(p => p.Cliente)  // Incluir la propiedad de navegación TipoProducto
                    .Where(x => x.ClienteIdCliente == ClienteIdCliente)
                    .ToListAsync();

                if (intencioncompras == null || intencioncompras.Count == 0)
                {
                    return NotFound(); // Cambiado a NotFound cuando no se encuentran resultados
                }

                return Ok(intencioncompras);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            //EL CODIGO EN SQL QUE QUIERO REPRESENTAR ES:
            /*SELECT P.IdProduto, TP.Nombre, P.Nombre, P.Descripcion 
                FROM sgc_ProductoTab P
                INNER JOIN sgc_TipoProducto TP ON P.TipoProductoIdTipoProducto = TP.IdTipoProducto*/

        }

        // POST api/<ColorProducto>
        [HttpPost("GenerarCompraFactura/")]
        public async Task<IActionResult> PostComprar([FromBody] int IntencionCompraIdIntencionCompra)
        {
            IntencionCompra intencion2 = await _db.sgc_IntencionCompra.FirstOrDefaultAsync(x => x.IdIntencionCompra== IntencionCompraIdIntencionCompra);
            if (intencion2!=null)
            {
                var Factura = new Factura
                {
                    Fecha=intencion2.Fecha,
                    ClienteIdCliente=intencion2.ClienteIdCliente,
                    
                };
                await _db.sgc_Factura.AddAsync(Factura);
                await _db.SaveChangesAsync();
                return Ok(Factura);

            }

            return BadRequest("No existe la intencion de compra");
        }

        [HttpGet("TotalIntencionCompra/{IntencionCompraIdIntencionCompra}")]
        public async Task<IActionResult> GetTotalCarrito(int IntencionCompraIdIntencionCompra)
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                List<IntencionDescripcion> descripciones = await _db.sgc_IntencionDescripcion
                    .Include(pcl => pcl.IntencionCompra)
                    .Include(pct => pct.ProductoColorTalla)
                    .Where(x => x.IntencionCompraIdIntencionCompra == IntencionCompraIdIntencionCompra)
                    .ToListAsync();
                if (descripciones.Count!=0 || descripciones != null)
                {
                    double totalPrecioCarrito = 0.0;

                    foreach (var descripcion in descripciones)
                    {

                        totalPrecioCarrito += descripcion.PrecioTotal;
                    }


                    return Ok(totalPrecioCarrito);

                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            //EL CODIGO EN SQL QUE QUIERO REPRESENTAR ES:
            /*SELECT P.IdProduto, TP.Nombre, P.Nombre, P.Descripcion 
                FROM sgc_ProductoTab P
                INNER JOIN sgc_TipoProducto TP ON P.TipoProductoIdTipoProducto = TP.IdTipoProducto*/

        }

    }
}
