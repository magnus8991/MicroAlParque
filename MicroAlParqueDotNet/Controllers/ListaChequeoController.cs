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
         // GET: api/Lote
        [HttpGet]
        public ActionResult<PeticionConsulta<ListaChequeoViewModel>> Consultar()
        {
            var response = _servicioListaChequeo.ConsultarTodos();
            return Ok(response);
        }

        // GET: api/Lote/5
        [HttpGet("{IdSede}")]
        public ActionResult<PeticionConsulta<ListaChequeoViewModel>> Buscar(int IdSede)
        {
            var response = _servicioListaChequeo.ConsultarPorSede(IdSede);
            return Ok(response);
        }
        
        // POST: api/Lote
        [HttpPost]
        public ActionResult<Peticion<ListaChequeoViewModel>> Guardar(ListaChequeoInputModel listaChequeoInput)
        {
            ListaChequeo listaChequeo = MapearListaChequeo(listaChequeoInput);
            var response = _servicioListaChequeo.Guardar(listaChequeo);
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