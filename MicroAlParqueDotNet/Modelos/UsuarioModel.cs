using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroAlParque.Models
{
    public class UsuarioInputModel
    {
        [Required]
        [MaxLength(10), MinLength(7)]
        public string Identificacion { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string PrimerApellido { get; set; }
        [Required]
        public string SegundoApellido { get; set; }

        [SexoValidacion(ErrorMessage = "El Sexo de ser Masculino o Femenino")]
        [Required]
        public string Sexo { get; set; }
        [Required, Range(18, 120, ErrorMessage = "La edad debe estar entre 18 y 120 años")]
        public int Edad { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Contrasena { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Rol { get; set; }

        public UsuarioInputModel() { }
    }

    public class UsuarioViewModel : UsuarioInputModel
    {
        public string Estado { get; set; }
        public UsuarioViewModel() { }
        public UsuarioViewModel(Usuario usuario)
        {
            Identificacion = usuario.Identificacion;
            Nombres = usuario.Nombres;
            PrimerApellido = usuario.PrimerApellido;
            SegundoApellido = usuario.SegundoApellido;
            Edad = usuario.Edad;
            Sexo = usuario.Sexo;
            NombreUsuario = usuario.NombreUsuario;
            Contrasena = usuario.Contrasena;
            Email = usuario.Email;
            Rol = usuario.Rol;
            Estado = usuario.Estado;
        }
    }
}