using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jugador>().ToTable("Jugador");
            modelBuilder.Entity<Pais>().ToTable("Pais");
            modelBuilder.Entity<Demarcacion>().ToTable("Demarcacion");
            modelBuilder.Entity<Pie>().ToTable("Pie");
            modelBuilder.Entity<Nacionalidad>().ToTable("Nacionalidad");
            modelBuilder.Entity<Representante>().ToTable("Representante");
            modelBuilder.Entity<Equipo>().ToTable("Equipo");
            modelBuilder.Entity<Estadio>().ToTable("Estadio");
            modelBuilder.Entity<Provincia>().ToTable("Provincia");
            modelBuilder.Entity<Video>().ToTable("Video");
            modelBuilder.Entity<AuthorVideo>().ToTable("AuthorVideo");
            modelBuilder.Entity<Comentario>().ToTable("Comentario");
        }

        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<Demarcacion> Demarcaciones { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Nacionalidad> Nacionalidades { get; set; }
        public DbSet<Representante> Representantes { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<AuthorVideo> AuthorVideos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}