# Locadora

Projeto de teste sobre locadora com endpoints para Filmes, Clientes e Locacoes 

Esta sendo usando InMemoryDatabase para persistencia, EF Core

Dividido em 3 projetos, API, Business (Services) e Data (Persistencia)

Um projeto usando XUnit para testes na camada de services com Persistencia em memoria.

Todos Ids sao GUID

# API Filmes:

POST

https://localhost:5001/api/filmes/Adicionar

Body:

{
    "nome": "The Lord of the Rings",
    "lancamento": "2002-01-01",
    "quantidadeDisponivel": 1,
    "ativo": true,
    "id": "cc88dc57-d0ac-4384-aca8-fa6afdb2b29c"
}


GET

https://localhost:5001/api/filmes

https://localhost:5001/api/filmes/cc88dc57-d0ac-4384-aca8-fa6afdb2b29c  


# API Clientes:

POST

https://localhost:5001/api/clientes/Adicionar

Body:

{
  "id": "f787b8f7-09d1-4ac1-beae-8ae1d1fe2763",
  "Nome": "Senhor Chang",
   "ativo": true,
  "Documento": "112233"
}

GET

https://localhost:5001/api/clientes

https://localhost:5001/api/clientes/f787b8f7-09d1-4ac1-beae-8ae1d1fe2763



# Locação

GET

https://localhost:5001/api/locacoes

GET

https://localhost:5001/api/locacoes/cliente/f787b8f7-09d1-4ac1-beae-8ae1d1fe2763

POST

https://localhost:5001/api/locacoes/Alugar

Body:

{
    "clienteId": "f787b8f7-09d1-4ac1-beae-8ae1d1fe2763",
    "filmeId": "cc88dc57-d0ac-4384-aca8-fa6afdb2b29c"
}

POST

https://localhost:5001/api/locacoes/Devolver

Body:


{
    "Id" : "8b8fca22-ecec-461b-ac35-65e539f54beb"
}

o Id acima pode ser obtido pelo GET normal ou https://localhost:5001/api/locacoes/cliente/


# Pontos de melhorias:

Implementar Swagger

Modelo de MVVM com automapper para melhor apresentacao dos dados na API

FluentValidation para validar entidades

Implementação de notificações de regras / validacoes -> para validar mensagem de erro do sistema ou de regra

