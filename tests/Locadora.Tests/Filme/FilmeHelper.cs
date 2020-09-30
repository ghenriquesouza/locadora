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

namespace Locadora.Tests.Filme
{
    public class FilmeHelper
    {
        
        IFilmeRepository filmeRepository;
        IFilmeService filmeService;
        MeuDBContext context;
        

        public FilmeHelper(MeuDBContext dbContext)
        {
            context = dbContext;
            filmeRepository = new FilmeRepository(context);
            filmeService = new FilmeService(filmeRepository);
            
        }
        
        public void Cadastrar(Guid id, string nome, int quantidade)
        {
            try
            {
                var filme = new Business.Models.Filme()
                {
                    Id = id,
                    Ativo = true,
                    Nome = nome,
                    QuantidadeDisponivel = quantidade
                };

                filmeService.Cadastrar(filme).Wait();
            }
            catch (Exception)
            {

                throw;
            }


        }

        public IEnumerable<Business.Models.Filme> ObterTodos()
        {
            return filmeRepository.ObterTodos().Result;
        }

        public Business.Models.Filme ObterPorId(Guid id)
        {
            return filmeRepository.ObterPorId(id).Result;
        }

       


    }
}
