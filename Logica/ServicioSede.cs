using System;
using Entidad;
using Datos;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class ServicioSede
    {
        private readonly MicroAlParqueContext _contexto;

        public ServicioSede(MicroAlParqueContext contexto)
        {
            _contexto = contexto;
        }

        public Peticion<Sede> Guardar(Sede Sede)
        {
            Peticion<Sede> respuesta = new Peticion<Sede>(Sede);
            try
            {
                respuesta = BuscarPorIdRestaurante(Sede.Nombre,Sede.RestauranteId);
                respuesta = (respuesta.Error) ?
                    new Peticion<Sede>(Sede, "Datos guardados correctamente", false) :
                    new Peticion<Sede>(null, "La Sede que intentar guardar ya se encuentra registrada", true);
                if (!respuesta.Error)
                {
                    _contexto.Sedes.Add(respuesta.Elemento);
                    _contexto.SaveChanges();
                }
            }
            catch (Exception E)
            {
                respuesta = new Peticion<Sede>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
        public Peticion<Sede> BuscarPorIdRestaurante(string NombreSede, string RestauranteId)
        {
            Peticion<Sede> respuesta = new Peticion<Sede>(new Sede());
            try
            {
                respuesta.Elemento = _contexto.Sedes
                .Where(s => s.Nombre == NombreSede && s.RestauranteId == RestauranteId).FirstOrDefault();
                respuesta = (respuesta.Elemento == null) ?
                    new Peticion<Sede>(null, $"La sede con nombre {NombreSede} no se encuentra registrada", true) :
                    new Peticion<Sede>(respuesta.Elemento, "Sede encontrada", false);
            }
            catch (Exception E)
            {
                respuesta = new Peticion<Sede>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
        public PeticionConsulta<Sede> ConsultarTodos(string RestauranteId)
        {
            PeticionConsulta<Sede> respuesta = new PeticionConsulta<Sede>();
            try
            {
                respuesta.Elementos = _contexto.Sedes.Where(s => s.RestauranteId == RestauranteId).ToList();
                respuesta = (respuesta.Elementos.Count == 0) ?
                    new PeticionConsulta<Sede>(new List<Sede>(), "No se han encontrado Sedes registradas", true) :
                    new PeticionConsulta<Sede>(respuesta.Elementos.ToList(), "Consulta realizada con éxito", false);
            }
            catch (Exception e)
            {
                respuesta = new PeticionConsulta<Sede>(new List<Sede>(), "Error: " + e.Message, true);
            }
            return respuesta;
        }

        public Peticion<Sede> BuscarPorIdSede(int SedeId)
        {
            Peticion<Sede> respuesta = new Peticion<Sede>(new Sede());
            try
            {
                respuesta.Elemento = _contexto.Sedes
                .Where(s => s.SedeId == SedeId).FirstOrDefault();
                respuesta = (respuesta.Elemento == null) ?
                    new Peticion<Sede>(null, $"La sede con ID {SedeId} no se encuentra registrada", true) :
                    new Peticion<Sede>(respuesta.Elemento, "Sede encontrada", false);
            }
            catch (Exception E)
            {
                respuesta = new Peticion<Sede>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }

        public Peticion<Sede> Modificar(Sede Sede, int SedeId)
        {
            Peticion<Sede> respuesta = new Peticion<Sede>(Sede);
            try
            {
                respuesta = BuscarPorIdSede(SedeId);
                respuesta = (!respuesta.Error) ?
                    new Peticion<Sede>(respuesta.Elemento, "Datos actualizados correctamente", false) :
                    new Peticion<Sede>(null, "La Sede que intentar modificar no se encuentra registrada", true);
                if (!respuesta.Error)
                {
                    respuesta.Elemento.Nombre = Sede.Nombre;
                    respuesta.Elemento.Direccion = Sede.Direccion;
                    respuesta.Elemento.Telefono = Sede.Telefono;
                    _contexto.Sedes.Update(respuesta.Elemento);
                    _contexto.SaveChanges();
                }
            }
            catch (Exception E)
            {
                respuesta = new Peticion<Sede>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
    }
}