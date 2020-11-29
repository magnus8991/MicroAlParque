using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroAlParque.Models
{
    public class RestauranteInputModel
    {
        public string NIT { get; set; }
        public string Nombre { get; set; }
        public Propietario Propietario { get; set; }

        public RestauranteInputModel() { }
    }

    public class RestauranteViewModel : RestauranteInputModel
    {
        public RestauranteViewModel() { }
        public RestauranteViewModel(Restaurante restaurante)
        {
            NIT = restaurante.NIT;
            Nombre = restaurante.Nombre;
            Propietario = restaurante.Propietario;
        }
    }
}