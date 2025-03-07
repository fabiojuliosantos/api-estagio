namespace RH.API.Domain.Entities.TestePOO;

public class Bcom
{
    public Bcom(string titular, int numeroConta, double saldo)
    {
        Titular = titular;
        NumeroConta = numeroConta;
        Saldo = saldo;
    }

    public string Titular { get; set; }
    public int NumeroConta { get; set; }
    public double Saldo { get; set; }
}
