using RHAPi.Infra.Dto;
using RHAPI.Domain;
using RHAPI.Infra.Dto;
using RHAPI.Service.Interfaces;
using RHAPI.Utils;

namespace RHAPI.Service.Service;

public class VendaService : IVendaService
{
    public List<Venda> ListaVendas { get; set; } = [];
    public List<Produto> ListaProdutos { get; set; } = [];
    public Produto CadastraProduto(CreateProdutoDto produtoDto)
    {
        Produto produto = new(produtoDto.NomeProduto, produtoDto.Preco, produtoDto.QuantidaEstoque);
        ListaProdutos.Add(produto);
        return produto;
    }

    public Produto ConsultaProdutoEmEstoque(int id)
    {
        Produto produto = ListaProdutos.Find(p => p.Id == id)!;

        if (produto is null)
        {
            throw new CustomerException("Produto não encontrado");
        }

        return produto;
    }

    public List<Venda> GeraRelatorioVenda()
    {
        return [.. ListaVendas];
    }

    public Venda VendaProduto(CreateVendaDto vendaDto)
    {
        int index = ListaProdutos.FindIndex(p => p.Id == vendaDto.ProdutoId)!;
        
        if (index == -1)
        {
            throw new CustomerException("Produto não encontrado");
        }
        
        var produto = ListaProdutos[index];

        produto.QuantidaEstoque -= vendaDto.Quantidade;

        ListaProdutos[index] =  produto;

        var valorVenda = vendaDto.Quantidade * produto.Preco;

        Venda venda = new(produto, vendaDto.Quantidade, valorVenda);
        ListaVendas.Add(venda);

        return venda;
    }
}