using System;
using Entidad;
using Datos;
using System.Linq;
using System.Collections.Generic;

namespace Logica
{
    public class ServicioPersona
    {
        private readonly MicroAlParqueContext _contexto;

        public ServicioPersona(MicroAlParqueContext contexto)
        {
            _contexto = contexto;
        }

        public Peticion<Persona> Guardar(Persona persona)
        {
            Peticion<Persona> respuesta = new Peticion<Persona>(persona);
            try
            {
                respuesta = BuscarPorIdentificacion(persona.Identificacion);
                respuesta = (respuesta.Error) ?
                    new Peticion<Persona>(persona, "Datos guardados correctamente", false) :
                    new Peticion<Persona>(null, "La persona que intentar guardar ya se encuentra registrada", true);
                if (!respuesta.Error)
                {
                    _contexto.Personas.Add(respuesta.Elemento);
                    _contexto.SaveChanges();
                }
            }
            catch (Exception E)
            {
                respuesta = new Peticion<Persona>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
        public Peticion<Persona> BuscarPorIdentificacion(string Identificacion)
        {
            Peticion<Persona> respuesta = new Peticion<Persona>(new Persona());
            try
            {
                respuesta.Elemento = _contexto.Personas.Find(Identificacion);
                respuesta = (respuesta.Elemento == null) ?
                    new Peticion<Persona>(null, "La persona con Identificacion {Identificacion} no se encuentra registrada", true) :
                    new Peticion<Persona>(respuesta.Elemento, "Persona encontrada", false);
            }
            catch (Exception E)
            {
                respuesta = new Peticion<Persona>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
        public PeticionConsulta<Persona> ConsultarTodos()
        {
            PeticionConsulta<Persona> respuesta = new PeticionConsulta<Persona>();
            try
            {
                respuesta.Elementos = _contexto.Personas.ToList();
                respuesta = (respuesta.Elementos.Count == 0) ?
                    new PeticionConsulta<Persona>(new List<Persona>(), "No se han encontrado personas registradas", true) :
                    new PeticionConsulta<Persona>(respuesta.Elementos.ToList(), "Consulta realizada con éxito", false);
            }
            catch (Exception e)
            {
                respuesta = new PeticionConsulta<Persona>(new List<Persona>(), "Error: " + e.Message, true);
            }
            return respuesta;
        }
    }
}