using APIProyecto.Data;
using APIProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorProductoController : ControllerBase
    {
        //Esto se usa como modelo singelton
        private readonly ApplicationDBContext _db; //cuando se pone guion bajo es porque es solo de lectura solo notacion

        public ColorProductoController(ApplicationDBContext db)
        {
            _db=db;
        }
        // GET: api/<ColorProducto>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<ColorProducto> Tiposproductos = await _db.sgc_ColorProducto.ToListAsync();
                return Ok(Tiposproductos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // GET api/<ColorProducto>/5 //busca por ID
        [HttpGet("{dColorProducto}")]
        public async Task<IActionResult> Get(int IdColorProducto)
        {
            ColorProducto color = await _db.sgc_ColorProducto.FirstOrDefaultAsync(x => x.IdColorProducto==IdColorProducto);
            if (color == null)
            {
                return BadRequest();
            }
            return Ok(color);
        }
      



        // POST api/<ColorProducto>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ColorProducto color)
        {
            ColorProducto color2 = await _db.sgc_ColorProducto.FirstOrDefaultAsync(x => x.Nombre.Equals(color.Nombre));
            if (color2 == null && color!=null)
            {
                await _db.sgc_ColorProducto.AddAsync(color);
                await _db.SaveChangesAsync();
                return Ok(color);
            }
            return BadRequest("El color ya existe");
        }

        // PUT api/<ColorProducto>/5
        [HttpPut("{IdColorProducto}")]
        public async Task<IActionResult> Put(int IdColorProducto, [FromBody] ColorProducto color)
        {
            ColorProducto color2 = await _db.sgc_ColorProducto.FirstOrDefaultAsync(x => x.IdColorProducto==IdColorProducto);
            if (color2 != null)
            {
                color2.Nombre = color.Nombre != null ? color.Nombre : color2.Nombre;
                _db.sgc_ColorProducto.Update(color2);
                await _db.SaveChangesAsync();
                return Ok(color2);
            }
            return BadRequest("El producto a modificar no existe");
        }

        // DELETE api/<ColorProducto>/5
        [HttpDelete("{IdColorProducto}")]
        public async Task<IActionResult> Delete(int IdColorProducto)
        {
            ColorProducto color = await _db.sgc_ColorProducto.FirstOrDefaultAsync(x => x.IdColorProducto==IdColorProducto);
            if (color != null)
            {
                _db.sgc_ColorProducto.Remove(color);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
