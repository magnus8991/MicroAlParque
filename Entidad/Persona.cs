using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidad
{
    public class Persona
    {
        [Key]
        [StringLength(10)]
        public string Identificacion { get; set; }
        [StringLength(30)]
        public string Nombres { get; set; }
        [StringLength(15)]
        public string PrimerApellido { get; set; }
        [StringLength(15)]
        public string SegundoApellido { get; set; }
        [StringLength(9)]
        public string Sexo { get; set; }
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
