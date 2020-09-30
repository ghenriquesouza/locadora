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
    [Route("api/filmes")]
    public class FilmesController: MainController
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly IFilmeService _filmeService;

        public FilmesController(IFilmeRepository filmeRepository, IFilmeService filmeService)
        {
            _filmeRepository = filmeRepository;
            _filmeService = filmeService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<Filme>> ObterTodos()
        {
            return await _filmeRepository.ObterTodos();
        }
        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Filme>> ObterPorId(Guid id)
        {
            var fornecedor = await _filmeRepository.ObterPorId(id);

            if (fornecedor == null) return NotFound();

            return fornecedor;
        }
        [AllowAnonymous]
        [HttpPost("Adicionar")]
        public async Task<ActionResult<Filme>> Adicionar(Filme filme)
        {
            try
            {
                if (filme == null)
                    return BadRequest();

                await _filmeService.Cadastrar(filme);

                return filme;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        

    }
}
