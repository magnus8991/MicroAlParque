using System;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class Usuario
    {
        [StringLength(20)]
        public string NombreUsuario { get; set; }
        [StringLength(20)]
        public string Contraseña { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
