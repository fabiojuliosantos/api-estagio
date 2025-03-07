using RH.API.Domain;

namespace RH.API.Services.Interface
{
    public interface IProdutoService
    {
        (bool Sucesso, string Mensagem) AdicionarProduto(Produto produto);
        (bool Sucesso, string Mensagem) AtualizarEstoque(List<Produto> produtos, string nomeProduto, int quantidadeAlteracao);

        List<Produto> ListarProdutos();
    }
}
