using Fiap.Api.Donation5.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Donation5.Data
{
    public class DataContext : DbContext
    {
        public DbSet<CategoriaModel> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaModel>(entity =>
            {
                entity.ToTable("Categoria");
                entity.HasKey(c => c.CategoriaId);
                entity.Property(c => c.CategoriaId).ValueGeneratedOnAdd();

                entity.Property(c => c.NomeCategoria)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(c => c.Descricao)
                .HasMaxLength(500);

                entity.HasIndex(c => c.NomeCategoria);
            });

            modelBuilder.Entity<CategoriaModel>().HasData(
                new CategoriaModel() { CategoriaId = 1, NomeCategoria = "Smartphone", Descricao = "Descrição para Smartphone" },
                new CategoriaModel() { CategoriaId = 2, NomeCategoria = "Televisores", Descricao = "Descrição para TV" }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }

    }
}
