using RHAPI.Domain;
using RHAPI.Infra.Dto;

namespace RHAPI.Service.Interfaces;

public interface IProdutoService
{
    // adicionar produtos, exibir produtos disponíveis e atualizar o estoque.
    Produto AdicionarProdutos(CreateProdutoDto produtoDto);
    List<Produto> ExibirProdutosDisponiveis();
    Produto AtualizarProdutoEmEstoque(UpdateProdutoDto produtoDto);
}