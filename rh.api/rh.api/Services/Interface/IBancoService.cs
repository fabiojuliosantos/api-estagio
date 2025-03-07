//using rh.api.Domain;

//namespace rh.api.Services.Interface
//{
//    public interface IBancoService
//    {
//        Banco CriarConta(string titular, int numeroConta, decimal saldoInicial);
//        string Depositar(int numeroConta, decimal valor);
//        string Sacar(int numeroConta, decimal valor);
//        string ConsultarSaldo(int numeroConta);
//    }
//}

using rh.api.DTO;

namespace rh.api.Services.Interface
{
    public interface IBancoService
    {
        BancoDTO CriarConta(string titular, int numeroConta, decimal saldoInicial);
        string Depositar(int numeroConta, decimal valor);
        string Sacar(int numeroConta, decimal valor);
        string ConsultarSaldo(int numeroConta);
    }
}