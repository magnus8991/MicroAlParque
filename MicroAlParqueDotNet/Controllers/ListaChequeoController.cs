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
        [HttpGet("{IdRestaurante}")]
        public ActionResult<Peticion<ListaChequeoViewModel>> Buscar(int IdListaChequeo)
        {
            var response = _servicioListaChequeo.BuscarPorIdListaChequeo(IdListaChequeo);
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
      
        // DELETE: api/Lote/5
        /*[HttpDelete("{codigoP}")]
        public ActionResult<string> Delete(string codigoP)
        {
            string mensaje = _LoteService.Eliminar(codigoP);
            return Ok(mensaje);
        }*/
        private ListaChequeo MapearListaChequeo(ListaChequeoInputModel listaChequeoInput)
        {
            var ListaChequeo = new ListaChequeo();
            ListaChequeo.RestauranteId = listaChequeoInput.RestauranteId;
            ListaChequeo.RespuestaChequeos = listaChequeoInput.RespuestaChequeos;
            return ListaChequeo;
        }
        /*// PUT: api/Lote/5
        [HttpPut("{codigoP}")]
        public ActionResult<string> Put(string codigoP, Lote Lote)
        {
            throw new NotImplementedException();
        }*/
    }
}