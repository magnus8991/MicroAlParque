using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroAlParque.Models
{
    public class SedeInputModel
    {
        [Required]
        [MaxLength(20, ErrorMessage = "El nombre debe tener entre 3 y 20 caracteres"), MinLength(3,
            ErrorMessage = "El nombre debe tener entre 3 y 20 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "La direccion debe tener entre 5 y 30 caracteres"), MinLength(5,
            ErrorMessage = "La direccion debe tener entre 5 y 30 caracteres")]
        public string Direccion { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "El telefono debe tener entre 7 y 10 digitos"), MinLength(7, 
            ErrorMessage = "El telefono debe tener  entre 7 y 10 digitos")]
        public string Telefono { get; set; }
        [Required]
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