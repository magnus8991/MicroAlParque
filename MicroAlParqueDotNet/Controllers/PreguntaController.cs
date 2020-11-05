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
    public class PreguntaController : ControllerBase
    {
        private readonly ServicioPreguntas _servicioPregunta;
        public PreguntaController(MicroAlParqueContext contexto)
        {
            _servicioPregunta = new ServicioPreguntas(contexto);
        }
         // GET: api/Lote
        [HttpGet]
        public ActionResult<PeticionConsulta<PreguntaViewModel>> Consultar()
        {
            var response = _servicioPregunta.ConsultarTodos();
            return Ok(response);
        }

        // GET: api/Lote/5
        [HttpGet("{IdRestaurante}")]
        public ActionResult<Peticion<PreguntaViewModel>> Buscar(int IdPregunta)
        {
            var response = _servicioPregunta.BuscarPorIdPregunta(IdPregunta);
            return Ok(response);
        }
        
        // POST: api/Lote
        [HttpPost]
        public ActionResult<Peticion<PreguntaViewModel>> Guardar(PreguntaInputModel preguntaInput)
        {
            Pregunta pregunta = MapearPregunta(preguntaInput);
            var response = _servicioPregunta.Guardar(pregunta);
            return Ok(response);
        }
      
        // DELETE: api/Lote/5
        /*[HttpDelete("{codigoP}")]
        public ActionResult<string> Delete(string codigoP)
        {
            string mensaje = _LoteService.Eliminar(codigoP);
            return Ok(mensaje);
        }*/
        private Pregunta MapearPregunta(PreguntaInputModel preguntaInput)
        {
            var Pregunta = new Pregunta();
            Pregunta.Enunciado = preguntaInput.Enunciado;
            return Pregunta;
        }
        /*// PUT: api/Lote/5
        [HttpPut("{codigoP}")]
        public ActionResult<string> Put(string codigoP, Lote Lote)
        {
            throw new NotImplementedException();
        }*/
    }
}