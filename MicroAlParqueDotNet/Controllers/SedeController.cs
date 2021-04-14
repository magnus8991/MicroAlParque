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
using Microsoft.AspNetCore.SignalR;
using MicroAlParque.Hubs;
using Microsoft.AspNetCore.Authorization;

namespace MicroAlParque.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SedeController : ControllerBase
    {
        private readonly ServicioSede _servicioSede;
        private readonly IHubContext<SignalHub> _hubContext;
        public SedeController(MicroAlParqueContext contexto, IHubContext<SignalHub> hubContext)
        {
            _servicioSede = new ServicioSede(contexto);
            _hubContext = hubContext;
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
        public async Task<ActionResult<Peticion<SedeViewModel>>> Guardar(SedeInputModel SedeInput)
        {
            Sede Sede = MapearSede(SedeInput);
            var response = _servicioSede.Guardar(Sede);
            if (response.Error) return BadRequest(response.Mensaje);
            await _hubContext.Clients.All.SendAsync("SedeRegistrada", response.Elemento);
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
        public async Task<ActionResult<Peticion<SedeViewModel>>> Modificar(int SedeId, SedeInputModel SedeInput)
        {
            Sede Sede = MapearSede(SedeInput);
            var response = _servicioSede.Modificar(Sede, SedeId);
            if (response.Error) return BadRequest(response.Mensaje);
            await _hubContext.Clients.All.SendAsync("SedeModificada", response.Elemento);
            return Ok(response);
        }
    }
}