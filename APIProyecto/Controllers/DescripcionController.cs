using APIProyecto.Data;
using APIProyecto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescripcionController : ControllerBase
    {

        private readonly ApplicationDBContext _db; //cuando se pone guion bajo es porque es solo de lectura solo notacion

        public DescripcionController(ApplicationDBContext db)
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
                List<Descripcion> descripcion = await _db.sgc_Descripcion
                    .Include(f => f.Factura)
                    .Include(pct => pct.ProductoColorTalla)
                    .ToListAsync();

                return Ok(descripcion);
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
        [HttpGet("{IdDescripcion}")]
        public async Task<IActionResult> Get(int IdDescripcion)
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                Descripcion fact = await _db.sgc_Descripcion
                    .Include(pcl => pcl.Factura)
                    .Include(pct => pct.ProductoColorTalla) // Incluir la propiedad de navegación TipoProducto
                    .FirstOrDefaultAsync(x => x.IdDescripcion == IdDescripcion);

                if (fact == null)
                {
                    return BadRequest();
                }

                return Ok(fact);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }




        // POST api/<ColorProducto>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DescripcionDTO descripcionDTO)
        {
            Descripcion descripcion2 = await _db.sgc_Descripcion.FirstOrDefaultAsync(x => x.IdDescripcion==descripcionDTO.IdDescripcion);
            if (descripcion2==null && descripcionDTO!=null)
            {
                var Descripcion1 = new Descripcion
                {
                    Cantidad=descripcionDTO.Cantidad,
                    PrecioTotal=descripcionDTO.PrecioTotal,
                    Status=descripcionDTO.Status,
                    ProductoColorTallaIdProductoColorTalla=descripcionDTO.ProductoColorTallaIdProductoColorTalla,
                    FacturaIdFactura=descripcionDTO.FacturaIdFactura
                };
                await _db.sgc_Descripcion.AddAsync(Descripcion1);
                await _db.SaveChangesAsync();
                return Ok(Descripcion1);
            }
            return BadRequest("La descripcion ya existe");
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
        [HttpDelete("{IdDescripcion}")]
        public async Task<IActionResult> Delete(int IdDescripcion)
        {
            Descripcion prod = await _db.sgc_Descripcion.FirstOrDefaultAsync(x => x.IdDescripcion==IdDescripcion);
            if (prod != null)
            {
                _db.sgc_Descripcion.Remove(prod);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
