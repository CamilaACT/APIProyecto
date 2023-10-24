using APIProyecto.Data;
using APIProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallaProductoController : ControllerBase
    {
        //Esto se usa como modelo singelton
        private readonly ApplicationDBContext _db; //cuando se pone guion bajo es porque es solo de lectura solo notacion

        public TallaProductoController(ApplicationDBContext db)
        {
            _db=db;
        }
        // GET: api/<TallaProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<TallaProducto> Tiposproductos = await _db.sgc_TallaProducto.ToListAsync();
            return Ok(Tiposproductos);
        }

        // GET api/<TallaProductoController>/5
        [HttpGet("{IdTallaProducto}")]
        public async Task<IActionResult> Get(int IdTallaProducto)
        {
            TallaProducto tipo = await _db.sgc_TallaProducto.FirstOrDefaultAsync(x => x.IdTallaProducto==IdTallaProducto);
            if (tipo == null)
            {
                return BadRequest();
            }
            return Ok(tipo);
        }

        // POST api/<TallaProductoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TallaProducto talla)
        {
            TallaProducto talla2 = await _db.sgc_TallaProducto.FirstOrDefaultAsync(x => x.IdTallaProducto==talla.IdTallaProducto);
            if (talla2 == null && talla!=null)
            {
                await _db.sgc_TallaProducto.AddAsync(talla);
                await _db.SaveChangesAsync();
                return Ok(talla);
            }
            return BadRequest("El objeto ya existe");
        }

        // PUT api/<TallaProductoController>/5
        [HttpPut("{IdTallaProducto}")]
        public async Task<IActionResult> Put(int IdTallaProducto, [FromBody] TallaProducto talla)
        {
            TallaProducto talla2 = await _db.sgc_TallaProducto.FirstOrDefaultAsync(x => x.IdTallaProducto==IdTallaProducto);
            if (talla2 != null)
            {
                talla2.Talla = talla.Talla != null ? talla.Talla : talla2.Talla;
                _db.sgc_TallaProducto.Update(talla2);
                await _db.SaveChangesAsync();
                return Ok(talla2);
            }
            return BadRequest("El producto a modificar no existe");
        }

        // DELETE api/<TallaProductoController>/5
        [HttpDelete("{IdTallaProducto}")]
        public async Task<IActionResult> Delete(int IdTallaProducto)
        {
            TallaProducto talla = await _db.sgc_TallaProducto.FirstOrDefaultAsync(x => x.IdTallaProducto==IdTallaProducto);
            if (talla != null)
            {
                _db.sgc_TallaProducto.Remove(talla);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
