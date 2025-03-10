using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RH.API.Data.Dtos;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class ProdutosService : IprodutoService
{
    private readonly DatabaseTemp _database;
    private readonly IMapper _mapper;

    public ProdutosService(DatabaseTemp database, IMapper mapper)
    {
        _database = database;
        _mapper = mapper;
    }

    public RespostaDTO AdicionarProduto(CriarProdutoDto produtoDto)
    {
        try
        {
            if (string.IsNullOrEmpty(produtoDto.Nome))
            {
                return new RespostaDTO(false, "Nome do produto não pode ser vazio!");
            }
            if (produtoDto.Preco <= 0)
            {
                return new RespostaDTO(false, "Preço do produto não pode ser menor que zero!");
            }
            if (produtoDto.QtdEstoque < 0)
            {
                return new RespostaDTO(false, "Quantidade no estoque não pode ser negativa!");
            }

            var produto = _mapper.Map<Produtos>(produtoDto);
            produto.ProdutoId = _database.Produtos.Count + 1;
            _database.Produtos.Add(produto);

            return new RespostaDTO(true, "Produto cadastrado com sucesso");
        }
        catch
        {
            return new RespostaDTO(false, "Erro ao adicionar produto");
        }
    }

    public RespostaDTO AtualizarProduto(int id, Produtos produto)
    {
        try
        {
            var produtoExistente = _database.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produtoExistente == null)
            {
                return new RespostaDTO(false, "Nenhum produto foi encontrado");
            }

            if (string.IsNullOrEmpty(produto.Nome))
            {
                return new RespostaDTO(false, "Nome do produto não pode ser vazio!");
            }
            if (produto.Preco <= 0)
            {
                return new RespostaDTO(false, "Preço do produto não pode ser menor que zero!");
            }
            if (produto.QtdEstoque < 0)
            {
                return new RespostaDTO(false, "Quantidade no estoque não pode ser negativa!");
            }

            produtoExistente.Nome = produto.Nome;
            produtoExistente.Preco = produto.Preco;
            produtoExistente.QtdEstoque = produto.QtdEstoque;

            return new RespostaDTO(true, "Produto atualizado com sucesso!");
        }
        catch
        {
            return new RespostaDTO(false, "Erro ao atualizar produto");
        }
    }

    public RespostaDTO ExibirProdutosPorId(int produtoId)
    {
        try
        {
            var produto = _database.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (produto == null)
            {
                return new RespostaDTO(false, "Produto não encontrado");
            }

            return new RespostaDTO(true, $"Nome: {produto.Nome}, Preço: {produto.Preco:C}, Quantidade no Estoque: {produto.QtdEstoque}");
        }
        catch
        {
            return new RespostaDTO(false, "Erro ao exibir produto");
        }
    }

    public List<Produtos> ExibirTodosProdutos()
    {
        try
        {
            if (!_database.Produtos.Any())
            {
                throw new Exception("Nenhum produto na lista");
            }
            return _database.Produtos;
        }
        catch (Exception ex)
        {
            throw new Exception("Ocorreu um erro ao processar a lista de produtos. Detalhes: " + ex.Message);
        }
    }
}
