using System.ComponentModel.DataAnnotations;

namespace MicroAlParque.Models
{
    public class LoginInputModel
    {
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Contrasena { get; set; }
    }
    public class LoginViewModel
    {
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Token { get; set; }
    }
}