using Locadora.Api.Controllers;
using Locadora.Business.Interfaces;
using Locadora.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Api.V1.Controller
{
    [Route("api/locacoes")]
    public class LocacaoController : MainController
    {
        private readonly ILocacaoRepository _LocacaoRepository;
        private readonly ILocacaoService _locacaoService;

        public LocacaoController(ILocacaoRepository LocacaoRepository,
                                 ILocacaoService locacaoService)
        {
            _LocacaoRepository = LocacaoRepository;
            _locacaoService = locacaoService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<Locacao>> ObterTodos()
        {
            return await _LocacaoRepository.ObterTodos();
        }
        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Locacao>> ObterPorId(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var locacoes = await _LocacaoRepository.ObterPorId(id);

            if (locacoes == null) return NotFound();

            return locacoes;
        }
        [AllowAnonymous]
        [HttpPost("Alugar")]
        public async Task<ActionResult<Locacao>> Alugar(Locacao locacao)
        {
            try
            {
                if (locacao == null)
                    return BadRequest();

                await _locacaoService.Alugar(locacao);

                return locacao;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [AllowAnonymous]
        [HttpPost("Devolver")]
        public async Task<ActionResult<string>> Devolver(Locacao locacao)
        {
            try
            {
                if (locacao == null)
                    return BadRequest();

                return await _locacaoService.Devolver(locacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }

        [AllowAnonymous]
        [HttpGet("cliente/{id:guid}")]
        public async Task<ActionResult<IEnumerable<Locacao>>> ObterPorCliente(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var locacoes = await _LocacaoRepository.ObterLocacoesPorClienteId(id);

            if (locacoes == null) return NotFound();

            return Ok(locacoes);
        }
    }
}
