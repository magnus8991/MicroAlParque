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
        public string RestauranteId { get; set; }
        public ListaChequeoInputModel() {
            RespuestaChequeos = new List<RespuestaChequeo>();
        }
    }

    public class ListaChequeoViewModel : ListaChequeoInputModel
    {
        public int ListaChequeoId { get; set; }
        public float PorcentajeCumplimiento {  get; set;  }
        public ListaChequeoViewModel() { }
        public ListaChequeoViewModel(ListaChequeo listaChequeo)
        {
            ListaChequeoId = listaChequeo.ListaChequeoId;
            RestauranteId = listaChequeo.RestauranteId;
            RespuestaChequeos = listaChequeo.RespuestaChequeos;
            PorcentajeCumplimiento = listaChequeo.PorcentajeCumplimiento;
        }
    }
}