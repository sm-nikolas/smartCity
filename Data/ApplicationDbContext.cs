using Microsoft.EntityFrameworkCore;
using SmartCityApi.Models;

namespace SmartCityApi.Data
{
    public class SmartCityContext : DbContext
    {
        public SmartCityContext(DbContextOptions<SmartCityContext> options) : base(options) { }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<Zona> Zonas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>().ToTable("Cidades");
            modelBuilder.Entity<Evento>().ToTable("Eventos");
            modelBuilder.Entity<Sensor>().ToTable("Sensores");
            modelBuilder.Entity<Zona>().ToTable("Zonas");

            // Configuração de relacionamentos

            // Cidade tem muitas Zonas
            modelBuilder.Entity<Cidade>()
                .HasMany(c => c.Zonas)
                .WithOne(z => z.Cidade)
                .HasForeignKey(z => z.CidadeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Zona tem muitos Sensores e Eventos
            modelBuilder.Entity<Zona>()
                .HasMany(z => z.Sensores)
                .WithOne(s => s.Zona)
                .HasForeignKey(s => s.ZonaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Zona>()
                .HasMany(z => z.Eventos)
                .WithOne(e => e.Zona)
                .HasForeignKey(e => e.ZonaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
