<center><h1>Documentação ClientsAPI</h1></center>

<h4>Tecnologias utilizadas<h4>

- **.Net 7**
- **Entity Framework**
- **SQL Server**
- **Microsoft Azure**

O Projeto **ClientsAPI** é uma API desenvolvida seguindo o padrão de MinimalAPI com as tecnologias listadas acima, as definições de uso dos endpoints seguem o formato das API padrões C# os verbos utilizados serão os **GET**, **POST**, **PUT** e **DELETE**.

Abaixo seguirá o contrato de como as respostas em _JSON_ serão retornadas e como os _REQUEST_ deverão ser enviadas a aplicação, sendo que a aplicação tem configurada o **Swagger** para facilitar tanto a documentação quanto os testes de desenvolvimento e está hospedada na Azure.

> Caso opte pela utilização do Postman, na raiz do projeto se encontra uma pasta com o nome _Postman_ contendo uma coleção com as requisições e os testes unitários dos endpoints.

**Listagem de cliente(s)**

- URL : <https://cnpclientsapi.azurewebsites.net/clients> / <https://cnpclientsapi.azurewebsites.net/clients/{id}>
- Verbo : **GET**

**Response**

```json
{
  "id": 0,
  "nome": "string",
  "dtNascimento": "2022-01-01T11:22:33.456Z",
  "status": 0,
  "datInclusao": "2022-01-01T11:22:33.456Z",
  "clienteEnderecos": [
    {
      "id": 0,
      "idCliente": 0,
      "logradouro": "string",
      "cep": "string",
      "uf": "uf",
      "cidade": "string",
      "bairro": "string",
      "status": 0,
      "datInclusao": "2022-01-01T11:22:33.456Z"
    }
  ]
}
````

**Criar cliente**

- URL : <https://cnpclientsapi.azurewebsites.net/clients>
- Verbo : **POST**

**Body**

```json
{
  "nome": "string",
  "dtNascimento": "2022-01-01T11:22:33.456Z",
  "status": 0,
  "clienteEnderecos": [
    {
      "logradouro": "string",
      "cep": "string",
      "uf": "uf",
      "cidade": "string",
      "bairro": "string",
      "status": 0
    }
  ]
}
````

**Alterar Cliente e Endereços**

- URL : <https://cnpclientsapi.azurewebsites.net/clients>
- Verbo : **PUT**

**Body**

```json
{
  "id": 0,
  "nome": "string",
  "dtNascimento": "2022-01-01T11:22:33.456Z",
  "status": 0,
  "datInclusao": "2022-01-01T11:22:33.456Z",
  "clienteEnderecos": [
    {
	  "id": 0,
      "logradouro": "string",
      "cep": "string",
      "uf": "uf",
      "cidade": "string",
      "bairro": "string",
      "status": 0
    }
  ]
}
````

> **Observação:**  Caso algum endereço da lista de endereços não tenha seu ID informado, a API entenderá que é um novo endereço a ser adicionado ao cliente


**Excluir Cliente**

- URL : <https://cnpclientsapi.azurewebsites.net/clients/{id}>
- Parâmetro: ID = Identificador do cliente
- Verbo : **DELETE**

> **Observação:**  Caso o cliente tenha endereços relacionados a ele, todos endereços dele serão excluídos.
