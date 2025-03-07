using System.Globalization;

namespace RH.API.Domain;

public static class ContaBancariaSacarDepositar
{
    private static readonly CultureInfo CultureInfo = CultureInfo.InvariantCulture;
    public static double Depositar (double saldoAtual, double valor)
    {
        if(!double.TryParse(valor.ToString(CultureInfo), out double valorConvertido) 
            || valorConvertido <= 0)
        {
            throw new Exception("O valor do deposito deve ser valido e positivo");
        }
        return saldoAtual + valorConvertido;
    }

    public static bool Sacar (double saldoAtual, double valor, out double novoSaldo)
    {
        if (!double.TryParse(valor.ToString(CultureInfo), out double valorConvertido) 
            || valorConvertido <=0)
        {
            throw new Exception("O valor do saque deve ser um numero positivo valido");
        }

        if (saldoAtual < valorConvertido)
        {
            novoSaldo = saldoAtual;
            return false;
        }
        novoSaldo = saldoAtual - valorConvertido;
        return true;
    }
}
