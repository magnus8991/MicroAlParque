using System;
using Entidad;
using Datos;
using System.Linq;
using System.Collections.Generic;

namespace Logica
{
    public class ServicioUsuario
    {
        private readonly MicroAlParqueContext _contexto;

        public ServicioUsuario(MicroAlParqueContext contexto)
        {
            _contexto = contexto;
        }

        public Peticion<Usuario> Guardar(Usuario usuario)
        {
            Peticion<Usuario> respuesta = new Peticion<Usuario>(usuario);
            try
            {
                respuesta = BuscarPorIdentificacion(usuario.Identificacion);
                respuesta = (respuesta.Error) ?
                    new Peticion<Usuario>(usuario, "Datos guardados correctamente", false) :
                    new Peticion<Usuario>(null, "El usuario que intentar guardar ya se encuentra registrado", true);
                if (!respuesta.Error)
                {
                    _contexto.Usuarios.Add(respuesta.Elemento);
                    _contexto.SaveChanges();
                }
            }
            catch (Exception E)
            {
                respuesta = new Peticion<Usuario>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
        public Peticion<Usuario> BuscarPorIdentificacion(string Identificacion)
        {
            Peticion<Usuario> respuesta = new Peticion<Usuario>(new Usuario());
            try
            {
                respuesta.Elemento = _contexto.Usuarios.Find(Identificacion);
                respuesta = (respuesta.Elemento == null) ?
                    new Peticion<Usuario>(null, "El usuario con Identificacion {Identificacion} no se encuentra registrado", true) :
                    new Peticion<Usuario>(respuesta.Elemento, "Usuario encontrado", false);
            }
            catch (Exception E)
            {
                respuesta = new Peticion<Usuario>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
        public PeticionConsulta<Usuario> ConsultarTodos()
        {
            PeticionConsulta<Usuario> respuesta = new PeticionConsulta<Usuario>();
            try
            {
                respuesta.Elementos = _contexto.Usuarios.ToList();
                respuesta = (respuesta.Elementos.Count == 0) ?
                    new PeticionConsulta<Usuario>(new List<Usuario>(), "No se han encontrado usuarios registrados", true) :
                    new PeticionConsulta<Usuario>(respuesta.Elementos.ToList(), "Consulta realizada con éxito", false);
            }
            catch (Exception e)
            {
                respuesta = new PeticionConsulta<Usuario>(new List<Usuario>(), "Error: " + e.Message, true);
            }
            return respuesta;
        }
    }
}