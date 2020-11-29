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
    public class RestauranteController : ControllerBase
    {
        private readonly ServicioRestaurante _servicioRestaurante;
        public RestauranteController(MicroAlParqueContext contexto)
        {
            _servicioRestaurante = new ServicioRestaurante(contexto);
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
        public ActionResult<Peticion<RestauranteViewModel>> Guardar(RestauranteInputModel restauranteInput)
        {
            Restaurante restaurante = MapearRestaurante(restauranteInput);
            var response = _servicioRestaurante.Guardar(restaurante);
            return Ok(response);
        }

        [HttpPut]
        public ActionResult<Peticion<RestauranteViewModel>> Modificar(RestauranteInputModel restauranteInput)
        {
            Restaurante restaurante = MapearRestaurante(restauranteInput);
            var response = _servicioRestaurante.Modificar(restaurante);
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