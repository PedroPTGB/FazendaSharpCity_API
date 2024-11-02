using FazendaSharpCity_API.Models;
using Microsoft.EntityFrameworkCore;

namespace FazendaSharpCity_API.Data.Contexts
{
    public class FuncionarioContext : DbContext
    {
        public FuncionarioContext(DbContextOptions<FuncionarioContext> opts) : base(opts)
        {

        }

        public DbSet<Funcionario> Funcionarios{ get; set; }
    }
}
