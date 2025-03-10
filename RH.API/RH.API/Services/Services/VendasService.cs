using RH.API.Data.Dtos;
using RH.API.Domain;
using RH.API.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.API.Services.Services;

public class VendasService : IVendasService
{
    private readonly DatabaseTemp _database;

    public VendasService(DatabaseTemp database)
    {
        _database = database;
    }

    public RespostaDTO ConsultaEstoque(int produtoId)
    {
        try
        {
            if (produtoId <= 0)
            {
                return new RespostaDTO(false, "Insira um Id válido");
            }

            var produto = _database.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            return produto == null
                ? new RespostaDTO(false, "Produto não encontrado")
                : new RespostaDTO(true, $"Estoque: {produto.QtdEstoque}");
        }
        catch
        {
            return new RespostaDTO(false, "Erro na consulta de estoque");
        }
    }

    public async Task<RelatorioVendaDto> RelatorioVendas(int id)
    {
        var venda = _database.Vendas.FirstOrDefault(v => v.IdVenda == id)
            ?? throw new KeyNotFoundException($"Venda com ID {id} não encontrada");

        var produto = _database.Produtos.FirstOrDefault(p => p.ProdutoId == venda.ProdutoId)
            ?? throw new KeyNotFoundException($"Produto com ID {venda.ProdutoId} não encontrado");

        return new RelatorioVendaDto
        {
            IdVenda = venda.IdVenda,
            HoraVenda = venda.HoraVenda,
            NomeProduto = produto.Nome,
            ValorTotal = venda.ValorTotal,
            QuantidadeVendida = venda.QuantidadeVendida
        };
    }

    public RespostaDTO VenderProduto(int produtoId, int quantidadeVendida)
    {
        try
        {
            if (produtoId <= 0 || quantidadeVendida <= 0)
            {
                return new RespostaDTO(false, "Dados inválidos");
            }

            var produto = _database.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (produto == null)
            {
                return new RespostaDTO(false, "Não existe esse produto");
            }

            if (quantidadeVendida > produto.QtdEstoque)
            {
                return new RespostaDTO(false, $"Estoque insuficiente. Disponível: {produto.QtdEstoque}");
            }

            produto.QtdEstoque -= quantidadeVendida;

            var venda = new Venda
            {
                IdVenda = _database.Vendas.Count + 1,
                HoraVenda = DateTime.Now,
                ProdutoId = produtoId,
                QuantidadeVendida = quantidadeVendida,
                ValorTotal = quantidadeVendida * produto.Preco
            };

            _database.Vendas.Add(venda);

            return new RespostaDTO(true, $"Venda realizada com sucesso {venda}");
        }
        catch
        {
            return new RespostaDTO(false, "Erro interno ao processar venda");
        }
    }
}
