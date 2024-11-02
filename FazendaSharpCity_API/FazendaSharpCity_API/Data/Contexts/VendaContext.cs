using FazendaSharpCity_API.Models;
using Microsoft.EntityFrameworkCore;

namespace FazendaSharpCity_API.Data.Contexts
{
    public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> opts) : base(opts)
        {

        }

        public DbSet<Venda> Vendas { get; set; }
    }
}
