using Entidad;
using Logica;
using Microsoft.AspNetCore.Mvc;
using MicroAlParque.Models;
using Datos;

namespace MicroAlParque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropietarioController : ControllerBase
    {
        private readonly ServicioPropietario _servicioPropietario;
        public PropietarioController(MicroAlParqueContext contexto)
        {
            _servicioPropietario = new ServicioPropietario(contexto);
        }
         // GET: api/Propietario
        [HttpGet]
        public ActionResult<PeticionConsulta<PropietarioViewModel>> Consultar()
        {
            var response = _servicioPropietario.ConsultarTodos();
            return Ok(response);
        }

        // GET: api/Propietario/5
        [HttpGet("{IdRestaurante}")]
        public ActionResult<Peticion<PropietarioViewModel>> Buscar(string Identificacion)
        {
            var response = _servicioPropietario.BuscarPorIdentificacion(Identificacion);
            return Ok(response);
        }
        
        // POST: api/Propietario
        [HttpPost]
        public ActionResult<Peticion<PropietarioViewModel>> Guardar(PropietarioInputModel PropietarioInput)
        {
            Propietario Propietario = MapearListaChequeo(PropietarioInput);
            var response = _servicioPropietario.Guardar(Propietario);
            return Ok(response);
        }
      
        // DELETE: api/Propietario/5
        /*[HttpDelete("{codigoP}")]
        public ActionResult<string> Delete(string codigoP)
        {
            string mensaje = _PropietarioService.Eliminar(codigoP);
            return Ok(mensaje);
        }*/
        private Propietario MapearListaChequeo(PropietarioInputModel PropietarioInput)
        {
            var Propietario = new Propietario();
            Propietario.Identificacion = PropietarioInput.Identificacion;
            Propietario.Nombres = PropietarioInput.Nombres;
            Propietario.PrimerApellido = PropietarioInput.PrimerApellido;
            Propietario.SegundoApellido = PropietarioInput.SegundoApellido;
            Propietario.Edad = PropietarioInput.Edad;
            Propietario.Sexo = PropietarioInput.Sexo;
            return Propietario;
        }
        /*// PUT: api/Propietario/5
        [HttpPut("{codigoP}")]
        public ActionResult<string> Put(string codigoP, Propietario Propietario)
        {
            throw new NotImplementedException();
        }*/
    }
}