using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IProdutoService
{
    Produto AdicionarProdutos(Produto produto);
    List<Produto> ExibirProdutos();
    Produto AtualizarProduto(Produto produto);
    Produto VenderProduto(int id, int quantidadeDesejada);
    Produto ExibirProdutoPorId(int id);

}
