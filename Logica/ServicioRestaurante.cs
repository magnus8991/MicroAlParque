using System;
using Entidad;
using Datos;
using System.Linq;
using System.Collections.Generic;

namespace Logica
{
    public class ServicioRestaurante
    {
        private readonly MicroAlParqueContext _contexto;

        public ServicioRestaurante(MicroAlParqueContext contexto)
        {
            _contexto = contexto;
        }

        public Peticion<Restaurante> Guardar(Restaurante restaurante)
        {
            Peticion<Restaurante> respuesta = new Peticion<Restaurante>(restaurante);
            try
            {
                respuesta = BuscarPorIdRestaurante(restaurante.NIT);
                respuesta = (respuesta.Error) ?
                    new Peticion<Restaurante>(restaurante, "Datos guardados correctamente", false) :
                    new Peticion<Restaurante>(null, "El restaurante que intentar guardar ya se encuentra registrado", true);
                if (!respuesta.Error)
                {
                    _contexto.Restaurantes.Add(respuesta.Elemento);
                    _contexto.SaveChanges();
                }
            }
            catch (Exception E)
            {
                respuesta = new Peticion<Restaurante>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
        public Peticion<Restaurante> BuscarPorIdRestaurante(string IdRestaurante)
        {
            Peticion<Restaurante> respuesta = new Peticion<Restaurante>(new Restaurante());
            try
            {
                respuesta.Elemento = _contexto.Restaurantes.Find(IdRestaurante);
                respuesta = (respuesta.Elemento == null) ?
                    new Peticion<Restaurante>(null, "El restaurante con ID {IdRestaurante} no se encuentra registrado", true) :
                    new Peticion<Restaurante>(respuesta.Elemento, "Restaurante encontrado", false);
            }
            catch (Exception E)
            {
                respuesta = new Peticion<Restaurante>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
        public PeticionConsulta<Restaurante> ConsultarTodos()
        {
            PeticionConsulta<Restaurante> respuesta = new PeticionConsulta<Restaurante>();
            try
            {
                respuesta.Elementos = _contexto.Restaurantes.ToList();
                respuesta = (respuesta.Elementos.Count == 0) ?
                    new PeticionConsulta<Restaurante>(new List<Restaurante>(), "No se han encontrado restaurantes registrados", true) :
                    new PeticionConsulta<Restaurante>(respuesta.Elementos.ToList(), "Consulta realizada con éxito", false);
            }
            catch (Exception e)
            {
                respuesta = new PeticionConsulta<Restaurante>(new List<Restaurante>(), "Error: " + e.Message, true);
            }
            return respuesta;
        }
    }
}