using RH.API.DTOs;

namespace RH.API.Services.Interface;

public interface IProdutoService
{
    IEnumerable<ProdutoDTO> ListarProdutos();
    ProdutoDTO BuscarProdutoPorNome(string nome);
    ProdutoDTO AdicionarProduto(ProdutoDTO produtoDTO);
    bool AtualizarProduto(ProdutoDTO produtoDTO);
    bool RemoverProduto(string nome);
    bool AtualizarEstoque(string nome, int quantidade);
}
