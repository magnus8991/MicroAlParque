using System;
using Entidad;
using Datos;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    namespace Logica
    {
        public class ServicioPreguntas
        {
            private readonly MicroAlParqueContext _contexto;

            public ServicioPreguntas(MicroAlParqueContext contexto)
            {
                _contexto = contexto;
            }

            public Peticion<Pregunta> Guardar(Pregunta pregunta)
            {
                Peticion<Pregunta> respuesta = new Peticion<Pregunta>(pregunta);
                try
                {
                    respuesta = BuscarPorIdPregunta(pregunta.PreguntaId);
                    respuesta = (respuesta.Error) ?
                        new Peticion<Pregunta>(pregunta, "Datos guardados correctamente", false) :
                        new Peticion<Pregunta>(null, "La lista que intentar guardar ya se encuentra registrada", true);
                    if (!respuesta.Error)
                    {
                        _contexto.Preguntas.Add(respuesta.Elemento);
                        _contexto.SaveChanges();
                    }
                }
                catch (Exception E)
                {
                    respuesta = new Peticion<Pregunta>(null, "Error de la aplicación: " + E.Message, true);
                }
                return respuesta;
            }
            public Peticion<Pregunta> BuscarPorIdPregunta(int IdPregunta)
            {
                Peticion<Pregunta> respuesta = new Peticion<Pregunta>(new Pregunta());
                try
                {
                    respuesta.Elemento = _contexto.Preguntas.Find(IdPregunta);
                    respuesta = (respuesta.Elemento == null) ?
                        new Peticion<Pregunta>(null, "La pregunta con ID {IdPregunta} no se encuentra registrada", true) :
                        new Peticion<Pregunta>(respuesta.Elemento, "Pregunta encontrada", false);
                }
                catch (Exception E)
                {
                    respuesta = new Peticion<Pregunta>(null, "Error de la aplicación: " + E.Message, true);
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
}
