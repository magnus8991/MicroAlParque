using System;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class Usuario: Persona
    {
        [Key]
        [StringLength(20)]
        public string NombreUsuario { get; set; }
        [StringLength(20)]
        public string Contrasena { get; set; }
        [StringLength(25)]
        public string Email { get; set; }
        [StringLength(25)]
        public string Rol { get; set; }
        [StringLength(8)]
        public string Estado { get; set; }
        public Usuario() { }
    }
}
