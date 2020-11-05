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
        [StringLength(15)]
        public string PaisDeProcedencia { get; set; }
        [StringLength(15)]
        public string NivelEducativo { get; set; }
        public int RestauranteId { get; set; }

    }
}
