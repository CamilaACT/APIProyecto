using APIProyecto.Data;
using APIProyecto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly ApplicationDBContext _db; //cuando se pone guion bajo es porque es solo de lectura solo notacion

        public FacturaController(ApplicationDBContext db)
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
                List<Factura> intencioncompras = await _db.sgc_Factura
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
        [HttpGet("{IdFactura}")]
        public async Task<IActionResult> Get(int IdFactura)
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                Factura factura = await _db.sgc_Factura
                    .Include(p => p.Cliente)  // Incluir la propiedad de navegación TipoProducto
                    .FirstOrDefaultAsync(x => x.IdFactura == IdFactura);

                if (factura == null)
                {
                    return BadRequest();
                }

                return Ok(factura);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }




        // POST api/<ColorProducto>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FacturaDTO FacturaDTO)
        {
            Factura factura2 = await _db.sgc_Factura.FirstOrDefaultAsync(x => x.IdFactura== FacturaDTO.IdFactura);
            if (factura2==null && FacturaDTO!=null)
            {
                var Factura = new Factura
                {

                    ClienteIdCliente = FacturaDTO.ClienteIdCliente,
                    Fecha=FacturaDTO.Fecha,
                };
                await _db.sgc_Factura.AddAsync(Factura);
                await _db.SaveChangesAsync();
                return Ok(Factura);
            }
            return BadRequest("El código de factura de compra ya existe");
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
        [HttpDelete("{IdFactura}")]
        public async Task<IActionResult> Delete(int IdFactura)
        {
            Factura prod = await _db.sgc_Factura.FirstOrDefaultAsync(x => x.IdFactura==IdFactura);
            if (prod != null)
            {
                _db.sgc_Factura.Remove(prod);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
