using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class VendaService : IVendaService
{
    List<Venda> vendas = new List<Venda>();
    int id = 1;

    public Venda AdicionarNovaVenda(Venda venda)
    {
        try
        {
            if (venda == null)
            {
                throw new Exception("Venda é inválida!");
            }
            else if (vendas.Find(v => v.IdVenda == venda.IdVenda) != null)
            {
                throw new Exception($"A venda com id {venda.IdVenda} já existe!");
            }
            else
            {
                venda.IdVenda = id;
                vendas.Add(venda);
                id++;
                return venda;
            }
        }
        catch (Exception e) { throw e; }
    }

    public List<Venda> GerarRelatório()
    {
        try
        {
            return vendas;
        }
        catch (Exception e) { throw e; }
    }
}
