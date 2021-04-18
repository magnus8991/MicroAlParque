using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidad
{
    public class ManipuladorDeAlimento : Persona
    {
        [StringLength(15)]
        public string EstadoCivil { get; set; }
        [StringLength(20)]
        public string PaisDeProcedencia { get; set; }
        [StringLength(20)]
        public string NivelEducativo { get; set; }
        public int SedeId { get; set; }
        public ManipuladorDeAlimento() { }

    }
}
