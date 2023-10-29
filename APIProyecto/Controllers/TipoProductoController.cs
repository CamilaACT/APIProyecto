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
        // GET: api/<ColorProducto>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<TipoProducto> Tiposproductos = await _db.sgc_TipoProducto.ToListAsync();
                return Ok(Tiposproductos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // GET api/<ColorProducto>/5 //busca por ID
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




        // POST api/<ColorProducto>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TipoProductoDTO tipoDTO)
        {
            TipoProducto tipo2 = await _db.sgc_TipoProducto.FirstOrDefaultAsync(x => x.Nombre.Equals(tipoDTO.Nombre));
            if (tipo2 == null && tipoDTO!=null)
            {
                var tipo = new TipoProducto
                {
                    Nombre = tipoDTO.Nombre,
                    Descripcion = tipoDTO.Descripcion
                };
                await _db.sgc_TipoProducto.AddAsync(tipo);
                await _db.SaveChangesAsync();
                return Ok(tipo);
            }
            return BadRequest("El tipo ya existe");
        }

        // PUT api/<ColorProducto>/5
        [HttpPut("{IdTipoProducto}")]
        public async Task<IActionResult> Put(int IdTipoProducto, [FromBody] TipoProductoDTO tipoDTO)
        {
            TipoProducto actualaModificar = await _db.sgc_TipoProducto.FirstOrDefaultAsync(x => x.IdTipoProducto==IdTipoProducto);
            var nombrequeyatengo=actualaModificar.Nombre;
            TipoProducto tallaquequieroponer = await _db.sgc_TipoProducto.FirstOrDefaultAsync(x => x.Nombre.Equals(tipoDTO.Nombre));

            if ((tallaquequieroponer == null || tallaquequieroponer.Nombre.Equals(nombrequeyatengo)) && tipoDTO != null)
            {
                actualaModificar.Nombre = tipoDTO.Nombre != null ? tipoDTO.Nombre : actualaModificar.Nombre;
                actualaModificar.Descripcion = tipoDTO.Descripcion != null ? tipoDTO.Descripcion : actualaModificar.Descripcion;
                _db.sgc_TipoProducto.Update(actualaModificar);
                await _db.SaveChangesAsync();
                return Ok(actualaModificar);
            }
            return BadRequest("La talla ya existe");
        }

        // DELETE api/<ColorProducto>/5
        [HttpDelete("{IdTipoProducto}")]
        public async Task<IActionResult> Delete(int IdTipoProducto)
        {
            TipoProducto talla = await _db.sgc_TipoProducto.FirstOrDefaultAsync(x => x.IdTipoProducto==IdTipoProducto);
            if (talla != null)
            {
                _db.sgc_TipoProducto.Remove(talla);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
