using RH.API.Domain.Entities.TestePOO;

namespace RH.API.Services.Interface.TestePOO;

public interface IProdutoService
{
    Task<bool> InserirProduto(Produto produto);
    Task<List<Produto>> BuscarTodosProdutos();
    Task<bool> AtualizarProduto(Produto produto);
}
