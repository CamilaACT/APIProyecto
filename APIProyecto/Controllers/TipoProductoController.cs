using APIProyecto.Data;
using APIProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductoController : ControllerBase
    {
        //Esto se usa como modelo singelton
        private readonly ApplicationDBContext _db; //cuando se pone guion bajo es porque es solo de lectura solo notacion

        public TipoProductoController(ApplicationDBContext db)
        {
            _db=db;
        }
        // GET: api/<TipoProductoController> En este método espero que se me retorne la lista de todos los tipos que tengo
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<TipoProducto> Tiposproductos = await _db.sgc_TipoProducto.ToListAsync();
            return Ok(Tiposproductos);
        }

        // GET api/<TipoProductoController>/5 Este método solo me retorna un tipoproducto especifico
        [HttpGet("{IdTipoProducto}")]
        public async Task<IActionResult> Get(int IdTipoProducto)
        {
            TipoProducto tipo = await _db.sgc_TipoProducto.FirstOrDefaultAsync(x => x.IdTipoProducto==IdTipoProducto);
            if (tipo == null)
            {
                return BadRequest();
            }
            return Ok(tipo);
        }

        // POST api/<TipoProductoController> Este método crea un tipo producto como es post lo recibe en el cuerpo de la petición
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TipoProducto tipoproducto)
        {
            TipoProducto tipoproducto2 = await _db.sgc_TipoProducto.FirstOrDefaultAsync(x => x.IdTipoProducto==tipoproducto.IdTipoProducto);
            if (tipoproducto2 == null && tipoproducto!=null)
            {
                await _db.sgc_TipoProducto.AddAsync(tipoproducto);
                await _db.SaveChangesAsync();
                return Ok(tipoproducto);
            }
            return BadRequest("El objeto ya existe");
        }

        // PUT api/<TipoProductoController>/5 Este método edita el tipo producto si primero lo encuentra
        [HttpPut("{IdTipoProducto}")]
        public async Task<IActionResult> Put(int IdTipoProducto, [FromBody] TipoProducto tipoproducto)
        {
            TipoProducto tipoProducto2 = await _db.sgc_TipoProducto.FirstOrDefaultAsync(x => x.IdTipoProducto==IdTipoProducto);
            if (tipoProducto2 != null)
            {
                tipoProducto2.Nombre = tipoproducto.Nombre != null ? tipoproducto.Nombre : tipoProducto2.Nombre;
                _db.sgc_TipoProducto.Update(tipoProducto2);
                await _db.SaveChangesAsync();
                return Ok(tipoProducto2);   
            }
            return BadRequest("El producto a modificar no existe");
        }

        // DELETE api/<TipoProductoController>/5
        [HttpDelete("{IdTipoProducto}")]
        public async Task<IActionResult> Delete(int IdTipoProducto)
        {
            TipoProducto tipoproducto = await _db.sgc_TipoProducto.FirstOrDefaultAsync(x => x.IdTipoProducto==IdTipoProducto);
            if (tipoproducto != null)
            {
                _db.sgc_TipoProducto.Remove(tipoproducto);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
