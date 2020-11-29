using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Restaurante
    {
        [Key]
        [StringLength(15)]
        public string NIT { get; set; }
        [StringLength(35)]
        public string Nombre { get; set; }
        public Propietario Propietario { get; set; }
        public Restaurante() { }

    }
}