using Locadora.Business.Interfaces;
using Locadora.Business.Models;
using Locadora.Business.Services;
using Locadora.Data.Repository;
using Locadora.Tests.Filme;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using Xunit;

namespace Locadora.Tests.Filme
{
    public class FilmeTest
    {
        FilmeHelper filmeHelper;

        public FilmeTest()
        {
            var db = new ConnectionFactory().CreateContextForInMemory();
            filmeHelper = new FilmeHelper(db);
        }

        [Fact(DisplayName = "Novo Filme Válido")]
        [Trait("Categoria", "Filme Trait Testes")]
        public void Filme_NovoFilme_DeveEstarValido()
        {
            //arrange
            var newId = Guid.NewGuid();

            //act
            filmeHelper.Cadastrar(newId, "Titanic", 1);
            var newClient = filmeHelper.ObterPorId(newId);

            //assert

            Assert.True(newClient.Id == newId);
        }

        [Fact(DisplayName = "Novo Filme INválido")]
        [Trait("Categoria", "Filme Trait Testes")]
        public void Filme_NovoFilme_DeveEstarInvalido()
        {
            //arrange
            var newId = Guid.Empty;

            //act
            var exception = Assert.Throws<AggregateException>(() => filmeHelper.Cadastrar(newId, "Titanic", 1 ));

            //assert
            Assert.Equal("Id invalido", exception.InnerException.Message);

        }


    }
}
