using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Restaurante
    {
        [Key]
        public int IdRestaurante { get; set; }
        [StringLength(35)]
        public string Nombre { get; set; }
        [StringLength(40)]
        public string Direccion { get; set; }
        [StringLength(11)]
        public string Identificacion { get; set; }
        public Restaurante() { }

    }
}