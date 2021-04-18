using System;
using System.Collections.Generic;
using System.Linq;
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
            if (peticion.Error)
            {
                ModelState.AddModelError("Consultar Respuestas", peticion.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(peticion);
        }

        // GET: api/Lote/5
        [HttpGet("{Identificacion}")]
        public ActionResult<Peticion<RespuestaViewModel>> ConsultarPorManipulador(string Identificacion)
        {
            var peticion = _servicioRespuesta.ConsultarPorManipulador(Identificacion);
            if (peticion.Error)
            {
                ModelState.AddModelError("Consultar Respuestas", peticion.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
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
        private Respuesta MapearRespuesta(RespuestaInputModel respuestaInput)
        {
            var Respuesta = new Respuesta();
            Respuesta.ContenidoRespuesta = respuestaInput.ContenidoRespuesta;
            Respuesta.PreguntaId = respuestaInput.PreguntaId;
            Respuesta.Identificacion = respuestaInput.Identificacion;
            if (respuestaInput.RespuestaId != 0) Respuesta.RespuestaId = respuestaInput.RespuestaId;
            return Respuesta;
        }

        [HttpPut]
        public ActionResult<PeticionConsulta<RespuestaViewModel>> Modificar(RespuestaInputModel[] respuestasInput)
        {
            List<Respuesta> respuestas = MapearRespuestas(respuestasInput);
            var peticion = _servicioRespuesta.ModificarRespuestas(respuestas);
            if (peticion.Error)
            {
                ModelState.AddModelError("Modificar Respuestas", peticion.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(peticion);
        }
        List<Respuesta> MapearRespuestas(RespuestaInputModel[] respuestasInput) {
            List<Respuesta> respuestas = new List<Respuesta>();
            foreach (var item in respuestasInput) respuestas.Add(MapearRespuesta(item));
            return respuestas;
        }
    }
}