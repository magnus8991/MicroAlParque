using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroAlParque.Models
{
    public class ListaChequeoInputModel
    {
        public IList<RespuestaChequeo> RespuestaChequeos { get; set; }

        public string SedeId { get; set; }
        public ListaChequeoInputModel() {
            RespuestaChequeos = new List<RespuestaChequeo>();
        }
    }

    public class ListaChequeoViewModel : ListaChequeoInputModel
    {

        public int ListaChequeoId { get; set; }
        public float PorcentajeCumplimiento {  get; set;  }
        public DateTime Fecha { get; set; }
        public ListaChequeoViewModel() { }
        public ListaChequeoViewModel(ListaChequeo listaChequeo)
        {
            ListaChequeoId = listaChequeo.ListaChequeoId;
            SedeId = listaChequeo.SedeId;
            RespuestaChequeos = listaChequeo.RespuestaChequeos;
            PorcentajeCumplimiento = listaChequeo.PorcentajeCumplimiento;
            Fecha = listaChequeo.Fecha;
        }
    }
}