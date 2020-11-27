using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroAlParque.Models
{
    public class ManipuladorInputModel
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string EstadoCivil { get; set; }
        public string PaisDeProcedencia { get; set; }
        public string NivelEducativo { get; set; }
        public string RestauranteId { get; set; }

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
            RestauranteId = manipulador.RestauranteId;
        }
    }
}