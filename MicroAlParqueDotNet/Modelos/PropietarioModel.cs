using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroAlParque.Models
{
    public class PropietarioInputModel
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }

        public PropietarioInputModel() { }
    }

    public class PropietarioViewModel : PropietarioInputModel
    {
        public int PropietarioId { get; set; }

        public PropietarioViewModel() { }
        public PropietarioViewModel(Propietario Propietario)
        {
            Identificacion = Propietario.Identificacion;
            Nombres = Propietario.Nombres;
            PrimerApellido = Propietario.PrimerApellido;
            SegundoApellido = Propietario.SegundoApellido;
            Edad = Propietario.Edad;
            Sexo = Propietario.Sexo;
        }
    }
}