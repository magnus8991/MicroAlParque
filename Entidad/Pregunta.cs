using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidad
{
    public class Pregunta
    {
        [Key]
        public int PreguntaId { get; set; }
        [StringLength(190)]
        public string Enunciado { get; set; }
    }
}
