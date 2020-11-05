using System;
using Entidad;
using Datos;
using System.Linq;
using System.Collections.Generic;

namespace Logica
{
    namespace Logica
    {
        public class ServicioManipuladorDeAlimento
        {
            private readonly MicroAlParqueContext _contexto;

            public ServicioManipuladorDeAlimento(MicroAlParqueContext contexto)
            {
                _contexto = contexto;
            }

            public Peticion<ManipuladorDeAlimento> Guardar(ManipuladorDeAlimento manipulador)
            {
                Peticion<ManipuladorDeAlimento> respuesta = new Peticion<ManipuladorDeAlimento>(manipulador);
                try
                {
                    respuesta = BuscarPorIdentificacion(manipulador.Identificacion);
                    respuesta = (respuesta.Error) ?
                        new Peticion<ManipuladorDeAlimento>(manipulador, "Datos guardados correctamente", false) :
                        new Peticion<ManipuladorDeAlimento>(null, "El manipulador que intentar guardar ya se encuentra registrado", true);
                    if (!respuesta.Error)
                    {
                        _contexto.Manipuladores.Add(respuesta.Elemento);
                        _contexto.SaveChanges();
                    }
                }
                catch (Exception E)
                {
                    respuesta = new Peticion<ManipuladorDeAlimento>(null, "Error de la aplicación: " + E.Message, true);
                }
                return respuesta;
            }
            public Peticion<ManipuladorDeAlimento> BuscarPorIdentificacion(string Identificacion)
            {
                Peticion<ManipuladorDeAlimento> respuesta = new Peticion<ManipuladorDeAlimento>(new ManipuladorDeAlimento());
                try
                {
                    respuesta.Elemento = _contexto.Manipuladores.Find(Identificacion);
                    respuesta = (respuesta.Elemento == null) ?
                        new Peticion<ManipuladorDeAlimento>(null, "El manipulador con Identificacion {Identificacion} no se encuentra registrado", true) :
                        new Peticion<ManipuladorDeAlimento>(respuesta.Elemento, "Manipulador encontrado", false);
                }
                catch (Exception E)
                {
                    respuesta = new Peticion<ManipuladorDeAlimento>(null, "Error de la aplicación: " + E.Message, true);
                }
                return respuesta;
            }
            public PeticionConsulta<ManipuladorDeAlimento> ConsultarTodos()
            {
                PeticionConsulta<ManipuladorDeAlimento> respuesta = new PeticionConsulta<ManipuladorDeAlimento>();
                try
                {
                    respuesta.Elementos = _contexto.Manipuladores.ToList();
                    respuesta = (respuesta.Elementos.Count == 0) ?
                        new PeticionConsulta<ManipuladorDeAlimento>(new List<ManipuladorDeAlimento>(), "No se han encontrado manipuladores registrados", true) :
                        new PeticionConsulta<ManipuladorDeAlimento>(respuesta.Elementos.ToList(), "Consulta realizada con éxito", false);
                }
                catch (Exception e)
                {
                    respuesta = new PeticionConsulta<ManipuladorDeAlimento>(new List<ManipuladorDeAlimento>(), "Error: " + e.Message, true);
                }
                return respuesta;
            }
        }
    }
}
