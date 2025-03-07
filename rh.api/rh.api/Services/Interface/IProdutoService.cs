using rh.api.Domain;
using rh.api.Dto;

namespace rh.api.Services.Interface
{
    public interface IProdutoService
    {
        List<Produto> ListarProdutos();
        Produto AdicionarProduto(ProdutoDto produto);
        ProdutoDto AtualizarEstoque(int id, ProdutoDto produtoAtualizado);
    }
}