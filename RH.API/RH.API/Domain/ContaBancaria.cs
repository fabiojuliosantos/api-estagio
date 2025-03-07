namespace RH.API.Domain;

public class ContaBancaria
{
    public string Titular { get; set; }
    public string NumeroConta { get; set; }
    public double Saldo { get; set; }
    public int Id { get; internal set; }

    public void Depositar (double valor)
    {
        Saldo = ContaBancariaSacarDepositar.Depositar(Saldo, valor);
    }
    public bool Sacar (double valor)
    {
        double novoSaldo;
        bool sucesso = ContaBancariaSacarDepositar.Sacar(Saldo, valor, out novoSaldo);
        if (sucesso) Saldo = novoSaldo;
        return sucesso;
    }
}
