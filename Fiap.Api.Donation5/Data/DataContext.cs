using Fiap.Api.Donation5.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Donation5.Data
{
    public class DataContext : DbContext
    {
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }

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

            modelBuilder.Entity<UsuarioModel>(entity =>
            {
                entity.ToTable("Usuario");
                entity.HasKey(k => k.UsuarioId);
                entity.Property(k => k.UsuarioId).ValueGeneratedOnAdd();

                entity.Property(p => p.NomeUsuario)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(p => p.EmailUsuario)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(p => p.Senha)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(p => p.Regra)
                .HasMaxLength(20);

                entity.HasIndex(e => e.EmailUsuario).IsUnique();

                entity.HasIndex(e => new
                {
                    e.EmailUsuario,
                    e.Senha
                });
            });

            modelBuilder.Entity<UsuarioModel>().HasData(
                new UsuarioModel() { UsuarioId = 1, NomeUsuario = "Willian", Senha = "senha", EmailUsuario = "wil@lia.n" },
                new UsuarioModel() { UsuarioId = 2, NomeUsuario = "Fulano", Senha = "senha", EmailUsuario = "ful@an.o" }
                );

            modelBuilder.Entity<ProdutoModel>(entity =>
            {
                entity.ToTable("Produto");
                entity.HasKey(e => e.ProdutoId);
                entity.Property(e => e.ProdutoId).ValueGeneratedOnAdd();

                entity.Property(e => e.Nome)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.SugestaoTroca)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.Disponivel);

                entity.Property(e => e.Valor)
                      .IsRequired()
                      .HasPrecision(18, 2);

                entity.Property(e => e.DataCadastro)
                      .IsRequired();

                entity.Property(e => e.DataExpiracao)
                      .IsRequired();

                entity.HasOne(e => e.Categoria)
                    .WithMany()
                    .HasForeignKey(e => e.CategoriaId)
                    .IsRequired();

                entity.HasOne(e => e.Usuario)
                    .WithMany()
                    .HasForeignKey(entity => entity.UsuarioId)
                    .IsRequired();

                entity.HasIndex(e => e.Nome);
            });
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