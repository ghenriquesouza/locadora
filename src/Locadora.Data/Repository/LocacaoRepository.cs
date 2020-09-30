using Locadora.Business.Interfaces;
using Locadora.Business.Models;
using Locadora.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Data.Repository
{
    public class LocacaoRepository : Repository<Locacao>, ILocacaoRepository
    {
        public LocacaoRepository(MeuDBContext context) : base(context) { }

        public async Task<IEnumerable<Locacao>> VerificarSeClienteJaLocouFilme(Guid ClienteId, Guid FilmeId)
        {
           return await  Db.Locacoes.AsNoTracking()
                .Where(c => c.ClienteId == ClienteId && c.FilmeId == FilmeId).ToListAsync();

        }
        
    }
}
