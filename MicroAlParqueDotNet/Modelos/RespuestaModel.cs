using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaArias.Models
{
    public class RespuestaInputModel
    {
        public string ContenidoRespuesta { get; set; }
        public int PreguntaId { get; set; }
        public string Identificacion { get; set; }

        public RespuestaInputModel() { }
    }

    public class RespuestaViewModel : RespuestaInputModel
    {
        public int RespuestaId { get; set; }
        public RespuestaViewModel() { }
        public RespuestaViewModel(Respuesta respuesta)
        {
            RespuestaId = respuesta.RespuestaId;
            ContenidoRespuesta = respuesta.ContenidoRespuesta;
            PreguntaId = respuesta.PreguntaId;
            Identificacion = respuesta.Identificacion;
        }
    }
}