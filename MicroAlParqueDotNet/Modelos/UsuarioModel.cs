using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroAlParque.Models
{
    public class UsuarioInputModel
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Email { get; set; }
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