using RH.API.Data.Dtos;
using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IbcomService
{

    RespostaDTO ExibirSaldo(int numeroConta);
    RespostaDTO CriarConta(Bcom bcom);
    RespostaDTO Sacar(int numeroConta,double saque);
    RespostaDTO Depositar(int numeroConta, double valor);

}
