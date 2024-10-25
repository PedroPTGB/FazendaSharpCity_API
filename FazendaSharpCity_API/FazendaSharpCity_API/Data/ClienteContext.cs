﻿using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FazendaSharpCity_API.Data
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> opts) : base(opts)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
