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
    public class SedeController : ControllerBase
    {
        private readonly ServicioSede _servicioSede;
        public SedeController(MicroAlParqueContext contexto)
        {
            _servicioSede = new ServicioSede(contexto);
        }
        // GET: api/Lote
        [HttpGet("{RestauranteId}")]
        public ActionResult<PeticionConsulta<SedeViewModel>> Consultar(string RestauranteId)
        {
            var response = _servicioSede.ConsultarTodos(RestauranteId);
            return Ok(response);
        }

        // GET: api/Lote/5
        [HttpGet("{Nombre}/{RestauranteId}")]
        public ActionResult<Peticion<SedeViewModel>> Buscar(string Nombre, string RestauranteId)
        {
            var response = _servicioSede.BuscarPorIdRestaurante(Nombre, RestauranteId);
            return Ok(response);
        }

        // POST: api/Lote
        [HttpPost]
        public ActionResult<Peticion<SedeViewModel>> Guardar(SedeInputModel SedeInput)
        {
            Sede Sede = MapearSede(SedeInput);
            var response = _servicioSede.Guardar(Sede);
            return Ok(response);
        }

        // DELETE: api/Lote/5
        /*[HttpDelete("{codigoP}")]
        public ActionResult<string> Delete(string codigoP)
        {
            string mensaje = _LoteService.Eliminar(codigoP);
            return Ok(mensaje);
        }*/
        private Sede MapearSede(SedeInputModel SedeInput)
        {
            var Sede = new Sede();
            Sede.Nombre = SedeInput.Nombre;
            Sede.Direccion = SedeInput.Direccion;
            Sede.Telefono = SedeInput.Telefono;
            Sede.RestauranteId = SedeInput.RestauranteId;
            return Sede;
        }
        
        // PUT: api/Lote/5
        [HttpPut("{SedeId}")]
        public ActionResult<Peticion<SedeViewModel>> Modificar(int SedeId, SedeInputModel SedeInput)
        {
            Sede Sede = MapearSede(SedeInput);
            var response = _servicioSede.Modificar(Sede, SedeId);
            return Ok(response);
        }
    }
}