using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidad
{
    public class Respuesta
    {
        [Key]
        public int RespuestaId { get; set; }
        [StringLength(200)]
        public string ContenidoRespuesta { get; set; }
        public int PreguntaId { get; set; }
        public string Identificacion { get; set; }
        public Respuesta() { }

    }
}
