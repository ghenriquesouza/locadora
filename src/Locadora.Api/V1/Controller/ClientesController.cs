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

    [Route("api/clientes")]
    public class ClientesController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clientService;

        public ClientesController(IClienteRepository clienteReposoitory, IClienteService clientService)
        {
            _clienteRepository = clienteReposoitory;
            _clientService = clientService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await _clienteRepository.ObterTodos();
        }
        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Cliente>> ObterPorId(Guid id)
        {
            var fornecedor = await _clienteRepository.ObterPorId(id);

            if (fornecedor == null) return NotFound();

            return fornecedor;
        }
        [AllowAnonymous]
        [HttpPost("Adicionar")]
        public async Task<ActionResult<Cliente>> Adicionar(Cliente cliente)
        {
            try
            {
                await _clientService.Cadastrar(cliente);

                return cliente;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
