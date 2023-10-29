using APIProyecto.Data;
using APIProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        //Esto se usa como modelo singelton
        private readonly ApplicationDBContext _db; //cuando se pone guion bajo es porque es solo de lectura solo notacion

        public ProductoController(ApplicationDBContext db)
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
                List<Producto> productos = await _db.sgc_ProductoTab
                    .Include(p => p.TipoProducto)  // Incluir la propiedad de navegación TipoProducto
                    .ToListAsync();

                return Ok(productos);
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
        [HttpGet("{IdProduto}")]
        public async Task<IActionResult> Get(int IdProduto)
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                Producto tipo = await _db.sgc_ProductoTab
                    .Include(p => p.TipoProducto)  // Incluir la propiedad de navegación TipoProducto
                    .FirstOrDefaultAsync(x => x.IdProduto == IdProduto);

                if (tipo == null)
                {
                    return BadRequest();
                }

                return Ok(tipo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }




        // POST api/<ColorProducto>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoDTO productoDTO)
        {
            Producto proucto2 = await _db.sgc_ProductoTab.FirstOrDefaultAsync(x => x.Nombre.Equals(productoDTO.Nombre));
            if (proucto2 == null && productoDTO!=null)
            {
                var producto = new Producto
                {
                    Nombre = productoDTO.Nombre,
                    Descripcion = productoDTO.Descripcion,
                    TipoProductoIdTipoProducto=productoDTO.TipoProductoIdTipoProducto
                };
                await _db.sgc_ProductoTab.AddAsync(producto);
                await _db.SaveChangesAsync();
                return Ok(producto);
            }
            return BadRequest("El Producto ya existe");
        }

        // PUT api/<ColorProducto>/5
        [HttpPut("{IdProduto}")]
        public async Task<IActionResult> Put(int IdProduto, [FromBody] ProductoDTO productoDTO)
        {
            Producto actualaModificar = await _db.sgc_ProductoTab.FirstOrDefaultAsync(x => x.IdProduto==IdProduto);
            var nombrequeyatengo = actualaModificar.Nombre;
            Producto tallaquequieroponer = await _db.sgc_ProductoTab.FirstOrDefaultAsync(x => x.Nombre.Equals(productoDTO.Nombre));

            if ((tallaquequieroponer == null || tallaquequieroponer.Nombre.Equals(nombrequeyatengo)) && productoDTO != null)
            {
                actualaModificar.Nombre = productoDTO.Nombre != null ? productoDTO.Nombre : actualaModificar.Nombre;
                actualaModificar.Descripcion = productoDTO.Descripcion != null ? productoDTO.Descripcion : actualaModificar.Descripcion;
                _db.sgc_ProductoTab.Update(actualaModificar);
                await _db.SaveChangesAsync();
                return Ok(actualaModificar);
            }
            return BadRequest("El producto ya existe");
        }

        // DELETE api/<ColorProducto>/5
        [HttpDelete("{IdProduto}")]
        public async Task<IActionResult> Delete(int IdProduto)
        {
            Producto prod = await _db.sgc_ProductoTab.FirstOrDefaultAsync(x => x.IdProduto==IdProduto);
            if (prod != null)
            {
                _db.sgc_ProductoTab.Remove(prod);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
