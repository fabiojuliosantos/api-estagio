using System.ComponentModel.DataAnnotations;

namespace RHAPI.Domain;

public class Produto
{
    private static int _nextId = 1;
    public int Id { get; }

    public string? NomeProduto { get; set; }
    public decimal Preco { get; set; }
    public int QuantidaEstoque { get; set; }

    public Produto(string? nomeProduto, decimal preco, int quantidaEstoque)
    {
        Id = _nextId++;
        NomeProduto = nomeProduto;
        Preco = preco;
        QuantidaEstoque = quantidaEstoque;
    }
}