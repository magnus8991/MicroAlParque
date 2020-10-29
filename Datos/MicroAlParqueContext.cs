using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class MicroAlParqueContext : DbContext
    {
        public MicroAlParqueContext(DbContextOptions options) : base(options) { }
    }
}
