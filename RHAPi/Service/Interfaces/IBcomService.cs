using RHAPI.Domain;

namespace RHAPI.Service.Interfaces;

public interface IBcomService
{
    Bcom CriarConta(Bcom contaBancaria);
    decimal Depositar(decimal valorDeposito);
    decimal Sacar(decimal ValorSaque, Bcom ContaASacar);
    decimal ExibirSaldo();
}