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
    public class ListaChequeoController : ControllerBase
    {
        private readonly ServicioListaChequeo _servicioListaChequeo;
        public ListaChequeoController(MicroAlParqueContext contexto)
        {
            _servicioListaChequeo = new ServicioListaChequeo(contexto);
        }

        // GET: api/Lote/5
        [HttpGet("{Formulario}/{Identificador}")]
        public object EjecutarConsulta(string Formulario, int Identificador) {
            if (Formulario == "Busqueda") return Buscar(Identificador);
            else return Consultar(Identificador);
        }
        private ActionResult<PeticionConsulta<ListaChequeoViewModel>> Consultar(int IdSede)
        {
            var response = _servicioListaChequeo.ConsultarPorSede(IdSede);
            if (response.Error) return BadRequest(response.Mensaje);
            return Ok(response);
        }
        
        private ActionResult<Peticion<ListaChequeoViewModel>> Buscar(int IdListaChequeo)
        {
            var response = _servicioListaChequeo.BuscarPorIdListaChequeo(IdListaChequeo);
            if (response.Error) return BadRequest(response.Mensaje);
            return Ok(response);
        }
        
        // POST: api/Lote
        [HttpPost]
        public ActionResult<Peticion<ListaChequeoViewModel>> Guardar(ListaChequeoInputModel listaChequeoInput)
        {
            ListaChequeo listaChequeo = MapearListaChequeo(listaChequeoInput);
            var response = _servicioListaChequeo.Guardar(listaChequeo);
            if (response.Error) return BadRequest(response.Mensaje);
            return Ok(response);
        }
        private ListaChequeo MapearListaChequeo(ListaChequeoInputModel listaChequeoInput)
        {
            var ListaChequeo = new ListaChequeo();
            ListaChequeo.SedeId = listaChequeoInput.SedeId;
            ListaChequeo.RespuestaChequeos = listaChequeoInput.RespuestaChequeos;
            ListaChequeo.Fecha = DateTime.Now;
            return ListaChequeo;
        }
    }
}