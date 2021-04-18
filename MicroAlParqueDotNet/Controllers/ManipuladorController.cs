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
    public class ManipuladorController : ControllerBase
    {
        private readonly ServicioManipuladorDeAlimento _servicioManipulador;
        private readonly IHubContext<SignalHub> _hubContext;
        public ManipuladorController(MicroAlParqueContext contexto, IHubContext<SignalHub> hubContext)
        {
            _servicioManipulador = new ServicioManipuladorDeAlimento(contexto);
            _hubContext = hubContext;
        }
         // GET: api/Lote
        [HttpGet("{sedeId}")]
        public ActionResult<PeticionConsulta<ManipuladorViewModel>> Consultar(int sedeId)
        {
            var response = _servicioManipulador.ConsultarTodos(sedeId);
            return Ok(response);
        }

        // GET: api/Lote/5
        
        
        // POST: api/Lote
        [HttpPost]
        public async Task<ActionResult<Peticion<ManipuladorViewModel>>> Guardar(ManipuladorInputModel manipuladorInput)
        {
            ManipuladorDeAlimento manipulador = MapearManipulador(manipuladorInput);
            var response = _servicioManipulador.Guardar(manipulador);
            if (response.Error)
            {
                ModelState.AddModelError("Guardar Manipulador", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            await _hubContext.Clients.All.SendAsync("ManipuladorRegistrado", response.Elemento);
            return Ok(response);
        }
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
            Manipulador.SedeId = manipuladorInput.SedeId;
            return Manipulador;
        }

        [HttpPut]
        public async Task<ActionResult<Peticion<ManipuladorViewModel>>> Modificar(ManipuladorInputModel manipuladorInput)
        {
            ManipuladorDeAlimento manipulador = MapearManipulador(manipuladorInput);
            var response = _servicioManipulador.Modificar(manipulador);
            if (response.Error)
            {
                ModelState.AddModelError("Modificar Manipulador", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            await _hubContext.Clients.All.SendAsync("ManipuladorActualizado", response.Elemento);
            return Ok(response);
        }
    }
}