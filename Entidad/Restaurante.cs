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
        [StringLength(40)]
        public string Direccion { get; set; }
        [StringLength(20)]
        public string Sede { get; set; }
        public int Telefono { get; set; }
        [StringLength(11)]
        public string IdPropietario { get; set; }
        public Restaurante() { }

    }
}