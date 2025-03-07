using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class EstoqueService : IEstoqueService
{
    public ProdutoDTO AdicionarProduto(ProdutoDTO produtoDTO)
    {
        throw new NotImplementedException();
    }

    public bool AtualizarProduto(ProdutoDTO produtoDTO)
    {
        throw new NotImplementedException();
    }

    public ProdutoDTO BuscarProdutoPorNome(string nome)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<VendaDTO> GerarRelatorioVendas()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProdutoDTO> ListarProdutos()
    {
        throw new NotImplementedException();
    }

    public bool RealizarVenda(string nomeProduto, int quantidade)
    {
        throw new NotImplementedException();
    }

    public bool RemoverProduto(string nome)
    {
        throw new NotImplementedException();
    }
}
