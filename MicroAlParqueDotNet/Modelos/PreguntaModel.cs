using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroAlParque.Models
{
    public class PreguntaViewModel
    {
        public int PreguntaId { get; set; }
        public string Enunciado { get; set; }
        public string PerteneceA { get; set; }
        public PreguntaViewModel() { }
        public PreguntaViewModel(Pregunta pregunta)
        {
            PreguntaId = pregunta.PreguntaId;
            Enunciado = pregunta.Enunciado;
            PerteneceA = pregunta.PerteneceA;
        }
    }
}