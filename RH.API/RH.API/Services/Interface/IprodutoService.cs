using RH.API.Data.Dtos;
using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IprodutoService
{
    RespostaDTO AdicionarProduto(CriarProdutoDto produtoDto);

    RespostaDTO ExibirProdutosPorId(int ProdutoID);

    List<Produtos> ExibirTodosProdutos();

    RespostaDTO AtualizarProduto(int id, Produtos produtos);
}
