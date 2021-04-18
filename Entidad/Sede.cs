using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class Sede
    {
        [Key]
        public int SedeId { get; set; }
        [StringLength(20)]
        public string Nombre { get; set; }
        [StringLength(30)]
        public string Direccion { get; set; }
        [StringLength(10)]
        public string Telefono { get; set; }
        [StringLength(15)]
        public string RestauranteId { get; set; }
    }
}