using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidad
{
    public class Persona
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
        [Required, Range(18, 120, ErrorMessage = "La edad debe estar entre 18 y 120 años")]
        public int Edad { get; set; }
        public Persona() { }


        public class SexoValidacion : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if ((value.ToString().ToLower() == "masculino") || (value.ToString().ToLower() == "femenino"))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
        }
    }
}
