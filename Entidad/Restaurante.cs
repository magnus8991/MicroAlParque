using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Restaurante
    {
        [Key]
        [MaxLength(15, ErrorMessage = "El NIT debe tener entre 6 y 15 caracteres"), MinLength(6,
            ErrorMessage = "El NIT debe tener entre 6 y 15 caracteres")]
        [Required]
        public string NIT { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "El nombre del restaurante debe tener entre 3 y 20 caracteres"), MinLength(3,
            ErrorMessage = "El nombre del restaurante debe tener entre 3 y 20 caracteres")]
        public string Nombre { get; set; }
        public Propietario Propietario { get; set; }
        public Restaurante() { }

    }
}