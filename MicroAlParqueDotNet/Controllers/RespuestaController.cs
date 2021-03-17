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
using Microsoft.AspNetCore.Authorization;

namespace MicroAlParque.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestaController : ControllerBase
    {
        private readonly ServicioRespuesta _servicioRespuesta;
        public RespuestaController(MicroAlParqueContext contexto)
        {
            _servicioRespuesta = new ServicioRespuesta(contexto);
        }
         // GET: api/Lote
        [HttpGet]
        public ActionResult<PeticionConsulta<RespuestaViewModel>> Consultar()
        {
            var peticion = _servicioRespuesta.ConsultarTodos();
            return Ok(peticion);
        }

        // GET: api/Lote/5
        [HttpGet("{IdRestaurante}")]
        public ActionResult<Peticion<RespuestaViewModel>> Buscar(int IdRespuesta)
        {
            var peticion = _servicioRespuesta.BuscarPorIdRespuesta(IdRespuesta);
            return Ok(peticion);
        }
        
        // POST: api/Lote
        [HttpPost]
        public ActionResult<Peticion<RespuestaViewModel>> Guardar(RespuestaInputModel respuestaInput)
        {
            Respuesta respuesta = MapearRespuesta(respuestaInput);
            var peticion = _servicioRespuesta.Guardar(respuesta);
            return Ok(peticion);
        }
      
        // DELETE: api/Lote/5
        /*[HttpDelete("{codigoP}")]
        public ActionResult<string> Delete(string codigoP)
        {
            string mensaje = _LoteService.Eliminar(codigoP);
            return Ok(mensaje);
        }*/
        private Respuesta MapearRespuesta(RespuestaInputModel respuestaInput)
        {
            var Respuesta = new Respuesta();
            Respuesta.ContenidoRespuesta = respuestaInput.ContenidoRespuesta;
            Respuesta.PreguntaId = respuestaInput.PreguntaId;
            Respuesta.Identificacion = respuestaInput.Identificacion;
            return Respuesta;
        }
        /*// PUT: api/Lote/5
        [HttpPut("{codigoP}")]
        public ActionResult<string> Put(string codigoP, Lote Lote)
        {
            throw new NotImplementedException();
        }*/
    }
}