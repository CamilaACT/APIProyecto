using APIProyecto.Data;
using APIProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoColorTallaController : ControllerBase
    {
        //Esto se usa como modelo singelton
        private readonly ApplicationDBContext _db; //cuando se pone guion bajo es porque es solo de lectura solo notacion

        public ProductoColorTallaController(ApplicationDBContext db)
        {
            _db=db;
        }
        // GET: api/<ColorProducto>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<ProductoColorTalla> TiposproductoscolorTalla = await _db.sgc_ProductoColorTalla
                    .Include(p => p.Producto)
                    .Include(p => p.TallaProducto)
                    .Include(p => p.ColorProducto)
                    .ToListAsync();
                return Ok(TiposproductoscolorTalla);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // GET api/<ColorProducto>/5 //busca por ID
        [HttpGet("{IdProductoColorTalla}")]
        public async Task<IActionResult> Get(int IdProductoColorTalla)
        {
            ProductoColorTalla productocolortalla = await _db.sgc_ProductoColorTalla
                .Include(p => p.Producto)
                .Include(p => p.TallaProducto)
                .Include(p => p.ColorProducto).FirstOrDefaultAsync(x => x.IdProductoColorTalla==IdProductoColorTalla);
            if (productocolortalla == null)
            {
                return BadRequest();
            }
            return Ok(productocolortalla);
        }
        [HttpGet("PorNombre/{ProductoNombre}")]
        public async Task<IActionResult> Get(string ProductoNombre)
        {
            List<ProductoColorTalla> productosColoresTallas = await _db.sgc_ProductoColorTalla
                .Include(p => p.Producto)
                .Include(p => p.TallaProducto)
                .Include(p => p.ColorProducto)
                .Where(x => x.Producto.Nombre == ProductoNombre)
                .ToListAsync();

            if (productosColoresTallas == null || productosColoresTallas.Count == 0)
            {
                return NotFound(); // NotFound si no se encuentran productos con ese nombre.
            }

            return Ok(productosColoresTallas);
        }

        [HttpGet("PorColor/{ColorProductoNombre}")]
        public async Task<IActionResult> GetColor(string ColorProductoNombre)
        {
            List<ProductoColorTalla> productosColoresTallas = await _db.sgc_ProductoColorTalla
                .Include(p => p.Producto)
                .Include(p => p.TallaProducto)
                .Include(p => p.ColorProducto)
                .Where(x => x.ColorProducto.Nombre == ColorProductoNombre)
                .ToListAsync();

            if (productosColoresTallas == null || productosColoresTallas.Count == 0)
            {
                return NotFound(); // NotFound si no se encuentran productos con ese nombre.
            }

            return Ok(productosColoresTallas);
        }

        [HttpGet("PorTalla/{TallaProductoTalla}")]
        public async Task<IActionResult> GetTalla(string TallaProductoTalla)
        {
            List<ProductoColorTalla> productosColoresTallas = await _db.sgc_ProductoColorTalla
                .Include(p => p.Producto)
                .Include(p => p.TallaProducto)
                .Include(p => p.ColorProducto)
                .Where(x => x.TallaProducto.Talla == TallaProductoTalla)
                .ToListAsync();

            if (productosColoresTallas == null || productosColoresTallas.Count == 0)
            {
                return NotFound(); // NotFound si no se encuentran productos con ese nombre.
            }

            return Ok(productosColoresTallas);
        }

        // POST api/<ColorProducto>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoColorTallaDTO productocolortallaDTO)
        {

            Producto producto = await _db.sgc_ProductoTab.FirstOrDefaultAsync(x => x.IdProduto == productocolortallaDTO.ProductoIdProduto);
            TallaProducto talla = await _db.sgc_TallaProducto.FirstOrDefaultAsync(x => x.IdTallaProducto == productocolortallaDTO.TallaProductoIdTallaProducto);
            ColorProducto color = await _db.sgc_ColorProducto.FirstOrDefaultAsync(x => x.IdColorProducto == productocolortallaDTO.ColorProductoIdColorProducto);

            ProductoColorTalla validacion = await _db.sgc_ProductoColorTalla.FirstOrDefaultAsync(x =>
                    x.Producto.Nombre.Equals(producto.Nombre) &&
                    x.TallaProducto.Talla.Equals(talla.Talla) &&
                    x.ColorProducto.Nombre.Equals(color.Nombre));

            if (validacion == null && productocolortallaDTO!=null)
            {
                var productotallacolor = new ProductoColorTalla
                {

                    ProductoIdProduto=productocolortallaDTO.ProductoIdProduto,
                    ColorProductoIdColorProducto=productocolortallaDTO.ColorProductoIdColorProducto,
                    TallaProductoIdTallaProducto=productocolortallaDTO.TallaProductoIdTallaProducto,

                    Stock=productocolortallaDTO.Stock,
                    StockMin=productocolortallaDTO.StockMin,
                    StockMax =productocolortallaDTO.StockMax,
                    Precio = productocolortallaDTO.Precio,
                };
                await _db.sgc_ProductoColorTalla.AddAsync(productotallacolor);
                await _db.SaveChangesAsync();
                return Ok(talla);
            }
            return BadRequest("El poducto unitario ya existe");
        }


        [HttpPut("{IdProductoColorTalla}")]
        public async Task<IActionResult> Put(int IdProductoColorTalla, [FromBody] ProductoColorTallaDTO productocolortallaDTO)
        {
            ProductoColorTalla actualaModificar = await _db.sgc_ProductoColorTalla.FirstOrDefaultAsync(x => x.IdProductoColorTalla==IdProductoColorTalla);
            //var colorqueyatengo = actualaModificar.Nombre;
            //ColorProducto colorquequieroponer = await _db.sgc_ColorProducto.FirstOrDefaultAsync(x => x.Nombre.Equals(colorDTO.Nombre));

            if (actualaModificar!=null && productocolortallaDTO != null)
            {
                actualaModificar.Stock = productocolortallaDTO.Stock != null ? productocolortallaDTO.Stock : actualaModificar.Stock;
                actualaModificar.StockMax = productocolortallaDTO.StockMax != null ? productocolortallaDTO.StockMax : actualaModificar.StockMax;
                actualaModificar.StockMin = productocolortallaDTO.StockMin != null ? productocolortallaDTO.StockMin : actualaModificar.StockMin;
                actualaModificar.Precio = productocolortallaDTO.Precio != null ? productocolortallaDTO.Precio : actualaModificar.Precio;
                _db.sgc_ProductoColorTalla.Update(actualaModificar);
                await _db.SaveChangesAsync();
                return Ok(actualaModificar);
            }
            return BadRequest("El color ya existe");
        }
        // DELETE api/<ColorProducto>/5
        [HttpDelete("{IdProductoColorTalla}")]
        public async Task<IActionResult> Delete(int IdProductoColorTalla)
        {
            ProductoColorTalla prod = await _db.sgc_ProductoColorTalla.FirstOrDefaultAsync(x => x.IdProductoColorTalla==IdProductoColorTalla);
            if (prod != null)
            {
                _db.sgc_ProductoColorTalla.Remove(prod);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

    }
}
