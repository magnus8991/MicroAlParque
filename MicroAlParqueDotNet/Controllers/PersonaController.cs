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
    public class PersonaController : ControllerBase
    {
        private readonly ServicioPersona _servicioPersona;
        public PersonaController(MicroAlParqueContext contexto)
        {
            _servicioPersona = new ServicioPersona(contexto);
        }
         // GET: api/Lote
        [HttpGet]
        public ActionResult<PeticionConsulta<PersonaViewModel>> Consultar()
        {
            var peticion = _servicioPersona.ConsultarTodos();
            return Ok(peticion);
        }

        // GET: api/Lote/5
        [HttpGet("{IdRestaurante}")]
        public ActionResult<Peticion<PersonaViewModel>> Buscar(string Identificacion)
        {
            var peticion = _servicioPersona.BuscarPorIdentificacion(Identificacion);
            return Ok(peticion);
        }
        
        // POST: api/Lote
        [HttpPost]
        public ActionResult<Peticion<PersonaViewModel>> Guardar(PersonaInputModel PersonaInput)
        {
            Persona Persona = MapearPersona(PersonaInput);
            var peticion = _servicioPersona.Guardar(Persona);
            return Ok(peticion);
        }
      
        // DELETE: api/Lote/5
        /*[HttpDelete("{codigoP}")]
        public ActionResult<string> Delete(string codigoP)
        {
            string mensaje = _LoteService.Eliminar(codigoP);
            return Ok(mensaje);
        }*/
        private Persona MapearPersona(PersonaInputModel PersonaInput)
        {
            var Persona = new Persona();
            Persona.Identificacion = PersonaInput.Identificacion;
            Persona.Nombres = PersonaInput.Nombres;
            Persona.PrimerApellido = PersonaInput.PrimerApellido;
            Persona.SegundoApellido = PersonaInput.SegundoApellido;
            Persona.Sexo = PersonaInput.Sexo;
            Persona.Edad = PersonaInput.Edad;
            return Persona;
        }
        /*// PUT: api/Lote/5
        [HttpPut("{codigoP}")]
        public ActionResult<string> Put(string codigoP, Lote Lote)
        {
            throw new NotImplementedException();
        }*/
    }
}