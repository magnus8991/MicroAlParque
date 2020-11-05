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
        [StringLength(100)]
        public string ContenidoRespuesta { get; set; }
        public int PreguntaId { get; set; }
        public int ManipuladorDeAlimentoId { get; set; }

    }
}
