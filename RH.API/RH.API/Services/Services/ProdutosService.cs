using System.Globalization;
using AutoMapper;
using RH.API.Data.Dtos;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class ProdutosService : IprodutoService
{
    private static int _proximoId = 1;
    private List<Produtos> _produto = new();

    private readonly IMapper _mapper;

    public ProdutosService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public RespostaDTO AdicionarProduto(CriarProdutoDto produtoDto)
    {
        try
        {
            if (String.IsNullOrEmpty(produtoDto.Nome))
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

            produto.ProdutoId = _proximoId++;

            _produto.Add(produto);
            return new RespostaDTO(true, "Produto cadastrado com sucesso");
        }
        catch (Exception)
        {

            throw;
        }
    }

    public RespostaDTO AtualizarProduto(int id ,Produtos produtos)
    {
        try
        {
            if (String.IsNullOrEmpty(produtos.Nome))
            {
                return new RespostaDTO(false, "Nome do produto não pode ser vazio!");
            }
            if (produtos.Preco <= 0)
            {
                return new RespostaDTO(false, "Preço do produto não pode ser menor que zero!");
            }

            if (produtos.QtdEstoque < 0)
            {

                return new RespostaDTO(false, "Quantidade no estoque não pode ser negativa!");

            }
            var produtoExistente = _produto.FirstOrDefault(p => p.ProdutoId == produtos.ProdutoId);

            if(produtoExistente == null)
            {
                return new RespostaDTO(false, "Nenhum produto foi encotrado");

            }

            produtoExistente.Nome = produtos.Nome;
            produtoExistente.Preco = produtos.Preco;
            produtoExistente.QtdEstoque = produtos.QtdEstoque;

            return new RespostaDTO(true, "Produto atualizado com sucesso! ");
          
            
        }
        catch (Exception)
        {

            throw;
        }
    }

    public RespostaDTO ExibirProdutosPorId(int produtoId)
    {
        try
        {
            var produto = _produto.FirstOrDefault(contas => contas.ProdutoId == produtoId);

            if (produto == null)
            {
                return new RespostaDTO(false, "produto não encontrado");
            }

            return new RespostaDTO(true, $"Nome:{produto.Nome}, Preço: {produto.Preco:C}, Quantidade no Estoque: {produto.QtdEstoque}");
        }
        catch (Exception)
        {

            throw;
        }
    }

    public List<Produtos> ExibirTodosProdutos()
    {
        try
        {

            if (!_produto.Any())
            {
                throw new Exception("Nenhum produto na lista");

            }


            foreach (var produtos in _produto)
            {
                Console.WriteLine($"Nome:{produtos.Nome}, Preço: {produtos.Preco:C}, Quantidade no Estoque: {produtos.QtdEstoque}");

            }
            return _produto;
        }
        catch (Exception ex)
        {
            { throw new Exception("Ocorreu um erro ao processar a lista de estudantes. Detalhes: " + ex.Message); }
        }
    }
}
