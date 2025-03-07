using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IBcomService
{
    Bcom CriarConta(Bcom conta);
    bool Depositar(int numeroDaConta, double valor);
    int Sacar(int numeroDaConta, double valor);
    Bcom ExibirSaldo(int numeroDaConta);
}
