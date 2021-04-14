using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MicroAlParque.Models
{
    public class RestauranteInputModel
    {

        [MaxLength(15, ErrorMessage = "El NIT debe tener entre 6 y 15 caracteres"), MinLength(6,
            ErrorMessage = "El NIT debe tener entre 6 y 15 caracteres")]
        [Required]
        public string NIT { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "El nombre del restaurante debe tener entre 3 y 20 caracteres"), MinLength(3,
            ErrorMessage = "El nombre del restaurante debe tener entre 3 y 20 caracteres")]
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