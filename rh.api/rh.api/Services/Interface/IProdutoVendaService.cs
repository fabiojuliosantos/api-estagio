using rh.api.Dto;

namespace rh.api.Services
{
    public interface IProdutoVendaService
    {
        Task CadastrarProduto(ProdutoVendaDto produtoDto);
        Task<VendaResult> VenderProduto(int produtoId, int quantidade);
        Task<ProdutoVenda> ConsultarEstoque(int produtoId);
        Task<List<ProdutoVenda>> GerarRelatorioVendas();
        Task<List<ProdutoVenda>> ListarProdutos();
    }
}