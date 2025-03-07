using RH.API.Domain;

namespace RH.API.Services.Interface
{
    public interface IContaBancariaService
    {
        (bool Sucesso, string Mensagem) AdicionarContaBancaria(ContaBancaria contaBancaria);
        (bool Sucesso, string Mensagem, decimal NovoSaldo) Depositar(int idConta, decimal valor);
        (bool Sucesso, string Mensagem, decimal NovoSaldo) Sacar(int idConta, decimal valor);
        decimal? ObterSaldo(int idConta);
    }
}
