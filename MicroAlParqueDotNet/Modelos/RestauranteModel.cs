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
        public string Direccion { get; set; }
        public string Sede { get; set; }
        public int Telefono { get; set; }
        public string IdPropietario { get; set; }

        public RestauranteInputModel() { }
    }

    public class RestauranteViewModel : RestauranteInputModel
    {
        public RestauranteViewModel() { }
        public RestauranteViewModel(Restaurante restaurante)
        {
            NIT = restaurante.NIT;
            Nombre = restaurante.Nombre;
            Direccion = restaurante.Direccion;
            Sede = restaurante.Sede;
            Telefono = restaurante.Telefono;
            IdPropietario = restaurante.IdPropietario;
        }
    }
}