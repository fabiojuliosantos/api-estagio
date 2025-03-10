using Microsoft.AspNetCore.Mvc.Formatters;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class ProdutoService : IProdutoService
{
    List<Produto> produtos = new List<Produto>();
    int id = 1;
    public Produto AdicionarProdutos(Produto produto)
    {
        try
        {
            if (produto == null)
            {
                throw new Exception("O produto é inválido!");
            }
            else if (produtos.Find(p => p.Id == produto.Id) != null)
            {
                throw new Exception($"O produto com id {produto.Id} já existe!");
            }
            else
            {
                produto.Id = id;
                produtos.Add(produto);
                id++;
                return produto;
            }

        }
        catch (Exception e) { throw e; }
    }

    public Produto AtualizarProduto(Produto produto)
    {
        try
        {
            if (produto == null) throw new Exception("Produto inválido!");
            else if (produtos.Find(p => p.Id == produto.Id) == null)
            {
                throw new Exception($"O produto com id {produto.Id} não foi encontrado.");
            }
            else
            {
                var produtoParaAtualizar = produtos.Find(p => p.Id == produto.Id);
                produtoParaAtualizar.Nome = produto.Nome;
                produtoParaAtualizar.Preco = produto.Preco;
                produtoParaAtualizar.QuantidadeEmEstoque = produto.QuantidadeEmEstoque;
                return produto;
            }

        }
        catch (Exception e) { throw e; }
    }

    public Produto ExibirProdutoPorId(int id)
    {
        try
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                throw new Exception($"O Produto com id {id} não foi encontrado!");
            }
            else
            {
                return produto;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public List<Produto> ExibirProdutos()
    {
        try
        {
            return produtos;
        }
        catch (Exception e) { throw e; }
    }

    public Produto VenderProduto(int id, int quantidadeDesejada)
    {
        try
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                throw new Exception($"O Produto com id {id} não foi encontrado!");
            }
            else
            {
                produto.QuantidadeEmEstoque -= quantidadeDesejada;
                if (produto.QuantidadeEmEstoque <= 0)
                {
                    var novoProduto = produto;
                    produto = null;
                    return novoProduto;
                }
                else
                {
                    return produto;
                }
            }
        }
        catch (Exception e) { throw e; }
    }
}
