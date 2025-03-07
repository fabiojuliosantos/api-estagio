using RH.API.Domain;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class ProdutoService : IProdutoService
{

    private static List<Produto> _produtos = new();
    private static int _proximoId = 1;
    public ProdutoDTO AdicionarProduto(ProdutoDTO produtoDTO)
    {
        try
        {
            if (string.IsNullOrEmpty(produtoDTO.Nome))
            {
                throw new Exception("o nome do produto é obrigatorio");
            }
            if (_produtos.Any(p => p.Nome == produtoDTO.Nome))
            {
                throw new Exception("ja existe um produto com esse nome");
            }
            if (produtoDTO.Preco <= 0 || produtoDTO.QtdEstoque < 0)
            {
                throw new Exception("Preco  quantidade em estoque devem ser valores positivo");
            }

            var novoProduto = new Produto
            {
                Id = _proximoId++,
                Nome = produtoDTO.Nome,
                Preco = Math.Round(produtoDTO.Preco, 2),
                QtdEstoque = produtoDTO.QtdEstoque
            };

            _produtos.Add(novoProduto);

            return new ProdutoDTO
            {
                Nome = novoProduto.Nome,
                Preco = Math.Round(novoProduto.Preco, 2),
                QtdEstoque = novoProduto.QtdEstoque
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool AtualizarEstoque(string nome, int quantidade)
    {
        try
        {
            var produto = _produtos.FirstOrDefault(p => p.Nome == nome);
            if (produto == null)
            {
                return false;
            }
            if (produto.QtdEstoque + quantidade < 0)
            {
                throw new Exception("quantidade em estoque nao pode ser negativa");
            }

            produto.QtdEstoque = produto.QtdEstoque + quantidade;
            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool AtualizarProduto(ProdutoDTO produtoDTO)
    {
        try
        {
            var produtoExistente = _produtos.FirstOrDefault(p => p.Nome == produtoDTO.Nome);
            if (produtoExistente == null)
            {
                return false;
            }

            produtoExistente.Preco = Math.Round(produtoDTO.Preco, 2);
            produtoExistente.QtdEstoque = produtoDTO.QtdEstoque;

            return true;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public ProdutoDTO BuscarProdutoPorNome(string nome)
    {
        try
        {
            var produto = _produtos.FirstOrDefault(p => p.Nome == nome);
            if (nome == null)
            {
                return null;
            }
            return new ProdutoDTO
            {
                Nome = produto.Nome,
                Preco = Math.Round(produto.Preco, 2),
                QtdEstoque = produto.QtdEstoque
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<ProdutoDTO> ListarProdutos()
    {
        try
        {
            return _produtos.Select(p => new ProdutoDTO
            {
                Nome = p.Nome,
                Preco = Math.Round(p.Preco, 2),
                QtdEstoque = p.QtdEstoque
            });
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool RemoverProduto(string nome)
    {
        try
        {
            var produto = _produtos.FirstOrDefault(p => p.Nome == nome);
            if (produto == null)
            {
                return false;
            }
            return _produtos.Remove(produto);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
