using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using FarmaciaArias.Models;
using Datos;

namespace FarmaciaArias.Controllers
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
         // GET: api/Lote
        [HttpGet]
        public ActionResult<PeticionConsulta<UsuarioViewModel>> Consultar()
        {
            var response = _servicioUsuario.ConsultarTodos();
            return Ok(response);
        }

        // GET: api/Lote/5
        [HttpGet("{IdRestaurante}")]
        public ActionResult<Peticion<UsuarioViewModel>> Buscar(string Identificacion)
        {
            var response = _servicioUsuario.BuscarPorIdentificacion(Identificacion);
            return Ok(response);
        }
        
        // POST: api/Lote
        [HttpPost]
        public ActionResult<Peticion<UsuarioViewModel>> Guardar(UsuarioInputModel usuarioInput)
        {
            Usuario usuario = MapearListaChequeo(usuarioInput);
            var response = _servicioUsuario.Guardar(usuario);
            return Ok(response);
        }
      
        // DELETE: api/Lote/5
        /*[HttpDelete("{codigoP}")]
        public ActionResult<string> Delete(string codigoP)
        {
            string mensaje = _LoteService.Eliminar(codigoP);
            return Ok(mensaje);
        }*/
        private Usuario MapearListaChequeo(UsuarioInputModel usuarioInput)
        {
            var Usuario = new Usuario();
            Usuario.Identificacion = usuarioInput.Identificacion;
            Usuario.TipoUsuario = usuarioInput.TipoUsuario;
            Usuario.NombreUsuario = usuarioInput.NombreUsuario;
            Usuario.Contraseña = usuarioInput.Contraseña;
            return Usuario;
        }
        /*// PUT: api/Lote/5
        [HttpPut("{codigoP}")]
        public ActionResult<string> Put(string codigoP, Lote Lote)
        {
            throw new NotImplementedException();
        }*/
    }
}