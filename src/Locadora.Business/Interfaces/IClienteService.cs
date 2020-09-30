using Locadora.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Business.Interfaces
{
    public interface IClienteService : IDisposable
    {
        Task Cadastrar(Cliente cliente);

       
    }
}
