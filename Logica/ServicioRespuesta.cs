using System;
using Entidad;
using Datos;
using System.Linq;
using System.Collections.Generic;

namespace Logica
{
    public class ServicioRespuesta
    {
        private readonly MicroAlParqueContext _contexto;

        public ServicioRespuesta(MicroAlParqueContext contexto)
        {
            _contexto = contexto;
        }

        public Peticion<Respuesta> Guardar(Respuesta respuestaDoc)
        {
            Peticion<Respuesta> respuesta = new Peticion<Respuesta>(respuestaDoc);
            try
            {
                respuesta = BuscarPorIdRespuesta(respuestaDoc.RespuestaId);
                respuesta = (respuesta.Error) ?
                    new Peticion<Respuesta>(respuestaDoc, "Datos guardados correctamente", false) :
                    new Peticion<Respuesta>(null, "La respuesta que intentar guardar ya se encuentra registrada", true);
                if (!respuesta.Error)
                {
                    _contexto.Respuestas.Add(respuesta.Elemento);
                    _contexto.SaveChanges();
                }
            }
            catch (Exception E)
            {
                respuesta = new Peticion<Respuesta>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
        public Peticion<Respuesta> BuscarPorIdRespuesta(int ResuestaId)
        {
            Peticion<Respuesta> respuesta = new Peticion<Respuesta>(new Respuesta());
            try
            {
                respuesta.Elemento = _contexto.Respuestas.Find(ResuestaId);
                respuesta = (respuesta.Elemento == null) ?
                    new Peticion<Respuesta>(null, "La respuesta con ID {RespuestaId} no se encuentra registrada", true) :
                    new Peticion<Respuesta>(respuesta.Elemento, "Lista encontrada", false);
            }
            catch (Exception E)
            {
                respuesta = new Peticion<Respuesta>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
        public PeticionConsulta<Respuesta> ConsultarPorManipulador(string Identificacion)
        {
            PeticionConsulta<Respuesta> respuesta = new PeticionConsulta<Respuesta>();
            try
            {
                respuesta.Elementos = _contexto.Respuestas.Where(r => r.Identificacion == Identificacion).ToList();
                respuesta = (respuesta.Elementos.Count == 0) ?
                    new PeticionConsulta<Respuesta>(new List<Respuesta>(), "No se han encontrado respuestas de chequeo registradas", true) :
                    new PeticionConsulta<Respuesta>(respuesta.Elementos.ToList(), "Consulta realizada con éxito", false);
            }
            catch (Exception e)
            {
                respuesta = new PeticionConsulta<Respuesta>(new List<Respuesta>(), "Error: " + e.Message, true);
            }
            return respuesta;
        }
        public PeticionConsulta<Respuesta> ConsultarTodos()
        {
            PeticionConsulta<Respuesta> respuesta = new PeticionConsulta<Respuesta>();
            try
            {
                respuesta.Elementos = _contexto.Respuestas.ToList();
                respuesta = (respuesta.Elementos.Count == 0) ?
                    new PeticionConsulta<Respuesta>(new List<Respuesta>(), "No se han encontrado respuestas de chequeo registradas", true) :
                    new PeticionConsulta<Respuesta>(respuesta.Elementos.ToList(), "Consulta realizada con éxito", false);
            }
            catch (Exception e)
            {
                respuesta = new PeticionConsulta<Respuesta>(new List<Respuesta>(), "Error: " + e.Message, true);
            }
            return respuesta;
        }

        public PeticionConsulta<Respuesta> ModificarRespuestas(IList<Respuesta> respuestas)
        {
            PeticionConsulta<Respuesta> respuesta = new PeticionConsulta<Respuesta>();
            foreach (var item in respuestas)
            {
                Peticion<Respuesta> respuestaModificacion = Modificar(item);
                if (respuestaModificacion.Error) return new PeticionConsulta<Respuesta>(new List<Respuesta>(), 
                    respuestaModificacion.Mensaje, true);
            }
            _contexto.SaveChanges();
            respuesta = new PeticionConsulta<Respuesta>(respuestas,"Respuestas actualizadas con éxito",false);
            return respuesta;
        }
        public Peticion<Respuesta> Modificar(Respuesta respuestaDoc)
        {
            Peticion<Respuesta> respuesta = new Peticion<Respuesta>(respuestaDoc);
            try
            {
                respuesta = BuscarPorIdRespuesta(respuestaDoc.RespuestaId);
                respuesta = (!respuesta.Error) ?
                    new Peticion<Respuesta>(respuesta.Elemento, "Datos actualizados correctamente", false) :
                    new Peticion<Respuesta>(null, "La respuesta que intentar actualizar no se encuentra registrada", true);
                if (!respuesta.Error)
                {
                    respuesta.Elemento.ContenidoRespuesta = respuestaDoc.ContenidoRespuesta;
                    _contexto.Respuestas.Update(respuesta.Elemento);
                }
            }
            catch (Exception E)
            {
                respuesta = new Peticion<Respuesta>(null, "Error de la aplicación: " + E.Message, true);
            }
            return respuesta;
        }
    }
}
