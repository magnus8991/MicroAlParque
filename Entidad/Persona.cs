using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidad
{
    public class Persona
    {
        [StringLength(11)]
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
    }
}
