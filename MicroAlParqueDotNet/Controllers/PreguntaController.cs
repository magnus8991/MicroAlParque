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
        [HttpGet("{PerteneceA}")]
        public ActionResult<PeticionConsulta<PreguntaViewModel>> Consultar(string PerteneceA)
        {
            var response = _servicioPregunta.ConsultarPorPertenencia(PerteneceA);
            return Ok(response);
        }

        private void CrearPreguntas()
        {
            var response = _servicioPregunta.ConsultarTodos();
            if (response.Elementos.Count() == 0)
            {
                IList<Pregunta> preguntas = new List<Pregunta>();
                CrearPreguntasManipuladores(preguntas);
                CrearPreguntaListaDeChequeo(preguntas);
                foreach (var pregunta in preguntas)
                {
                    var mensaje = _servicioPregunta.Guardar(pregunta);
                }
            }
        }

        private void CrearPreguntasManipuladores(IList<Pregunta> preguntas)
        {
            preguntas.Add(new Pregunta("¿Conoce las normas de higiene para manipulación de alimentos?", "Manipuladores"));
            preguntas.Add(new Pregunta("¿Ha recibido  capacitación sobre buenas prácticas de manufactura?", "Manipuladores"));
            preguntas.Add(new Pregunta("¿De qué trata la  resolución 2674 del 2013?", "Manipuladores"));
            preguntas.Add(new Pregunta("¿Qué tipo de contaminación de los alimentos conoce?", "Manipuladores"));
            preguntas.Add(new Pregunta("¿Sabe qué es un alimento inocuo? Explique", "Manipuladores"));
            preguntas.Add(new Pregunta("En caso afirmativo, la explicación, ¿Fue correcta?", "Manipuladores"));
            preguntas.Add(new Pregunta("¿Considera necesaria una capacitación sobre normas de higiene y manipulación de alimentos para mejorar sus procesos y su negocio?", "Manipuladores"));
            preguntas.Add(new Pregunta("¿Ha renovado el último año su certificado médico?", "Manipuladores"));
            preguntas.Add(new Pregunta("¿Se ha realizado los exámenes para manipuladores de alimentos (KOH de uñas, Frotis de garganta y coprológico)?", "Manipuladores"));
            preguntas.Add(new Pregunta("En caso afirmativo, ¿Hace cuánto?", "Manipuladores"));
            preguntas.Add(new Pregunta("¿Considera que manipular alimentos con las uñas largas y pintadas puede ser inapropiado?", "Manipuladores"));
            preguntas.Add(new Pregunta("¿Considera que el uso de prendas puede afectar negativamente el proceso de manipulación de alimentos?", "Manipuladores"));
            preguntas.Add(new Pregunta("¿Utiliza bata,  tapa bocas y malla para cubrir el cabello mientras manipula alimentos?", "Manipuladores"));
            preguntas.Add(new Pregunta("¿Manipula alimentos y dinero al mismo tiempo?", "Manipuladores"));
            preguntas.Add(new Pregunta("¿Con qué frecuencia se lava las manos para manipular alimentos?", "Manipuladores"));
            preguntas.Add(new Pregunta("Al momento de preparar alimentos, ¿retira sus prendas?", "Manipuladores"));
        }
        private void CrearPreguntaListaDeChequeo(IList<Pregunta> preguntas)
        {
            preguntas.Add(new Pregunta("El personal manipulador tiene certificado medico", "Lista de chequeo"));
            preguntas.Add(new Pregunta("Los manipuladores acreditan cursos en higiene y protección de alimentos", "Lista de chequeo"));
            preguntas.Add(new Pregunta("Los empleados que manipulan alimentos utilizan uniformes adecuados de color claro, limpio y calzado cerrado", "Lista de chequeo"));
            preguntas.Add(new Pregunta("Las manos de los trabajadores se encuentran limpias, son joyas, uñas cortas y sin esmalte", "Lista de chequeo"));
            preguntas.Add(new Pregunta("Los manipuladores evitan practicas antihigiénicas tales como comer, fumar, toser, escupir o rascarse.", "Lista de chequeo"));
            preguntas.Add(new Pregunta("Los manipuladores se lavan y se desinfectan las manos hasta el codo , cada vez que sea necesario", "Lista de chequeo"));
            preguntas.Add(new Pregunta("Se evidencian equipos e implementos de seguridad en funcionamiento y ubicados correctamente (extintores, campanas extractoras, barandas, etc.)", "Lista de chequeo"));
            preguntas.Add(new Pregunta("El establecimiento dispone de botiquín bien dotado y ubicado en un lugar visible", "Lista de chequeo"));
            preguntas.Add(new Pregunta("Se cuenta con equipos de protección personal en función de las actividades realizadas ej: guantes de malla metálica, chaquetas, etc.", "Lista de chequeo"));
        }
    }
}