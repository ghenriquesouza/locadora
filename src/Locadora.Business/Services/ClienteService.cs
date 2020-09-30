using Locadora.Business.Interfaces;
using Locadora.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.Business.Services
{
   public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        
        public async Task Cadastrar(Cliente cliente)
        {
            if (cliente.Id == Guid.Empty)
                throw new Exception("Id inválido");

            if (string.IsNullOrEmpty(cliente.Nome))
                throw new Exception("Informe o nome");

            if (string.IsNullOrEmpty(cliente.Documento))
                throw new Exception("Informe o número do documento");
            
            await _clienteRepository.Adicionar(cliente);
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
