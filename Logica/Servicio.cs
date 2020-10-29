using System;
using Entidad;
using Datos;

namespace Logica
{
    public class Servicio
    {
        private readonly MicroAlParqueContext _contexto;

        public Servicio(MicroAlParqueContext contexto)
        {
            _contexto = contexto;
        }
    }
}
