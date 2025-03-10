using RH.API.Domain;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class EstoqueService : IEstoqueService
{
    private static List<ProdutoDTO> _produtos = new();
    private static List<VendaDTO> _vendas = new();

    public ProdutoDTO AdicionarProduto(ProdutoDTO produtoDTO)
    {
        _produtos.Add(produtoDTO);
        return produtoDTO;
    }

    public bool AtualizarProduto(ProdutoDTO produtoDTO)
    {
        var produtoExistente = _produtos.FirstOrDefault(p => p.Nome == produtoDTO.Nome);
        if (produtoExistente == null)
        {
            return false;
        }

        produtoExistente.Preco = produtoDTO.Preco;
        produtoExistente.QtdEstoque = produtoDTO.QtdEstoque;
        return true;
    }

    public ProdutoDTO BuscarProdutoPorId(string id)
    {
        return _produtos.FirstOrDefault(p => p.Nome == id);
    }

    public IEnumerable<VendaDTO> GerarRelatorioVendas()
    {
        return _vendas;
    }

    public IEnumerable<ProdutoDTO> ListarProdutos()
    {
        return _produtos;
    }

    public bool RealizarVenda(string nomeProduto, int quantidade)
    {
        var produto = _produtos.FirstOrDefault(p => p.Nome == nomeProduto);
        if (produto == null || produto.QtdEstoque < quantidade)
        {
            return false;
        }

        produto.QtdEstoque -= quantidade;
        var venda = new VendaDTO
        {
            NomeProduto = nomeProduto,
            Quantidade = quantidade,
            ValorTotal = VendaCalcularValorTotal.CalcularValorTotal(produto.Preco, quantidade)
        };
        _vendas.Add(venda);
        return true;
    }

    public bool RemoverProduto(string nome)
    {
        var produto = _produtos.FirstOrDefault(p => p.Nome == nome);
        if (produto == null)
        {
            return false;
        }

        _produtos.Remove(produto);
        return true;
    }
}
