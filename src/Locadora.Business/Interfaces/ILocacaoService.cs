using Locadora.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Business.Interfaces
{
    public interface ILocacaoService: IDisposable
    {
        Task Alugar(Locacao locacao);

        Task<string> Devolver(Locacao locacao);

    }
}
