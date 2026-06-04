using Domain.Entities;
using GymAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Ejercicio> Ejercicios => Set<Ejercicio>();
        public DbSet<GrupoMuscular> GruposMusculares => Set<GrupoMuscular>();
        public DbSet<Rutina> Rutinas => Set<Rutina>();
        public DbSet<RutinaUsuario> RutinasUsuarios => Set<RutinaUsuario>();
        public DbSet<RutinaDetalle> RutinasDetalles => Set<RutinaDetalle>();
        public DbSet<Pago> Pagos => Set<Pago>();
        public DbSet<Cuota> Cuotas => Set<Cuota>();
        public DbSet<FormaPago> FormasPago => Set<FormaPago>();
        public DbSet<PlanEntrenamiento> PlanesEntrenamiento => Set<PlanEntrenamiento>();
        public DbSet<CarouselItem> CarouselItems => Set<CarouselItem>();
        public DbSet<FooterConfig> FooterConfigs => Set<FooterConfig>();
        public DbSet<Alimento> Alimentos => Set<Alimento>();
        public DbSet<AlimentoCategoria> AlimentosCategorias => Set<AlimentoCategoria>();
        public DbSet<AlimentoObjetivo> AlimentosObjetivos => Set<AlimentoObjetivo>();
        public DbSet<DietaDetalle> DietasDetalles { get; set; }

        public DbSet<UsuarioDieta> UsuarioDietas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ==============================
            // USUARIOS
            // ==============================
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");

                entity.HasKey(e => e.Mail);

                entity.Ignore(e => e.Id);

                entity.Property(e => e.Nombre)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Apellido)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Mail)
                      .HasMaxLength(150)
                      .IsRequired();

                entity.Property(e => e.Telefono)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(e => e.Username)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(e => e.Clave)
                      .HasMaxLength(500)
                      .IsRequired();

                entity.Property(e => e.Tipo)
                      .IsRequired();

                entity.Property(e => e.Activo)
                      .IsRequired();

                entity.Property(e => e.ID_UsuarioTipo)
                      .HasColumnName("ID_UsuarioTipo")
                      .IsRequired();

                entity.HasIndex(e => e.Mail)
                      .IsUnique();

                entity.HasIndex(e => e.Username)
                      .IsUnique();
            });

            // ==============================
            // EJERCICIOS
            // ==============================
            modelBuilder.Entity<Ejercicio>(entity =>
            {
                entity.ToTable("Ejercicios");
                entity.HasKey(e => e.ID_Ejercicio);

                entity.HasOne(e => e.GrupoMuscular)
                      .WithMany(g => g.Ejercicios)
                      .HasForeignKey(e => e.ID_Grupo);
            });

            // ==============================
            // GRUPOS MUSCULARES
            // ==============================
            modelBuilder.Entity<GrupoMuscular>(entity =>
            {
                entity.ToTable("GruposMusculares");
                entity.HasKey(g => g.ID_Grupo);
            });

            // ==============================
            // ALIMENTOS
            // ==============================
            modelBuilder.Entity<Alimento>(entity =>
            {
                entity.ToTable("Alimentos");

                entity.HasKey(a => a.ID_Alimento);

                entity.Property(a => a.Nombre)
                      .HasMaxLength(150);

                entity.Property(a => a.Descripcion)
                      .HasMaxLength(255);

                entity.HasOne(a => a.Categoria)
                      .WithMany(c => c.Alimentos)
                      .HasForeignKey(a => a.ID_Categoria);

                entity.HasOne(a => a.Objetivo)
                      .WithMany(o => o.Alimentos)
                      .HasForeignKey(a => a.ID_Objetivo);
            });

            // ==============================
            // DIETAS DETALLES
            // ==============================
            modelBuilder.Entity<DietaDetalle>(entity =>
            {
                entity.ToTable("DietasDetalles");

                entity.HasKey(x => x.ID);

                entity.Property(x => x.Dia)
                      .HasMaxLength(50);

                entity.Property(x => x.Categoria)
                      .HasMaxLength(50);

                entity.Property(x => x.Alimento)
                      .HasMaxLength(255);
            });



            // ==============================
            // USUARIO DIETAS
            // ==============================

            modelBuilder.Entity<UsuarioDieta>().HasKey(x => new
            {
                x.ID_Dieta,
                x.Username
            });

            //==============================
            // RUTINAS
            //==============================
            modelBuilder.Entity<Rutina>(entity =>
            {
                entity.ToTable("Rutinas");

                entity.HasKey(x => x.ID_Rutina);

                entity.Property(x => x.ID_Rutina)
                      .HasColumnName("ID_Rutina")
                      .ValueGeneratedOnAdd();

                entity.Property(x => x.Nombre)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(x => x.Descripcion)
                      .HasMaxLength(500);

                entity.Property(x => x.Intensidad)
                      .HasMaxLength(50);

                entity.Property(x => x.Activa)
                      .IsRequired();

                entity.Property(x => x.EjerciciosXDia)
                      .IsRequired();
            });

            // ==============================
            // PAGOS
            // ==============================
            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("Pagos");

                entity.HasKey(x => x.ID);

                entity.Property(x => x.Username)
                    .HasMaxLength(50);

                entity.Property(x => x.Mes)
                    .HasMaxLength(20);

                entity.Property(x => x.Estado)
                    .HasMaxLength(20);

                entity.Property(x => x.Fecha);

                entity.HasIndex(x => new
                {
                    x.Username,
                    x.Mes
                })
                .IsUnique();

                entity.HasOne(x => x.FormaPago)
                    .WithMany()
                    .HasForeignKey(x => x.ID_FormaPago)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Plan)
                    .WithMany()
                    .HasForeignKey(x => x.ID_Plan)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ==============================
            // FORMAS DE PAGO
            // ==============================
            modelBuilder.Entity<FormaPago>(entity =>
            {
                entity.ToTable("FormasPago");

                entity.HasKey(x => x.ID);

                entity.Property(x => x.Nombre)
                    .HasMaxLength(100);
            });
            // ==============================
            // PLANES ENTRENAMIENTO
            // ==============================
            modelBuilder.Entity<PlanEntrenamiento>(entity =>
            {
                entity.ToTable("PlanesEntrenamiento");

                entity.HasKey(x => x.ID);

                entity.Property(x => x.Nombre)
                    .HasMaxLength(100);

                entity.Property(x => x.Descripcion)
                    .HasMaxLength(255);

                entity.Property(x => x.Nivel)
                    .HasMaxLength(50);

                entity.Property(x => x.Precio)
                    .HasColumnType("decimal(10,2)");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}