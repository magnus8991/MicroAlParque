using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroAlParque.Models
{
    public class SedeInputModel
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string RestauranteId { get; set; }

        public SedeInputModel() { }
    }

    public class SedeViewModel : SedeInputModel
    {
        public int SedeId { get; set; }
        public SedeViewModel() { }
        public SedeViewModel(Sede Sede)
        {
            SedeId = Sede.SedeId;
            Nombre = Sede.Nombre;
            Direccion = Sede.Direccion;
            Telefono = Sede.Telefono;
            RestauranteId = Sede.RestauranteId;
        }
    }
}