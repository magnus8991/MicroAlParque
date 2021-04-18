using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroAlParque.Models
{
    public class ManipuladorInputModel
    {
        [Required]
        [MaxLength(10, ErrorMessage = "La identificacion debe tener entre 7 y 10 caracteres"), MinLength(7,
            ErrorMessage = "La identificacion debe tener entre 7 y 10 caracteres")]
        public string Identificacion { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "El nombre debe tener entre 5 y 30 caracteres"), MinLength(5,
            ErrorMessage = "El nombre debe tener entre 5 y 30 caracteres")]
        public string Nombres { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "El primer apellido debe tener entre 5 y 15 caracteres"), MinLength(5,
            ErrorMessage = "El primer apellido debe tener entre 5 y 15 caracteres")]
        public string PrimerApellido { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "El segundo apellido debe tener entre 5 y 15 caracteres"), MinLength(5,
            ErrorMessage = "El segundo apellido debe tener entre 5 y 15 caracteres")]
        public string SegundoApellido { get; set; }

        [SexoValidacion(ErrorMessage = "El Sexo de ser Masculino o Femenino")]
        [Required]
        public string Sexo { get; set; }
        [Required, Range(18, 120, ErrorMessage = "La edad debe estar entre 18 y 120 anhos")]
        public int Edad { get; set; }
        [Required]
        public string EstadoCivil { get; set; }
        [Required]
        public string PaisDeProcedencia { get; set; }
        [Required]
        public string NivelEducativo { get; set; }
        [Required]
        public int SedeId { get; set; }

        public ManipuladorInputModel() { }
    }

    public class ManipuladorViewModel : ManipuladorInputModel
    {

        public ManipuladorViewModel() { }
        public ManipuladorViewModel(ManipuladorDeAlimento manipulador)
        {
            Identificacion = manipulador.Identificacion;
            Nombres = manipulador.Nombres;
            PrimerApellido = manipulador.PrimerApellido;
            SegundoApellido = manipulador.SegundoApellido;
            Sexo = manipulador.Sexo;
            Edad = manipulador.Edad;
            EstadoCivil = manipulador.EstadoCivil;
            PaisDeProcedencia = manipulador.PaisDeProcedencia;
            NivelEducativo = manipulador.NivelEducativo;
            SedeId = manipulador.SedeId;
        }
    }
}