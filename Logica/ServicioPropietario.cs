using System;
using Entidad;
using Datos;
using System.Linq;
using System.Collections.Generic;

namespace Logica
{
    public class ServicioPropietario
    {
        private readonly MicroAlParqueContext _contexto;

        public ServicioPropietario(MicroAlParqueContext contexto)
        {
            _contexto = contexto;
        }

        public Peticion<Propietario> Guardar(Propietario Propietario)
        {
            Peticion<Propietario> respuesta = new Peticion<Propietario>(Propietario);
            try
            {
                respuesta = BuscarPorIdentificacion(Propietario.Identificacion);
                respuesta = (respuesta.Error) ?
                    new Peticion<Propietario>(Propietario, "Datos guardados correctamente", false) :
                    new Peticion<Propietario>(null, "El Propietario que intentar guardar ya se encuentra registrado", true);
                if (!respuesta.Error)
                {
                    _contexto.Propietarios.Add(respuesta.Elemento);
                    _contexto.SaveChanges();
                }
            }
            catch (Exception E)
            {
                respuesta = new Peticion<Propietario>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
        public Peticion<Propietario> BuscarPorIdentificacion(string Identificacion)
        {
            Peticion<Propietario> respuesta = new Peticion<Propietario>(new Propietario());
            try
            {
                respuesta.Elemento = _contexto.Propietarios.Find(Identificacion);
                respuesta = (respuesta.Elemento == null) ?
                    new Peticion<Propietario>(null, "El Propietario con Identificacion {Identificacion} no se encuentra registrado", true) :
                    new Peticion<Propietario>(respuesta.Elemento, "Propietario encontrado", false);
            }
            catch (Exception E)
            {
                respuesta = new Peticion<Propietario>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
        public PeticionConsulta<Propietario> ConsultarTodos()
        {
            PeticionConsulta<Propietario> respuesta = new PeticionConsulta<Propietario>();
            try
            {
                respuesta.Elementos = _contexto.Propietarios.ToList();
                respuesta = (respuesta.Elementos.Count == 0) ?
                    new PeticionConsulta<Propietario>(new List<Propietario>(), "No se han encontrado Propietarios registrados", true) :
                    new PeticionConsulta<Propietario>(respuesta.Elementos.ToList(), "Consulta realizada con éxito", false);
            }
            catch (Exception e)
            {
                respuesta = new PeticionConsulta<Propietario>(new List<Propietario>(), "Error: " + e.Message, true);
            }
            return respuesta;
        }
    }
}