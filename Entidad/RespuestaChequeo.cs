using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidad
{
    public class RespuestaChequeo 
    {
        [Key]
        public int RespuestaChequeoId { get; set; }
        [StringLength(200)]
        public string ContenidoRespuesta { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Puntaje { get; set; }
        public int PreguntaId { get; set; }
        public RespuestaChequeo() { }
    }
}
