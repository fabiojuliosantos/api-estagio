using RH.API.Domain.Entities.TestePOO;

namespace RH.API.Services.Interface.TestePOO;

public interface IBcomService
{
    Task<bool> Depositar(string numeroConta, string deposito);
    Task<bool> Sacar(string numeroConta, string saque);
    Task<double> ExibirSaldo(string numeroConta);
    Task<bool> InserirConta(Bcom bcom);
}
