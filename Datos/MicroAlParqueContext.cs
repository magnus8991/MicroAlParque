using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class MicroAlParqueContext : DbContext
    {
        public MicroAlParqueContext(DbContextOptions options) : base(options) { }

        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ManipuladorDeAlimento> Manipuladores { get; set; }
        public DbSet<ListaChequeo> ListasDeChequeo { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Sede> Sedes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListaChequeo>()
                .HasOne<Sede>()
                .WithMany()
                .HasForeignKey(l => l.SedeId);
            modelBuilder.Entity<RespuestaChequeo>()
                .HasOne<Pregunta>()
                .WithMany()
                .HasForeignKey(rp => rp.PreguntaId);
            modelBuilder.Entity<Sede>()
                .HasOne<Restaurante>()
                .WithMany()
                .HasForeignKey(s => s.RestauranteId);
            modelBuilder.Entity<Respuesta>()
                .HasOne<Pregunta>()
                .WithMany()
                .HasForeignKey(r => r.PreguntaId);
            modelBuilder.Entity<Respuesta>()
                .HasOne<ManipuladorDeAlimento>()
                .WithMany()
                .HasForeignKey(r => r.Identificacion);
            modelBuilder.Entity<ManipuladorDeAlimento>()
                .HasOne<Sede>()
                .WithMany()
                .HasForeignKey(ma => ma.SedeId);
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.NombreUsuario);
            modelBuilder.Entity<Propietario>()
            .HasKey(p => p.Identificacion);
            modelBuilder.Entity<ManipuladorDeAlimento>()
            .HasKey(m => m.Identificacion);
            
        }
    }
}
