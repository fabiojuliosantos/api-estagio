using RHAPi.Infra.Dto;
using RHAPI.Domain;
using RHAPI.Infra.Dto;

namespace RHAPI.Service.Interfaces;

public interface IVendaService
{
    Produto CadastraProduto(CreateProdutoDto produtoDto);
    Venda VendaProduto(CreateVendaDto vendaDto);
    Produto ConsultaProdutoEmEstoque(int id);
    List<Venda> GeraRelatorioVenda();
}