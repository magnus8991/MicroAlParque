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
    public class ManipuladorController : ControllerBase
    {
        private readonly ServicioManipuladorDeAlimento _servicioManipulador;
        public ManipuladorController(MicroAlParqueContext contexto)
        {
            _servicioManipulador = new ServicioManipuladorDeAlimento(contexto);
        }
         // GET: api/Lote
        [HttpGet]
        public ActionResult<PeticionConsulta<ManipuladorViewModel>> Consultar()
        {
            var response = _servicioManipulador.ConsultarTodos();
            return Ok(response);
        }

        // GET: api/Lote/5
        [HttpGet("{IdRestaurante}")]
        public ActionResult<Peticion<ManipuladorViewModel>> Buscar(string Identificacion)
        {
            var response = _servicioManipulador.BuscarPorIdentificacion(Identificacion);
            return Ok(response);
        }
        
        // POST: api/Lote
        [HttpPost]
        public ActionResult<Peticion<ManipuladorViewModel>> Guardar(ManipuladorInputModel manipuladorInput)
        {
            ManipuladorDeAlimento manipulador = MapearManipulador(manipuladorInput);
            var response = _servicioManipulador.Guardar(manipulador);
            return Ok(response);
        }
      
        // DELETE: api/Lote/5
        /*[HttpDelete("{codigoP}")]
        public ActionResult<string> Delete(string codigoP)
        {
            string mensaje = _LoteService.Eliminar(codigoP);
            return Ok(mensaje);
        }*/
        private ManipuladorDeAlimento MapearManipulador(ManipuladorInputModel manipuladorInput)
        {
            var Manipulador = new ManipuladorDeAlimento();
            Manipulador.Identificacion = manipuladorInput.Identificacion;
            Manipulador.Nombres = manipuladorInput.Nombres;
            Manipulador.PrimerApellido = manipuladorInput.PrimerApellido;
            Manipulador.SegundoApellido = manipuladorInput.SegundoApellido;
            Manipulador.Sexo = manipuladorInput.Sexo;
            Manipulador.Edad = manipuladorInput.Edad;
            Manipulador.EstadoCivil = manipuladorInput.EstadoCivil;
            Manipulador.PaisDeProcedencia = manipuladorInput.PaisDeProcedencia;
            Manipulador.NivelEducativo = manipuladorInput.NivelEducativo;
            Manipulador.RestauranteId = manipuladorInput.RestauranteId;
            return Manipulador;
        }
        /*// PUT: api/Lote/5
        [HttpPut("{codigoP}")]
        public ActionResult<string> Put(string codigoP, Lote Lote)
        {
            throw new NotImplementedException();
        }*/
    }
}