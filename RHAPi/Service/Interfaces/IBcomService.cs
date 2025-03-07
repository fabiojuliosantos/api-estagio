using RHAPI.Domain;
using RHAPI.Infra.Dto;

namespace RHAPI.Service.Interfaces;

public interface IBcomService
{
    Bcom CriarConta(CreateBcomDto contaBancaria);
    string Depositar(decimal valorDeposito, string numeroConta);
    string Sacar(decimal ValorSaque, string numeroConta);
    string ExibirSaldo(string numeroConta);
}