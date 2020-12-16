using System;
using Entidad;
using Datos;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class ServicioListaChequeo
    {
        private readonly MicroAlParqueContext _contexto;

        public ServicioListaChequeo(MicroAlParqueContext contexto)
        {
            _contexto = contexto;
        }

        public Peticion<ListaChequeo> Guardar(ListaChequeo listaChequeo)
        {
            Peticion<ListaChequeo> respuesta = new Peticion<ListaChequeo>(listaChequeo);
            try
            {
                respuesta = BuscarPorIdListaChequeo(listaChequeo.ListaChequeoId);
                respuesta = (respuesta.Error) ?
                    new Peticion<ListaChequeo>(listaChequeo, "Datos guardados correctamente", false) :
                    new Peticion<ListaChequeo>(null, "La lista que intentar guardar ya se encuentra registrada", true);
                if (!respuesta.Error)
                {
                    _contexto.ListasDeChequeo.Add(respuesta.Elemento);
                    _contexto.SaveChanges();
                }
            }
            catch (Exception E)
            {
                respuesta = new Peticion<ListaChequeo>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
        public Peticion<ListaChequeo> BuscarPorIdListaChequeo(int IdListaChequeo)
        {
            Peticion<ListaChequeo> respuesta = new Peticion<ListaChequeo>(new ListaChequeo());
            try
            {
                respuesta.Elemento = _contexto.ListasDeChequeo.Find(IdListaChequeo);
                respuesta = (respuesta.Elemento == null) ?
                    new Peticion<ListaChequeo>(null, "La lista con ID {IdListaChequeo} no se encuentra registrada", true) :
                    new Peticion<ListaChequeo>(respuesta.Elemento, "Lista encontrada", false);
            }
            catch (Exception E)
            {
                respuesta = new Peticion<ListaChequeo>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
        public PeticionConsulta<ListaChequeo> ConsultarTodos()
        {
            PeticionConsulta<ListaChequeo> respuesta = new PeticionConsulta<ListaChequeo>();
            try
            {
                respuesta.Elementos = _contexto.ListasDeChequeo.Include(lc => lc.RespuestaChequeos).ToList();
                respuesta = (respuesta.Elementos.Count == 0) ?
                    new PeticionConsulta<ListaChequeo>(new List<ListaChequeo>(), "No se han encontrado listas de chequeo registradas", true) :
                    new PeticionConsulta<ListaChequeo>(respuesta.Elementos.ToList(), "Consulta realizada con éxito", false);
            }
            catch (Exception e)
            {
                respuesta = new PeticionConsulta<ListaChequeo>(new List<ListaChequeo>(), "Error: " + e.Message, true);
            }
            return respuesta;
        }
        public PeticionConsulta<ListaChequeo> ConsultarPorSede(int nit)
        {
            PeticionConsulta<ListaChequeo> respuesta = new PeticionConsulta<ListaChequeo>();
            try
            {
                respuesta.Elementos = _contexto.ListasDeChequeo.Where(l => l.SedeId == nit).Include(lc => lc.RespuestaChequeos).ToList();
                respuesta = (respuesta.Elementos.Count == 0) ?
                    new PeticionConsulta<ListaChequeo>(new List<ListaChequeo>(), "No se han encontrado listas de chequeo registradas", true) :
                    new PeticionConsulta<ListaChequeo>(respuesta.Elementos.ToList(), "Consulta realizada con éxito", false);
            }
            catch (Exception e)
            {
                respuesta = new PeticionConsulta<ListaChequeo>(new List<ListaChequeo>(), "Error: " + e.Message, true);
            }
            return respuesta;
        }
    }
}
