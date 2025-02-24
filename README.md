# APIs usando .NET 8

### Ferramentas utilizadas:

|Ferramenta | Descricão |
|-----------|-----------|
|ASP.NET 8  | Framework utilizado para construção das APIs|
|Entity Framework Core | ORM utilizado para comunicação da aplicação com o banco|
|Dapper | Micro ORM utilizado para leitura e persistência dos dados|
|Swagger | Ferramenta para documentação e testes de rotas| 

#### Roteiro da criação da aplicação:
- [ ] Criação do template da API.
- [ ] Criação das Models.
- [ ] Criação do Contexto das Models.
- [ ] Criação e Execução das migrações.
- [ ] Criação dos diretórios Infra/Repositories.
- [ ] Criação dos diretórios Application/Services.
- [ ] Implementação da lógica da aplicação.
  
#### Funcionamento da aplicação:

> A aplicação deve receber os dados dos colaboradores e empresas onde cada empresa pode ter N colaboradores, mas um colaborador está atrelado somente a uma empresa.

```csharp
public class Colaborador
{
    public int ColaboradorID {get; set;}
    public string Nome {get; set;}
    public string Cpf {get; set;}
    public int matricula
}


public class Empresa
{
    public int EmpresaID {get; set;}
    public string Nome{get; set;}
}
```

> A aplicação deve realizar o CRUD das duas classes, incluindo novos colaboradores e novas empresas. As rotas precisam ser:

- [ ] Inserção de dados (colaborador/empresa).
- [ ] Busca de todos os itens (colaborador/empresa).
- [ ] Busca por Id (colaborador/empresa).
- [ ] Deleção por Id (colaborador/empresa).
- [ ] Atualizar por Id (colaborador/empresa).

> Obs: Utilize os verbos HTTP correspondentes para cada implementação nas rotas, para que seja condizente o que está sendo processado na aplicação, e o que a rota indica.


## Desafio

*[Clique Aqui](https://sudden-manchego-90e.notion.site/APIs-usando-NET-8-1a0f51a76f4c80f68099dd3f867ccb61)* para acessar o desafio.