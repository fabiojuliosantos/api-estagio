namespace RHAPI.Domain;

public class Bcom
{
    private static int _contador = 1;

    public string? Titular { get; set; }
    public string? NumeroConta { get; set; }
    public decimal Saldo { get; set; }

    public Bcom(string? titular, decimal saldo)
    {
        NumeroConta = GerarNumeroConta();
        Titular = titular;
        Saldo = saldo;
    }

    private string GerarNumeroConta()
    {
        return $"BCOM-{_contador++.ToString("D4")}";
    }
}