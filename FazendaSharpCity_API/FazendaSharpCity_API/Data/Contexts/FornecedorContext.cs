using FazendaSharpCity_API.Models;
using Microsoft.EntityFrameworkCore;

namespace FazendaSharpCity_API.Data
{
    public class FornecedorContext : DbContext
    {
        public FornecedorContext(DbContextOptions<FornecedorContext> opts) : base(opts)
        {

        }

        public DbSet<Fornecedor> Fornecedores{ get; set; }
    }
}
