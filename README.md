# APIs usando .NET 8


## TO-DO:

> As Seguintes tarefas devem ser realizadas para finalização do projeto:

#### Geral:
- [X] Ao realizar o cadastro, deleção ou atualização de um item (colaborador/empresa), retornar a mensagem de sucesso ou erro da operação.
- [X] Caso os itens buscados por id não houverem retorno (null) retornar o código 404 NotFound na Controller.
- [ ] Realizar a busca paginando os resultados de acordo com a quantidade de itens, e a página que o usuário solicita.
- [ ] Realizar a validação para caso o array com os itens esteja em branco, retornar uma mensagem dizendo que não foram encontrados registros para aquela página


#### Colaborador:
- [X] Implementar a lógica de CRUD para a classe de Colaborador .
- [X] Realizar a validação dos dados de entrada do Colaborador.
- [X] Criar DTO para receber no processo de cadastro do colaborador, todos os dados do mesmo EXCETO o ColaboradorID que é autoincrementado.
- [X] Realizar a validação de CPF do colaborador.
- [X] Quando a busca do colaborador for realizada, retornar a empresa a qual ele está atrelado. Seja a busca de todas as empresas, ou a busca por ID (Faça as devidas alterações para tal).



### Ferramentas utilizadas:

|Ferramenta | Descricão |
|-----------|-----------|
|ASP.NET 8  | Framework utilizado para construção das APIs|
|Entity Framework Core | ORM utilizado para comunicação da aplicação com o banco|
|Dapper | Micro ORM utilizado para leitura e persistência dos dados|
|Swagger | Ferramenta para documentação e testes de rotas| 

#### Roteiro da criação da aplicação:
- [x] Criação do template da API.
- [X] Criação das Models.
- [X] Criação do Contexto das Models.
- [X] Criação dos diretórios Infra/Repositories.
- [X] Criação dos diretórios Application/Services.
- [X] Implementação da lógica da aplicação.
  
#### Funcionamento da aplicação:

> A aplicação deve receber os dados dos colaboradores e empresas onde cada empresa pode ter N colaboradores, mas um colaborador está atrelado somente a uma empresa.

```csharp
public class Colaborador
{
    public int ColaboradorID {get; set;}
    public string Nome {get; set;}
    public string Cpf {get; set;}
    public int matricula {get; set;}
}


public class Empresa
{
    public int EmpresaID {get; set;}
    public string Nome {get; set;}
}
```

> A aplicação deve realizar o CRUD das duas classes, incluindo novos colaboradores e novas empresas. As rotas precisam ser:

- [X] Inserção de dados (colaborador/empresa).
- [X] Busca de todos os itens (colaborador/empresa).
- [X] Busca por Id (colaborador/empresa).
- [X] Deleção por Id (colaborador/empresa).
- [X] Atualizar por Id (colaborador/empresa).

> Obs: Utilize os verbos HTTP correspondentes para cada implementação nas rotas, para que seja condizente o que está sendo processado na aplicação, e o que a rota indica.


## Materiais de Apoio:

 - Ciclo de vida dos serviços: *[Clique Aqui](https://medium.com/@marcofsjrr/explorando-os-ciclos-de-vida-de-servi%C3%A7os-no-net-core-mecanismos-da-inje%C3%A7%C3%A3o-de-depend%C3%AAncia-b4609d616d53)*
 - Documentação Dapper: *[Clique Aqui](https://www.learndapper.com/)*
 - Padrão Repository: *[Clique Aqui](https://www.macoratti.net/11/10/net_pr1.htm)*

<!-- ## Desafio

*[Clique Aqui](https://sudden-manchego-90e.notion.site/APIs-usando-NET-8-1a0f51a76f4c80f68099dd3f867ccb61)* para acessar o desafio. -->
