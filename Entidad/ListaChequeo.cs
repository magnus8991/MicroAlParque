using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidad
{
    public class ListaChequeo
    {
        [Key]
        public int ListaChequeoId { get; set; }
        List<RespuestaChequeo> RespuestaChequeos { get; set; }
    }
}
