using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaArias.Models
{
    public class PersonaInputModel
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }

        public PersonaInputModel() { }
    }

    public class PersonaViewModel : PersonaInputModel
    {

        public PersonaViewModel() { }
        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            Nombres = persona.Nombres;
            PrimerApellido = persona.PrimerApellido;
            SegundoApellido = persona.SegundoApellido;
            Sexo = persona.Sexo;
            Edad = persona.Edad;
        }
    }
}