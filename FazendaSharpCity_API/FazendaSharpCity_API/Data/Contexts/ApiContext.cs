using FazendaSharpCity_API.Models;
using Microsoft.EntityFrameworkCore;

namespace FazendaSharpCity_API.Data.Contexts
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cliente)
                .WithOne(cliente => cliente.Endereco)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.Fornecedor)
                .WithOne(fornecedor => fornecedor.Endereco)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.Funcionario)
                .WithOne(funcionario => funcionario.Endereco)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
