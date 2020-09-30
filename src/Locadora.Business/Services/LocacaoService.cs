using Locadora.Business.Interfaces;
using Locadora.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Business.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IFilmeRepository _filmeRepository;
        private readonly IClienteRepository _clienteRepository;
        private const int QTDE_DIAS_DEVOLUCAO = 3;

        public LocacaoService(ILocacaoRepository locacaoRepository,
                              IFilmeRepository filmeRepository,
                              IClienteRepository clienteRepository)
        {
            _locacaoRepository = locacaoRepository;
            _filmeRepository = filmeRepository;
            _clienteRepository = clienteRepository;

        }
        public async Task Alugar(Locacao locacao)
        {
            if (locacao.ClienteId == Guid.Empty)
                throw new Exception("Cliente não pode ser nulo");
            if(locacao.FilmeId == Guid.Empty)
                throw new Exception("Filme não pode ser nulo");

            var filme = await  _filmeRepository.ObterPorId(locacao.FilmeId);

            if (filme == null)
                throw new Exception("Filme não encontrado");

            var cliente = await _clienteRepository.ObterPorId(locacao.ClienteId);
            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            if (_locacaoRepository.VerificarSeClienteJaLocouFilme(locacao.ClienteId, locacao.FilmeId).Result.Any())
                throw new Exception("O Filme já foi locado anteriormente");

            if (filme.QuantidadeDisponivel ==0)
                throw new Exception("O Filme esta indisponivel");

            

            locacao.Inicio = DateTime.Now;

            await _locacaoRepository.Adicionar(locacao);
            filme.QuantidadeDisponivel--;
            await _filmeRepository.Atualizar(filme);
        }

        public async Task<String> Devolver(Locacao locacao)
        {
            var mensagem = "Devolucao realizada com sucesso";

            if (locacao.Id   == Guid.Empty)
                throw new Exception("Locação Invalida");

            var devolucao = await _locacaoRepository.ObterPorId(locacao.Id);
            if (devolucao == null)
                throw new Exception("Locacao nao encontrada");

            if (devolucao.Devolucao != DateTime.MinValue)
                throw new Exception("Devolucao ja realizada");

            var filme = await _filmeRepository.ObterPorId(devolucao.FilmeId);
            var dataDevolucao = DateTime.Today;
            var dataMaximaDevolucao = devolucao.Inicio.AddDays(QTDE_DIAS_DEVOLUCAO);

            if (dataDevolucao > dataMaximaDevolucao)
                mensagem = "Devolucao com atraso";

            devolucao.Devolucao = DateTime.Now;
            await _locacaoRepository.Atualizar(devolucao);
            filme.QuantidadeDisponivel++;
            await _filmeRepository.Atualizar(filme);


            return mensagem;
        }

        public void Dispose()
        {
            _filmeRepository?.Dispose();
            _clienteRepository?.Dispose();
            _locacaoRepository?.Dispose();

        }

      
    }
}
