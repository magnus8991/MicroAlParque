using System;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [StringLength(25)]
        public string TipoUsuario { get; set; }
        [StringLength(20)]
        public string NombreUsuario { get; set; }
        [StringLength(20)]
        public string Contraseña { get; set; }
        [StringLength(11)]
        public string Identificacion { get; set; }
    }
}
