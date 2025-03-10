using Microsoft.IdentityModel.Tokens;
using RHAPI.Domain;
using RHAPI.Infra.Dto;
using RHAPI.Service.Interfaces;
using RHAPI.Utils;

namespace RHAPI.Service.Service;


public class ProdutoService : IProdutoService
{
    private readonly List<Produto> _estoque = [];
    public Produto AdicionarProdutos(CreateProdutoDto produtoDto)
    {
        try
        {
            Produto produto =  new(produtoDto.NomeProduto, produtoDto.Preco, produtoDto.QuantidaEstoque);
            _estoque.Add(produto);
            return produto;
        }
        catch (Exception) { throw; }
    }

    public Produto AtualizarProdutoEmEstoque(UpdateProdutoDto produtoDto)
    {
        try
        {
            int index = _estoque.FindIndex(p => p.Id == produtoDto.Id);

            Produto produto = _estoque[index] ?? throw new CustomerException("Produto não foi encontrado");

            produto.NomeProduto = produtoDto.NomeProduto ?? produto.NomeProduto;
            produto.Preco = produtoDto.Preco.HasValue && produtoDto.Preco > 0 ? (decimal)produtoDto.Preco : produto.Preco;
            produto.QuantidaEstoque = produtoDto.QuantidaEstoque.HasValue && produtoDto.QuantidaEstoque > 0 ? produto.QuantidaEstoque + (int)produtoDto.QuantidaEstoque : produto.QuantidaEstoque;

            _estoque[index] = produto;

            return produto;

        }
        catch (Exception) { throw; }
    }

    public List<Produto> ExibirProdutosDisponiveis()
    {
        List<Produto> produtos = _estoque.FindAll(produto => produto.QuantidaEstoque > 0);

        if (produtos.IsNullOrEmpty()) throw new CustomerException("Não existe produtos em estoque.");

        return [.. produtos];
    }
}