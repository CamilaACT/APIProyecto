using APIProyecto.Data;
using APIProyecto.Migrations;
using APIProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //Esto se usa como modelo singelton
        private readonly ApplicationDBContext _db; //cuando se pone guion bajo es porque es solo de lectura solo notacion

        public ClienteController(ApplicationDBContext db)
        {
            _db=db;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Cliente> Cliente = await _db.sgc_Cliente.ToListAsync();
            return Ok(Cliente);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{IdCliente}")]
        public async Task<IActionResult> Get(int IdCliente)
        {
            Cliente cleinte = await _db.sgc_Cliente.FirstOrDefaultAsync(x => x.IdCliente==IdCliente);
            if (cleinte == null)
            {
                return BadRequest();
            }
            return Ok(cleinte);
        }
        [HttpGet("{Cedula}")]
        public async Task<IActionResult> Get(String Cedula)
        {
            Cliente cleinte = await _db.sgc_Cliente.FirstOrDefaultAsync(x => x.Cedula==Cedula);
            if (cleinte == null)
            {
                return BadRequest();
            }
            return Ok(cleinte);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            Cliente cliente2 = await _db.sgc_Cliente.FirstOrDefaultAsync(x => x.IdCliente==cliente.IdCliente);
            if (cliente2 == null && cliente!=null)
            {
                await _db.sgc_Cliente.AddAsync(cliente);
                await _db.SaveChangesAsync();
                return Ok(cliente);
            }
            return BadRequest("El objeto ya existe");
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{IdCliente}")]
        public async Task<IActionResult> Put(int IdCliente, [FromBody] Cliente cliente)
        {
            Cliente cliente2 = await _db.sgc_Cliente.FirstOrDefaultAsync(x => x.IdCliente==IdCliente);
            if (cliente2 != null)
            {
                cliente2.Nombre = cliente.Nombre != null ? cliente.Nombre : cliente2.Nombre;
                cliente2.Cedula = cliente.Cedula != null ? cliente.Cedula : cliente2.Cedula;
                cliente2.Apellido = cliente.Apellido != null ? cliente.Apellido : cliente2.Apellido;
                cliente2.Direccion = cliente.Direccion != null ? cliente.Direccion : cliente2.Direccion;
                cliente2.NumeroTarjeta = cliente.NumeroTarjeta != null ? cliente.NumeroTarjeta : cliente2.NumeroTarjeta;
                

                _db.sgc_Cliente.Update(cliente2);
                await _db.SaveChangesAsync();
                return Ok(cliente2);
            }
            return BadRequest("El producto a modificar no existe");
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{IdCliente}")]
        public async Task<IActionResult> Delete(int IdCliente)
        {
            Cliente cliente = await _db.sgc_Cliente.FirstOrDefaultAsync(x => x.IdCliente==IdCliente);
            if (cliente != null)
            {
                _db.sgc_Cliente.Remove(cliente);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
        //metodo para el login 
        [HttpGet("{Login}/{Contrasenia}")]
        public async Task<IActionResult> GetCredenciales(string Login, string Contrasenia)
        {
            Cliente cliente = await _db.sgc_Cliente.FirstOrDefaultAsync(x => x.Login.Equals(Login) && x.Contrasenia.Equals(Contrasenia));
            if (cliente == null)
            {
                return BadRequest();
            }
            return Ok(cliente);
        }
    }
}
