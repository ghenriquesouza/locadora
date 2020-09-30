using Locadora.Tests.Cliente;
using Locadora.Tests.Filme;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Locadora.Tests.Locacao
{
    public class LocacaoTest
    {
        LocacaoHelper helper;
        FilmeHelper filmeHelper;
        ClienteHelper clienteHelper;

        public LocacaoTest()
        {
            var db = new ConnectionFactory().CreateContextForInMemory();
            helper = new LocacaoHelper(db);
            filmeHelper = new FilmeHelper(db);
            clienteHelper = new ClienteHelper(db);

        }

        [Fact(DisplayName = "Nova Locacao Válida")]
        [Trait("Categoria", "Locacao Trait Testes")]
        public void Locacao_NovaLocacao_DeveEstarValida()
        {
            //arrange
            var newClienteId = Guid.NewGuid();
            var newFilmeId = Guid.NewGuid();
            var newIdLocacao = Guid.NewGuid();
            //ACT
            filmeHelper.Cadastrar(newFilmeId, "Titanic", 1);
            clienteHelper.Cadastrar(newClienteId);

            helper.Alugar(newIdLocacao, newClienteId, newFilmeId);
            var locacaoNova = helper.ObterPorId(newIdLocacao);
            //assert
            
            Assert.True(locacaoNova.Id == newIdLocacao);
        }

        [Fact(DisplayName = "Nova Locacao Filme Indisponivel")]
        [Trait("Categoria", "Locacao Trait Testes")]
        public void Locacao_NovaLocacao_FilmeIndisponivel()
        {
            //arrange
            var newClienteId = Guid.NewGuid();
            var segundoClienteId = Guid.NewGuid();
            var newFilmeId = Guid.NewGuid();
            var newIdLocacao = Guid.NewGuid();
            //ACT
            filmeHelper.Cadastrar(newFilmeId, "Taxi Driver", 1);
            clienteHelper.Cadastrar(newClienteId);
            clienteHelper.Cadastrar(segundoClienteId);

            helper.Alugar(newIdLocacao, newClienteId, newFilmeId);
            var locacaoNova = helper.ObterPorId(newIdLocacao);

            //act
            var exception = Assert.Throws<AggregateException>(() => helper.Alugar(newIdLocacao, segundoClienteId, newFilmeId));

            //assert
            Assert.Equal("O Filme esta indisponivel", exception.InnerException.Message);

        }

        [Fact(DisplayName = "Nova Locacao Filme Repetido")]
        [Trait("Categoria", "Locacao Trait Testes")]
        public void Locacao_NovaLocacao_FilmeRepetido()
        {
            //arrange
            var newClienteId = Guid.NewGuid();
            var newFilmeId = Guid.NewGuid();
            var newIdLocacao = Guid.NewGuid();
            //ACT
            filmeHelper.Cadastrar(newFilmeId, "Titanic", 1);
            clienteHelper.Cadastrar(newClienteId);
            

            helper.Alugar(newIdLocacao, newClienteId, newFilmeId);
            var locacaoNova = helper.ObterPorId(newIdLocacao);

            //act
            var exception = Assert.Throws<AggregateException>(() => helper.Alugar(newIdLocacao, newClienteId, newFilmeId));

            //assert
            Assert.Equal("O Filme já foi locado anteriormente", exception.InnerException.Message);

        }

        [Fact(DisplayName = "Nova Devolucao Valida")]
        [Trait("Categoria", "Locacao Trait Testes")]
        public void Locacao_Devolucao_Valida()
        {
            //arrange
            var newClienteId = Guid.NewGuid();
            var newFilmeId = Guid.NewGuid();
            var newIdLocacao = Guid.NewGuid();

            //ACT
            filmeHelper.Cadastrar(newFilmeId, "Titanic", 1);
            clienteHelper.Cadastrar(newClienteId);
            helper.Alugar(newIdLocacao, newClienteId, newFilmeId);

            var mensagemRetorno = helper.Devolver(newIdLocacao);

            //assert
            Assert.Equal("Devolucao realizada com sucesso", mensagemRetorno);

        }

        [Fact(DisplayName = "Nova Devolucao InValida")]
        [Trait("Categoria", "Locacao Trait Testes")]
        public void Locacao_Devolucao_InValida()
        {
            //arrange
            var newClienteId = Guid.NewGuid();
            var newFilmeId = Guid.NewGuid();
            var newIdLocacao = Guid.NewGuid();

            //ACT
            filmeHelper.Cadastrar(newFilmeId, "The Lord of the Rings", 1);
            clienteHelper.Cadastrar(newClienteId);
            helper.Alugar(newIdLocacao, newClienteId, newFilmeId);

            helper.Devolver(newIdLocacao);

            
            var exception = Assert.Throws<AggregateException>(() => helper.Devolver(newIdLocacao));

            //assert
            Assert.Equal("Devolucao ja realizada", exception.InnerException.Message);


        }


        [Fact(DisplayName = "Nova Devolucao Atrasada")]
        [Trait("Categoria", "Locacao Trait Testes")]
        public void Locacao_Devolucao_Atrasada()
        {
            //arrange
            var newClienteId = Guid.NewGuid();
            var newFilmeId = Guid.NewGuid();
            var newIdLocacao = Guid.NewGuid();

            //ACT
            filmeHelper.Cadastrar(newFilmeId, "Matrix", 1);
            clienteHelper.Cadastrar(newClienteId);
            helper.Alugar(newIdLocacao, newClienteId, newFilmeId);

            var locacao = helper.ObterPorId(newIdLocacao);
            locacao.Inicio = locacao.Inicio.AddDays(-10);
            helper.Atualizar(locacao);

            var mensagemRetorno = helper.Devolver(newIdLocacao);

            //assert
            Assert.Equal("Devolucao com atraso", mensagemRetorno);


        }

    }
}
