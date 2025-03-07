using System.Globalization;

namespace RH.API.Domain;

public static class ValidarNumerosPositivos
{
    private static readonly CultureInfo CultureInfo = CultureInfo.InvariantCulture;

    public static double ValidarValorPositivo(double valor, string msgErro)
    {
        if (!double.TryParse(valor.ToString(CultureInfo), out double valorConvertido) 
            || valorConvertido <=0)
        {
            throw new Exception(msgErro);
        }
        return valorConvertido;
    }
}
