using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MicroAlParque.Models;
using Datos;

namespace MicroAlParque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ServicioUsuario _servicioUsuario;
        public UsuarioController(MicroAlParqueContext contexto)
        {
            _servicioUsuario = new ServicioUsuario(contexto);
        }
         // GET: api/Usuario
        [HttpGet]
        public ActionResult<PeticionConsulta<UsuarioViewModel>> Consultar()
        {
            var response = _servicioUsuario.ConsultarTodos();
            return Ok(response);
        }

        // GET: api/Usuario/5
        [HttpGet("{IdRestaurante}")]
        public ActionResult<Peticion<UsuarioViewModel>> Buscar(string Identificacion)
        {
            var response = _servicioUsuario.BuscarPorIdentificacion(Identificacion);
            return Ok(response);
        }
        
        // POST: api/Usuario
        [HttpPost]
        public ActionResult<Peticion<UsuarioViewModel>> Guardar(UsuarioInputModel usuarioInput)
        {
            Usuario usuario = MapearListaChequeo(usuarioInput);
            var response = _servicioUsuario.Guardar(usuario);
            return Ok(response);
        }
      
        // DELETE: api/Usuario/5
        /*[HttpDelete("{codigoP}")]
        public ActionResult<string> Delete(string codigoP)
        {
            string mensaje = _UsuarioService.Eliminar(codigoP);
            return Ok(mensaje);
        }*/
        private Usuario MapearListaChequeo(UsuarioInputModel usuarioInput)
        {
            var Usuario = new Usuario();
            Usuario.Identificacion = usuarioInput.Identificacion;
            Usuario.Nombres = usuarioInput.Nombres;
            Usuario.PrimerApellido = usuarioInput.PrimerApellido;
            Usuario.SegundoApellido = usuarioInput.SegundoApellido;
            Usuario.Edad = usuarioInput.Edad;
            Usuario.Sexo = usuarioInput.Sexo;
            Usuario.NombreUsuario = usuarioInput.NombreUsuario;
            Usuario.Contrasena = usuarioInput.Contrasena;
            Usuario.Email = usuarioInput.Email;
            Usuario.Rol = usuarioInput.Rol;
            return Usuario;
        }
        /*// PUT: api/Usuario/5
        [HttpPut("{codigoP}")]
        public ActionResult<string> Put(string codigoP, Usuario Usuario)
        {
            throw new NotImplementedException();
        }*/
    }
}