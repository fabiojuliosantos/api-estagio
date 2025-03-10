using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IVendaService
{
    Venda AdicionarNovaVenda(Venda venda);
    List<Venda> GerarRelatório();
}
