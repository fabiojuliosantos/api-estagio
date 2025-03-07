using RH.API.DTOs;

namespace RH.API.Services.Interface;

public interface IEstoqueService
{
    IEnumerable<ProdutoDTO> ListarProdutos();
    ProdutoDTO BuscarProdutoPorNome(string nome);
    ProdutoDTO AdicionarProduto(ProdutoDTO produtoDTO);
    bool AtualizarProduto(ProdutoDTO produtoDTO);
    bool RemoverProduto(string nome);
    bool RealizarVenda(string nomeProduto, int quantidade);
    IEnumerable<VendaDTO> GerarRelatorioVendas();
}
