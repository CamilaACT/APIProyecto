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
        // GET: api/<ColorProducto>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<TallaProducto> Tiposproductos = await _db.sgc_TallaProducto.ToListAsync();
                return Ok(Tiposproductos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // GET api/<ColorProducto>/5 //busca por ID
        [HttpGet("{IdTallaProducto}")]
        public async Task<IActionResult> Get(int IdTallaProducto)
        {
            TallaProducto talla = await _db.sgc_TallaProducto.FirstOrDefaultAsync(x => x.IdTallaProducto==IdTallaProducto);
            if (talla == null)
            {
                return BadRequest();
            }
            return Ok(talla);
        }




        // POST api/<ColorProducto>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TallaProductoDTO tallaDTO)
        {
            TallaProducto talla2 = await _db.sgc_TallaProducto.FirstOrDefaultAsync(x => x.Talla.Equals(tallaDTO.Talla));
            if (talla2 == null && tallaDTO!=null)
            {
                var talla = new TallaProducto
                {
                    Talla = tallaDTO.Talla
                };
                await _db.sgc_TallaProducto.AddAsync(talla);
                await _db.SaveChangesAsync();
                return Ok(talla);
            }
            return BadRequest("El color ya existe");
        }

        // PUT api/<ColorProducto>/5
        [HttpPut("{IdTallaProducto}")]
        public async Task<IActionResult> Put(int IdTallaProducto, [FromBody] TallaProductoDTO tallaDTO)
        {
            TallaProducto actualaModificar = await _db.sgc_TallaProducto.FirstOrDefaultAsync(x => x.IdTallaProducto==IdTallaProducto);
            var tallaqueyatengo = actualaModificar.Talla;
            TallaProducto tallaquequieroponer = await _db.sgc_TallaProducto.FirstOrDefaultAsync(x => x.Talla.Equals(tallaDTO.Talla));

            if ((tallaquequieroponer == null ||tallaquequieroponer.Talla.Equals(tallaqueyatengo)) && tallaDTO != null)
            {
                actualaModificar.Talla = tallaDTO.Talla != null ? tallaDTO.Talla : actualaModificar.Talla;
                _db.sgc_TallaProducto.Update(actualaModificar);
                await _db.SaveChangesAsync();
                return Ok(actualaModificar);
            }
            return BadRequest("La talla ya existe");
        }

        // DELETE api/<ColorProducto>/5
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
