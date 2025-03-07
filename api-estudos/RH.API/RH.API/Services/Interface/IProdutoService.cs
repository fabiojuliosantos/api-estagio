using RH.API.Dto;

namespace RH.API.Services.Interface
{
    public interface IProdutoService
    {
        (bool Sucesso, string Mensagem, ProdutoGetDto Produto) AdicionarProduto(ProdutoDto produtoDto);
        (bool Sucesso, string Mensagem) AtualizarProduto(int id, ProdutoUpdateDto produtoUpdateDto);
        (bool Sucesso, string Mensagem, IEnumerable<ProdutoGetDto> Produtos) ObterProdutos();

    }
}
