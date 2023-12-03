using APIProyecto.Data;
using APIProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        public UsuarioController(ApplicationDBContext db)
        {
            _db=db;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Usuario> Cliente = await _db.sgc_Usuarios.ToListAsync();
            return Ok(Cliente);
        }

        // GET api/<UsuarioController>/5

        [HttpGet("{IdUsuario}")]
        public async Task<IActionResult> Get(int IdUsuario)
        {
            Usuario usuario = await _db.sgc_Usuarios.FirstOrDefaultAsync(x => x.IdUsuario==IdUsuario);
            if (usuario == null)
            {
                return BadRequest();
            }
            return Ok(usuario);
        }
        //metodo para el login 
        [HttpGet("{Login}/{Contrasenia}")]
        public async Task<IActionResult> GetCredenciales(string Login, string Contrasenia)
        {
            Usuario usuario = await _db.sgc_Usuarios.FirstOrDefaultAsync(x => x.Login.Equals(Login) && x.Contrasenia.Equals(Contrasenia));
            if (usuario == null)
            {
                return BadRequest();
            }
            return Ok(usuario);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            Usuario usuario2 = await _db.sgc_Usuarios.FirstOrDefaultAsync(x => x.Cedula.Equals(usuario.Cedula));
            if (usuario2 == null && usuario!=null)
            {
                await _db.sgc_Usuarios.AddAsync(usuario);
                await _db.SaveChangesAsync();
                return Ok(usuario);
            }
            return BadRequest("El usuario ya existe");
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{IdUsuario}")]
        public async Task<IActionResult> Put(int IdUsuario, [FromBody] Usuario usuario)
        {
            Usuario usuario2 = await _db.sgc_Usuarios.FirstOrDefaultAsync(x => x.IdUsuario==IdUsuario);
            if (usuario2 != null)
            {
                usuario2.Nombre = usuario.Nombre != null ? usuario.Nombre : usuario2.Nombre;
                usuario2.Cedula = usuario.Cedula != null ? usuario.Cedula : usuario2.Cedula;
                usuario2.Apellido = usuario.Apellido != null ? usuario.Apellido : usuario2.Apellido;
                usuario2.Login = usuario.Login != null ? usuario.Login : usuario2.Login;
                usuario2.Contrasenia = usuario.Contrasenia  != null ? usuario.Contrasenia : usuario2.Contrasenia;
                usuario2.NumeroSeguridad = usuario.NumeroSeguridad  != null ? usuario.NumeroSeguridad : usuario2.NumeroSeguridad;

                _db.sgc_Usuarios.Update(usuario2);
                await _db.SaveChangesAsync();
                return Ok(usuario2);
            }
            return BadRequest("El producto a modificar no existe");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{IdUsuario}")]
        public async Task<IActionResult> Delete(int IdUsuario)
        {
            Usuario usur = await _db.sgc_Usuarios.FirstOrDefaultAsync(x => x.IdUsuario==IdUsuario);
            if (usur != null)
            {
                _db.sgc_Usuarios.Remove(usur);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
