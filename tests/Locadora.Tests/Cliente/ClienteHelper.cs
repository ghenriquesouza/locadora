using System;
using System.Collections.Generic;
using System.Text;
using Locadora.Business.Interfaces;
using Locadora.Business.Services;
using Locadora.Data.Context;
using Locadora.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Locadora.Business;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Locadora.Tests.Cliente
{
    public class ClienteHelper
    {
        IClienteService clienteService;
        IClienteRepository clienteRepository;
        MeuDBContext context;

        public ClienteHelper(MeuDBContext dbContext)
        {
            context = (MeuDBContext) dbContext;
            clienteRepository = new ClienteRepository(context);
            clienteService = new ClienteService(clienteRepository);

        }

        public void Cadastrar(Guid id)
        {
            try
            {
                var cliente = new Business.Models.Cliente()
                {
                    Id = id,
                    Ativo = true,
                    Documento = "123455",
                    Nome = "Cliente Teste"
                };
                clienteService.Cadastrar(cliente).Wait();
            }
            catch (Exception)
            {

                throw;
            }
           

        }

        public IEnumerable<Business.Models.Cliente> ObterTodos()
        {
            return clienteRepository.ObterTodos().Result;
        }
            
        public Business.Models.Cliente ObterPorId(Guid id)
        {
            return clienteRepository.ObterPorId(id).Result;
        }


    }
}
