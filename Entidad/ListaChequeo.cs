using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace Entidad
{
    public class ListaChequeo
    {
        [Key]
        public int ListaChequeoId { get; set; }
        public DateTime Fecha { get; set; }
        public IList<RespuestaChequeo> RespuestaChequeos { get; set; }
        public int SedeId { get; set; }
        public ListaChequeo() {
            RespuestaChequeos = new List<RespuestaChequeo>();
        }
        public float PorcentajeCumplimiento
        {
            get
            {
                int cantidadRespuesta = RespuestaChequeos.Count();
                if(cantidadRespuesta == 0)
                {
                    return -1;
                }
                int cantidadRespuestasCumplidas = RespuestaChequeos.Where(r  => r.ContenidoRespuesta == "Cumple").Count();
                return (cantidadRespuestasCumplidas * 100)/cantidadRespuesta;
            }
        }
    }
}
