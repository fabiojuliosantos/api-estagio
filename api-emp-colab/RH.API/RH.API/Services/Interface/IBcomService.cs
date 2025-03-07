using RH.API.Domain;

namespace RH.API.Services.Interface
{
    public interface IBcomService
    {
        (bool Sucesso, string Mensagem) AdicionarConta(Bcom bcom);
        List<Bcom> ListarContasBancarias();
        (bool Sucesso, string Mensagem) Depositar(int numeroConta, double valor);
        (bool Sucesso, string Mensagem) Sacar(int numeroConta, double valor);
        double ExibirSaldo(int numeroConta);
    }
}
