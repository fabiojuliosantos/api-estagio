using RH.API.Domain.Entities.TestePOO;
using RH.API.Services.Interface.TestePOO;

namespace RH.API.Services.Services.TestePOO;

public class ProdutoService : IProdutoService
{
    private readonly List<Produto> _produtos = [];
    public Task<bool> AtualizarProduto(Produto produto)
    {
        try
        {
            Produto produtoAntigo = _produtos.FirstOrDefault(p => p.Id == produto.Id);

            if (produtoAntigo == null) throw new Exception("Produto não registrado!");

            if (produto.Preco <= 0) throw new Exception("Preço inserido inválido!");

            if (produto.QtdEstoque <= 0) throw new Exception("Quantidade em estoque inserida inválida!");

            else
            {
                // Obtém o índice do produto encontrado na lista
                int index = _produtos.IndexOf(produtoAntigo);

                // Substitui o produto antigo pelo novo
                _produtos[index] = produto;

                return Task.FromResult(true);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    public Task<List<Produto>> BuscarTodosProdutos()
    {
        try
        {
            if (_produtos.Count() == 0)
                throw new Exception("Não há produtos cadastrados!");
            else
            {
                List<Produto> produtos = _produtos;
                return Task.FromResult(produtos);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<bool> InserirProduto(Produto produto)
    {
        try
        {
            if (_produtos.Any(p => p.Id == produto.Id)) throw new Exception("O ID informado já está cadastrado!");

            if (produto.Preco <= 0) throw new Exception("Preço inserido inválido!");

            if (produto.QtdEstoque <= 0) throw new Exception("Quantidade em estoque inserida inválida!");

            else
            {
                _produtos.Add(produto);
                return Task.FromResult(true);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
