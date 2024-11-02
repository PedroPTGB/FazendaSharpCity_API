using FazendaSharpCity_API.Models;
using Microsoft.EntityFrameworkCore;

namespace FazendaSharpCity_API.Data.Contexts
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> opts) : base(opts)
        {

        }

        public DbSet<Produto> Produtos{ get; set; }
    }
}
