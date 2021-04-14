using System.Threading.Tasks;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class RestauranteController : ControllerBase
    {
        private readonly ServicioRestaurante _servicioRestaurante;
        private readonly IHubContext<SignalHub> _hubContext;
        public RestauranteController(MicroAlParqueContext contexto, IHubContext<SignalHub> hubContext)
        {
            _servicioRestaurante = new ServicioRestaurante(contexto);
            _hubContext = hubContext;
        }
        // GET: api/Lote
        [HttpGet]
        public ActionResult<PeticionConsulta<RestauranteViewModel>> Consultar()
        {
            var response = _servicioRestaurante.ConsultarTodos();
            return Ok(response);
        }

        // GET: api/Lote/5
        [HttpGet("{IdRestaurante}")]
        public ActionResult<Peticion<RestauranteViewModel>> Buscar(string IdRestaurante)
        {
            var response = _servicioRestaurante.BuscarPorIdRestaurante(IdRestaurante);
            return Ok(response);
        }

        // POST: api/Lote
        [HttpPost]
        public async Task<ActionResult<Peticion<RestauranteViewModel>>> Guardar(RestauranteInputModel restauranteInput)
        {
            Restaurante restaurante = MapearRestaurante(restauranteInput);
            var response = _servicioRestaurante.Guardar(restaurante);
            if (response.Error)
            {
                ModelState.AddModelError("Guardar Restaurante", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            await _hubContext.Clients.All.SendAsync("RestauranteRegistrado", response.Elemento);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<Peticion<RestauranteViewModel>>> Modificar(RestauranteInputModel restauranteInput)
        {
            Restaurante restaurante = MapearRestaurante(restauranteInput);
            var response = _servicioRestaurante.Modificar(restaurante);
            if (response.Error) return BadRequest(response.Mensaje);
            await _hubContext.Clients.All.SendAsync("RestauranteModificado", response.Elemento);
            return Ok(response);
        }
        
        private Restaurante MapearRestaurante(RestauranteInputModel restauranteInput)
        {
            var Restaurante = new Restaurante();
            Restaurante.NIT = restauranteInput.NIT;
            Restaurante.Nombre = restauranteInput.Nombre;
            Restaurante.Propietario = restauranteInput.Propietario;
            return Restaurante;
        }
    }
}