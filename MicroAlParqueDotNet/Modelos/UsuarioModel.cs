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
        [MaxLength(10, ErrorMessage = "La identificacion debe tener entre 7 y 10 caracteres"), MinLength(7,
            ErrorMessage = "La identificacion debe tener entre 7 y 10 caracteres")]
        public string Identificacion { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "El nombre debe tener entre 5 y 30 caracteres"), MinLength(5,
            ErrorMessage = "El nombre debe tener entre 5 y 30 caracteres")]
        public string Nombres { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "El primer apellido debe tener entre 5 y 15 caracteres"), MinLength(5,
            ErrorMessage = "El primer apellido debe tener entre 5 y 15 caracteres")]
        public string PrimerApellido { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "El segundo apellido debe tener entre 5 y 15 caracteres"), MinLength(5,
            ErrorMessage = "El segundo apellido debe tener entre 5 y 15 caracteres")]
        public string SegundoApellido { get; set; }

        [SexoValidacion(ErrorMessage = "El Sexo de ser Masculino o Femenino")]
        [Required]
        public string Sexo { get; set; }
        [Required, Range(18, 120, ErrorMessage = "La edad debe estar entre 18 y 120 anhos")]
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