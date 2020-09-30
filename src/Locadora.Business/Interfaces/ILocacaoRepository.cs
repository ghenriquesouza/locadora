using Locadora.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Business.Interfaces
{
    public interface ILocacaoRepository: IRepository<Locacao>
    {
        Task<IEnumerable<Locacao>> VerificarSeClienteJaLocouFilme(Guid ClienteId, Guid FilmeId);

        Task<IEnumerable<Locacao>> ObterLocacoesPorClienteId(Guid ClienteId);
    }
}
