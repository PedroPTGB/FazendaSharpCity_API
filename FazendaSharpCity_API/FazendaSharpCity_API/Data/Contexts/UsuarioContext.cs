using FazendaSharpCity_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FazendaSharpCity_API.Data.Contexts
{
    public class UsuarioContext(DbContextOptions<UsuarioContext> opts) : IdentityDbContext<Usuario>(opts)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
