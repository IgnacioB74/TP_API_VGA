using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class VgaContext : DbContext
    {
        public VgaContext(DbContextOptions<VgaContext> options)
            : base(options) { }

        public DbSet<AlimentoCategoria> AlimentosCategorias { get; set; }
        public DbSet<Alimento> Alimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Clave primaria explícita
            modelBuilder.Entity<AlimentoCategoria>()
                .HasKey(a => a.ID_Categoria);

            // Configuración decimal
            modelBuilder.Entity<Cuota>()
                .Property(c => c.Monto)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PlanEntrenamiento>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");
        }
    }
}
