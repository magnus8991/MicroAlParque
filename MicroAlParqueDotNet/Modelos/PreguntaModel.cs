using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroAlParque.Models
{
    public class PreguntaInputModel
    {
        public string Enunciado { get; set; }

        public PreguntaInputModel() { }
    }

    public class PreguntaViewModel : PreguntaInputModel
    {
        public int PreguntaId { get; set; }
        public PreguntaViewModel() { }
        public PreguntaViewModel(Pregunta pregunta)
        {
            PreguntaId = pregunta.PreguntaId;
            Enunciado = pregunta.Enunciado;
        }
    }
}