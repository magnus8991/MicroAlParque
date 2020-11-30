using System;
using System.Collections.Generic;
using System.Linq;
using Logica;
using Microsoft.AspNetCore.Mvc;
using MicroAlParque.Models;
using Datos;
using Entidad;

namespace MicroAlParque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaController : ControllerBase
    {
        private readonly ServicioPreguntas _servicioPregunta;
        public PreguntaController(MicroAlParqueContext contexto)
        {
            _servicioPregunta = new ServicioPreguntas(contexto);
            CrearPreguntas();
        }
        // GET: api/Lote
        [HttpGet]
        public ActionResult<PeticionConsulta<PreguntaViewModel>> Consultar()
        {
            var response = _servicioPregunta.ConsultarTodos();
            return Ok(response);
        }

        private void CrearPreguntas()
        {
            var response = _servicioPregunta.ConsultarTodos();
            if (response.Elementos.Count() == 0)
            {
                IList<Pregunta> preguntas = CrearLista();
                foreach (var pregunta in preguntas)
                {
                    var mensaje = _servicioPregunta.Guardar(pregunta);
                }
            }
        }

        private IList<Pregunta> CrearLista()
        {
            IList<Pregunta> preguntas = new List<Pregunta>();
            preguntas.Add(new Pregunta("¿Conoce las normas de higiene para manipulación de alimentos?"));
            preguntas.Add(new Pregunta("¿Ha recibido  capacitación sobre buenas prácticas de manufactura?"));
            preguntas.Add(new Pregunta("¿De qué trata la  resolución 2674 del 2013?"));
            preguntas.Add(new Pregunta("¿Qué tipo de contaminación de los alimentos conoce?"));
            preguntas.Add(new Pregunta("¿Sabe qué es un alimento inocuo? Explique"));
            preguntas.Add(new Pregunta("En caso afirmativo, la explicación, ¿Fue correcta?"));
            preguntas.Add(new Pregunta("¿Considera necesaria una capacitación sobre normas de higiene y manipulación de alimentos para mejorar sus procesos y su negocio?"));
            preguntas.Add(new Pregunta("¿Ha renovado el último año su certificado médico?"));
            preguntas.Add(new Pregunta("¿Se ha realizado los exámenes para manipuladores de alimentos (KOH de uñas, Frotis de garganta y coprológico)?"));
            preguntas.Add(new Pregunta("En caso afirmativo, ¿Hace cuánto?"));
            preguntas.Add(new Pregunta("¿Considera que manipular alimentos con las uñas largas y pintadas puede ser inapropiado?"));
            preguntas.Add(new Pregunta("¿Considera que el uso de prendas puede afectar negativamente el proceso de manipulación de alimentos?"));
            preguntas.Add(new Pregunta("¿Utiliza bata,  tapa bocas y malla para cubrir el cabello mientras manipula alimentos?"));
            preguntas.Add(new Pregunta("¿Manipula alimentos y dinero al mismo tiempo?"));
            preguntas.Add(new Pregunta("¿Con qué frecuencia se lava las manos para manipular alimentos?"));
            preguntas.Add(new Pregunta("Al momento de preparar alimentos, ¿retira sus prendas?"));
            return preguntas;
        }
    }
}