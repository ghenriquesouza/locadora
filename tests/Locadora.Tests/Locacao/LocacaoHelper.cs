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

namespace Locadora.Tests.Locacao
{
    public class LocacaoHelper
    {

        ILocacaoRepository locacaoRepository;
        ILocacaoService locacaoService;
        IFilmeRepository filmeRepository;
        
        IClienteRepository clienteRepository;
        
        MeuDBContext context;

        public LocacaoHelper(MeuDBContext dbContext)
        {
            context = dbContext;
            locacaoRepository = new LocacaoRepository(context);
            filmeRepository = new FilmeRepository(context);
            clienteRepository = new ClienteRepository(context);
            locacaoService = new LocacaoService(locacaoRepository, filmeRepository, clienteRepository);
            
        }

        public  Business.Models.Locacao CriarLocacaoModel(Guid locacaoId, Guid clienteId, Guid filmeId)
        {
            return new Business.Models.Locacao()
            {
                ClienteId = clienteId,
                FilmeId = filmeId,
                Id = locacaoId
            };
        }

        public void Alugar(Guid locacaoId, Guid clienteId,  Guid filmeId)
        {
            try
            {
                var locacao = CriarLocacaoModel(locacaoId, clienteId, filmeId);
                locacaoService.Alugar(locacao).Wait();
            }
            catch (Exception)
            {

                throw;
            }


        }

        public string Devolver(Guid locacaoId)
        {
            try
            {
                var locacao = new Business.Models.Locacao() { Id = locacaoId };
                return  locacaoService.Devolver(locacao).Result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public IEnumerable<Business.Models.Locacao> ObterTodos()
        {
            return locacaoRepository.ObterTodos().Result;
        }

        public Business.Models.Locacao ObterPorId(Guid id)
        {
            return locacaoRepository.ObterPorId(id).Result;
        }

        public void Atualizar(Business.Models.Locacao locacao)
        {
            locacaoRepository.Atualizar(locacao).Wait();
        }


    }
}
