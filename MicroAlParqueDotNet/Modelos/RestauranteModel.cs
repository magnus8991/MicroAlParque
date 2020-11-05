using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaArias.Models
{
    public class RestauranteInputModel
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Identificacion { get; set; }

        public RestauranteInputModel() { }
    }

    public class RestauranteViewModel : RestauranteInputModel
    {
        public int IdRestaurante { get; set; }

        public RestauranteViewModel() { }
        public RestauranteViewModel(Restaurante restaurante)
        {
            IdRestaurante = restaurante.IdRestaurante;
            Nombre = restaurante.Nombre;
            Direccion = restaurante.Direccion;
            Identificacion = restaurante.Identificacion;
        }
    }
}