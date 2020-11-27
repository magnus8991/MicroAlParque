using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaArias.Models
{
    public class UsuarioInputModel
    {
        public string TipoUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Identificacion { get; set; }

        public UsuarioInputModel() { }
    }

    public class UsuarioViewModel : UsuarioInputModel
    {
        public int UsuarioId { get; set; }

        public UsuarioViewModel() { }
        public UsuarioViewModel(Usuario usuario)
        {
            UsuarioId = usuario.UsuarioId;
            TipoUsuario = usuario.TipoUsuario;
            NombreUsuario = usuario.NombreUsuario;
            Contrasena = usuario.Contrasena;
            Identificacion = usuario.Identificacion;
        }
    }
}