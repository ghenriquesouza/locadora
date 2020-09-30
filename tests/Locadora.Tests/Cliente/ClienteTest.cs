using Locadora.Business.Interfaces;
using Locadora.Business.Models;
using Locadora.Business.Services;
using Locadora.Data.Repository;
using Locadora.Tests.Cliente;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using Xunit;

namespace Locadora.Tests.Cliente
{
    public class ClienteTest
    {
        ClienteHelper clienteHelper;

        public ClienteTest()
        {
            var db = new ConnectionFactory().CreateContextForInMemory();
            clienteHelper = new ClienteHelper(db);
        }

        [Fact(DisplayName = "Novo Cliente Válido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            //arrange
            var newId = Guid.NewGuid();

            //act
            clienteHelper.Cadastrar(newId);
            var newClient = clienteHelper.ObterPorId(newId);

            //assert

            Assert.True(newClient.Id == newId);
        }

        [Fact(DisplayName = "Novo Cliente INválido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarInvalido()
        {
            //arrange
            var newId = Guid.Empty;

            //act


            //assert

            var exception = Assert.Throws<AggregateException>(() => clienteHelper.Cadastrar(newId));

            Assert.Equal("Id inválido", exception.InnerException.Message);

        }


    }
}
