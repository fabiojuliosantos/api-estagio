namespace rh.api.Domain
{
    public class Banco
    {
        public string Titular { get; set; }
        public int NumeroConta { get; set; }
        public decimal Saldo { get; set; }

        public Banco(string titular, int numeroConta, decimal saldo)
        {
            Titular = titular;
            NumeroConta = numeroConta;
            Saldo = saldo;
        }

        public void Depositar(decimal valor)
        {
            try
            {
                if (valor <= 0)
                    throw new ArgumentException("O valor do depósito deve ser maior que zero.");
                Saldo += valor;

            }
            catch (Exception) { throw; }

        }

        public void Sacar(decimal valor)
        {
            try
            {
                if (valor <= 0)
                    throw new ArgumentException("O valor do saque deve ser maior que zero.");

                if (Saldo < valor)
                    throw new InvalidOperationException("Saldo insuficiente para realizar o saque.");

                Saldo -= valor;
            }
            catch (Exception) { throw; }

        }
    }
}



