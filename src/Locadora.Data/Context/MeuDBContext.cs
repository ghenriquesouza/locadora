using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Locadora.Business.Models;
using System.Linq;

namespace Locadora.Data.Context
{
    public class  MeuDBContext: DbContext
    {
        public MeuDBContext(DbContextOptions<MeuDBContext> options) : base(options) { }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

    }
}
