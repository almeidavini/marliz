using Liz.Models;
using Microsoft.EntityFrameworkCore;

namespace Liz.Data
{
    public class LizDbContext : DbContext
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Endereco> Enderecos { get; set; }
        DbSet<Pedido> Pedidos { get; set; }
        DbSet<Produto> Produtos { get; set; }
        DbSet<ProdutoPedido> ProdutosPedido { get; set; }
        DbSet<Status> Status { get; set; }
        DbSet<Telefone> Telefones { get; set; }
        DbSet<TpUnidade> TpUnidades { get; set; }

        public LizDbContext(DbContextOptions options) : base(options)
        {

        }
        public LizDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity
                    .HasKey(o => o.IdCliente);

                entity
                    .Property(o => o.Nome)
                    .HasMaxLength(100)
                    .IsRequired();

                entity
                    .Property(o => o.Sobrenome)
                    .HasMaxLength(100)
                    .IsRequired();

                entity
                    .Property(o => o.Cpf)
                    .HasMaxLength(11)
                    .IsRequired();

                entity
                    .Property(o => o.Sexo)
                    .IsRequired();

                entity
                    .Property(o => o.Email);

                entity
                    .Property(o => o.DtCadastro)
                    .HasColumnType("dateTime")
                    .IsRequired();
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity
                    .HasKey(o => o.IdEndereco);

                entity
                    .Property(o => o.Cep)
                    .HasMaxLength(8)
                    .IsRequired();

                entity
                    .Property(o => o.Logradouro)
                    .HasMaxLength(200)
                    .IsRequired();

                entity
                    .Property(o => o.Numero)
                    .IsRequired();

                entity
                    .Property(o => o.Bairro)
                    .IsRequired();

                entity
                    .Property(o => o.Cidade)
                    .IsRequired();

                entity
                    .Property(o => o.Uf)
                    .HasMaxLength(2)
                    .IsRequired();
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity
                    .HasKey(o => o.IdPedido);

                entity
                    .Property(o => o.DtPedido)
                    .HasColumnType("dateTime")
                    .IsRequired();

                entity
                    .Property(o => o.DtEntrega)
                    .HasColumnType("dateTime")
                    .IsRequired();
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity
                    .HasKey(o => o.IdProduto);

                entity
                    .Property(o => o.Descricao)
                    .HasMaxLength(100)
                    .IsRequired();

                entity
                    .Property(o => o.Valor)
                    .HasColumnType("float")
                    .IsRequired();
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity
                    .HasKey(o => o.IdStatus);

                entity
                    .Property(o => o.Descricao)
                    .HasMaxLength(100)
                    .IsRequired();
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity
                    .HasKey(o => o.IdTelefone);

                entity
                    .Property(o => o.Ddd)
                    .HasMaxLength(2)
                    .IsRequired();

                entity
                    .Property(o => o.Numero)
                    .HasMaxLength(9)
                    .IsRequired();
            });

            modelBuilder.Entity<TpUnidade>(entity =>
            {
                entity
                    .HasKey(o => o.IdTpUnidade);

                entity
                    .Property(o => o.Abreviatura)
                    .HasMaxLength(5)
                    .IsRequired();

                entity
                    .Property(o => o.Descricao)
                    .HasMaxLength(20)
                    .IsRequired();
            });

            modelBuilder.Entity<ProdutoPedido>()
                .HasKey(o => new { o.PedidoId, o.ProdutoId });

            modelBuilder.Entity<ProdutoPedido>()
                .HasOne(o => o.Pedido)
                .WithMany(o => o.ProdutoPedidos)
                .HasForeignKey(o => o.PedidoId);

            modelBuilder.Entity<ProdutoPedido>()
                .HasOne(o => o.Produto)
                .WithMany(o => o.ProdutoPedidos)
                .HasForeignKey(o => o.ProdutoId);
        }
    }
}