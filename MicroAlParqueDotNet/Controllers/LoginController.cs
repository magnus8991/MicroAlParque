using Entidad;
using Logica;
using Microsoft.AspNetCore.Mvc;
using MicroAlParque.Models;
using Datos;
using Microsoft.AspNetCore.Authorization;
using MicroAlParque.Service;
using Microsoft.Extensions.Options;
using MicroAlParque.Config;

namespace MicroAlParque.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        MicroAlParqueContext _contexto;
        ServicioUsuario _servicioUsuario;
        JwtService _jwtService;
        public LoginController(MicroAlParqueContext contexto, IOptions<AppSetting> appSettings)
        {
            _contexto = contexto;
            var admin = _contexto.Usuarios.Find("Admin");
            if (admin == null)
            {
                var usuario = new Usuario()
                {
                    NombreUsuario = "Admin",
                    Contrasena = "11014221dM",
                    Identificacion = "1003258091",
                    Nombres = "Diego",
                    PrimerApellido = "Mandon",
                    SegundoApellido = "Arengas",
                    Edad = 22,
                    Sexo = "Masculino",
                    Email = "dam1003258091@gmail.com",
                    Estado = "ACTIVE",
                    Rol = "Administrador",
                };
                _contexto.Usuarios.Add(usuario);
                var registrosGuardados = _contexto.SaveChanges();
            }
            _servicioUsuario = new ServicioUsuario(contexto);
            _jwtService = new JwtService(appSettings);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginInputModel model)
        {
            var usuario = _servicioUsuario.Validate(model.NombreUsuario, model.Contrasena);
            if (usuario == null) return BadRequest("Nombre de usuario o contraseña incorrecto(a)");
            var response = _jwtService.GenerateToken(usuario);
            return Ok(response);
        }
    }
}