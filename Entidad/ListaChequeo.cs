using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidad
{
    public class ListaChequeo
    {
        [Key]
        public int ListaChequeoId { get; set; }
        public IList<RespuestaChequeo> RespuestaChequeos { get; set; }
        public int RestauranteId { get; set; }
<<<<<<< HEAD
        public ListaChequeo()
        {
=======
        public ListaChequeo() {
>>>>>>> 407ce48... modelos y controllers
            RespuestaChequeos = new List<RespuestaChequeo>();
        }
    }
}
