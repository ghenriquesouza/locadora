using Locadora.Business.Interfaces;
using Locadora.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Business.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;
        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task Cadastrar(Filme filme)
        {
            if (filme.Id == Guid.Empty)
                throw new Exception("Id invalido");

            if (string.IsNullOrEmpty(filme.Nome))
                throw new Exception("Informe o nome do filme");

            await _filmeRepository.Adicionar(filme);
        }

        public void Dispose()
        {
            _filmeRepository?.Dispose();
        }
    }
}
