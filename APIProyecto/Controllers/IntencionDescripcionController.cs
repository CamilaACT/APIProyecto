using APIProyecto.Data;
using APIProyecto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntencionDescripcionController : ControllerBase
    {

        //Esto se usa como modelo singelton
        private readonly ApplicationDBContext _db; //cuando se pone guion bajo es porque es solo de lectura solo notacion

        public IntencionDescripcionController(ApplicationDBContext db)
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
                List<IntencionDescripcion> intenciondescripciones = await _db.sgc_IntencionDescripcion
                    .Include(pcl => pcl.IntencionCompra)
                    .Include(pct => pct.ProductoColorTalla)
                    .ToListAsync();

                return Ok(intenciondescripciones);
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
        [HttpGet("{IdIntencionDescripcion}")]
        public async Task<IActionResult> Get(int IdIntencionDescripcion)
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                IntencionDescripcion intencionDescripcion = await _db.sgc_IntencionDescripcion
                    .Include(pcl => pcl.IntencionCompra)
                    .Include(pct => pct.ProductoColorTalla) // Incluir la propiedad de navegación TipoProducto
                    .FirstOrDefaultAsync(x => x.IdIntencionDescripcion == IdIntencionDescripcion);

                if (intencionDescripcion == null)
                {
                    return BadRequest();
                }

                return Ok(intencionDescripcion);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }





        // POST api/<ColorProducto>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IntencionDescripcionDTO IntencionDescripcionDTO)
        {
            double total= 0.0;
            IntencionDescripcion intencion2 = await _db.sgc_IntencionDescripcion.FirstOrDefaultAsync(x => x.IdIntencionDescripcion==IntencionDescripcionDTO.IdIntencionDescripcion);
            
            if (intencion2==null && IntencionDescripcionDTO!=null)
            {
                ProductoColorTalla prod = _db.sgc_ProductoColorTalla.FirstOrDefault(x => x.IdProductoColorTalla==IntencionDescripcionDTO.ProductoColorTallaIdProductoColorTalla);
                if (prod != null)
                {
                    var precio = prod.Precio;
                    total = precio*IntencionDescripcionDTO.Cantidad;
                }

                var Intenciondescripcion1 = new IntencionDescripcion
                {
                    Cantidad=IntencionDescripcionDTO.Cantidad,
                    PrecioTotal=total,
                    Status=true,
                    ProductoColorTallaIdProductoColorTalla=IntencionDescripcionDTO.ProductoColorTallaIdProductoColorTalla,
                    IntencionCompraIdIntencionCompra = IntencionDescripcionDTO.IntencionCompraIdIntencionCompra
                };
                await _db.sgc_IntencionDescripcion.AddAsync(Intenciondescripcion1);
                await _db.SaveChangesAsync();
                return Ok(Intenciondescripcion1);
            }
            return BadRequest("La intencion ya existe");
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
        [HttpDelete("{IdIntencionDescripcion}")]
        public async Task<IActionResult> Delete(int IdIntencionDescripcion)
        {
            IntencionDescripcion prod = await _db.sgc_IntencionDescripcion.FirstOrDefaultAsync(x => x.IdIntencionDescripcion==IdIntencionDescripcion);
            if (prod != null)
            {
                _db.sgc_IntencionDescripcion.Remove(prod);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }


        [HttpGet("PorCarrito/{IntencionCompraIdIntencionCompra}")]
        public async Task<IActionResult> GetListaProductosDelCarrito(int IntencionCompraIdIntencionCompra)
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                List<IntencionDescripcion> intenciondescripciones = await _db.sgc_IntencionDescripcion
                    .Include(pcl => pcl.IntencionCompra)
                    .Include(pct => pct.ProductoColorTalla)
                    .Where(x => x.IntencionCompraIdIntencionCompra == IntencionCompraIdIntencionCompra)
                    .ToListAsync();

                return Ok(intenciondescripciones);
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

        [HttpPost("GenerarDescripcionFactura/")]
        public async Task<IActionResult> PostComprarDescripcion([FromBody] SolicitudDescripcion solicitud)
        {
            List<IntencionDescripcion> intenciondescripciones = await _db.sgc_IntencionDescripcion
                    .Include(pcl => pcl.IntencionCompra)
                    .Include(pct => pct.ProductoColorTalla)
                    .Where(x => x.IntencionCompraIdIntencionCompra == solicitud.IntencionCompraIdIntencionCompra)
                    .ToListAsync();
            if(intenciondescripciones.Count > 0)
            {
                foreach(var intenciondescripcion in intenciondescripciones) 
                {
                    ProductoColorTalla producto = intenciondescripcion.ProductoColorTalla;
                    var stockactual = producto.Stock-intenciondescripcion.Cantidad;
                    intenciondescripcion.ProductoColorTalla.Stock=stockactual;
                    var descripcion = new Descripcion
                    {
                        Cantidad=intenciondescripcion.Cantidad,
                        PrecioTotal=intenciondescripcion.PrecioTotal,
                        Status=intenciondescripcion.Status,
                        ProductoColorTallaIdProductoColorTalla=intenciondescripcion.ProductoColorTallaIdProductoColorTalla,
                        FacturaIdFactura = solicitud.FacturaIdFactura
                    };
                    await _db.sgc_Descripcion.AddAsync(descripcion);
                    await _db.SaveChangesAsync();
                }
                return Ok();
            }

            return BadRequest("No existe la intencion de compra");
        }
    }
}
