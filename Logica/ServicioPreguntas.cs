using System;
using Entidad;
using Datos;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class ServicioPreguntas
    {
        private readonly MicroAlParqueContext _contexto;

        public ServicioPreguntas(MicroAlParqueContext contexto)
        {
            _contexto = contexto;
        }

        public string Guardar(Pregunta pregunta)
        {
            try
            {
                    _contexto.Preguntas.Add(pregunta);
                    _contexto.SaveChanges();
                    return "Datos guardados correctamente";
            }
            catch (Exception E)
            {
                return "Error de la aplicación: " + E.Message;
            }
        }
        public PeticionConsulta<Pregunta> ConsultarPorPertenencia(string PerteneceA)
        {
            PeticionConsulta<Pregunta> respuesta = new PeticionConsulta<Pregunta>();
            try
            {
                respuesta.Elementos = _contexto.Preguntas.Where(p => p.PerteneceA == PerteneceA).ToList();
                respuesta = (respuesta.Elementos.Count == 0) ?
                    new PeticionConsulta<Pregunta>(new List<Pregunta>(), "No se han encontradopreguntas registradas", true) :
                    new PeticionConsulta<Pregunta>(respuesta.Elementos.ToList(), "Consulta realizada con éxito", false);
            }
            catch (Exception e)
            {
                respuesta = new PeticionConsulta<Pregunta>(new List<Pregunta>(), "Error: " + e.Message, true);
            }
            return respuesta;
        }

        public PeticionConsulta<Pregunta> ConsultarTodos()
        {
            PeticionConsulta<Pregunta> respuesta = new PeticionConsulta<Pregunta>();
            try
            {
                respuesta.Elementos = _contexto.Preguntas.ToList();
                respuesta = (respuesta.Elementos.Count == 0) ?
                    new PeticionConsulta<Pregunta>(new List<Pregunta>(), "No se han encontradopreguntas registradas", true) :
                    new PeticionConsulta<Pregunta>(respuesta.Elementos.ToList(), "Consulta realizada con éxito", false);
            }
            catch (Exception e)
            {
                respuesta = new PeticionConsulta<Pregunta>(new List<Pregunta>(), "Error: " + e.Message, true);
            }
            return respuesta;
        }
    }
}
