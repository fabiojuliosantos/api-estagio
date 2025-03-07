//using rh.api.Domain;
//using rh.api.Services.Interface;

//namespace rh.api.Services.Services
//{
//    public class BancoService : IBancoService
//    {
//        private readonly List<Banco> _contas = new List<Banco>();

//        public Banco CriarConta(string titular, int numeroConta, decimal saldoInicial)
//        {
//            try
//            {// Validação do titular
//                if (string.IsNullOrEmpty(titular))
//                    throw new ArgumentException("O titular da conta não pode ser nulo ou vazio.");

//                // Validação do número da conta
//                if (numeroConta <= 0)
//                    throw new ArgumentException("O número da conta deve ser positivo e maior que zero.");

//                // Validação do saldo inicial
//                if (saldoInicial < 0)
//                    throw new ArgumentException("O saldo inicial não pode ser negativo.");

//                // Verifica se a conta já existe
//                var contaExistente = _contas.Find(c => c.NumeroConta == numeroConta);
//                if (contaExistente != null)
//                    throw new InvalidOperationException("Já existe uma conta com esse número.");

//                // Cria a nova conta
//                var conta = new Banco(titular, numeroConta, saldoInicial);
//                _contas.Add(conta);
//                return conta;

//            }
//            catch (Exception)
//            { throw; }

//        }

//        public string Depositar(int numeroConta, decimal valor)
//        {
//            try
//            {
//                var conta = ObterConta(numeroConta);
//                conta.Depositar(valor);
//                return $"Depósito de {valor:C2} realizado com sucesso na conta {numeroConta}. Novo saldo: {conta.Saldo:C2}.";
//            }
//            catch (Exception) { throw; }

//        }

//        public string Sacar(int numeroConta, decimal valor)
//        {
//            try
//            {
//                var conta = ObterConta(numeroConta);
//                conta.Sacar(valor);
//                return $"Saque de {valor:C2} realizado com sucesso na conta {numeroConta}. Novo saldo: {conta.Saldo:C2}.";

//            }
//            catch (Exception) { throw; }

//        }

//        public string ConsultarSaldo(int numeroConta)
//        {
//            try
//            {
//                var conta = ObterConta(numeroConta);
//                return $"O saldo da conta {numeroConta} é {conta.Saldo:C2}.";

//            }
//            catch (Exception) { throw; }

//        }

//        private Banco ObterConta(int numeroConta)
//        {
//            try
//            {
//                var conta = _contas.Find(c => c.NumeroConta == numeroConta);
//                if (conta == null)
//                    throw new KeyNotFoundException("Conta não encontrada.");

//                return conta;

//            }
//            catch (Exception) { throw; }

//        }
//    }
//}

using rh.api.Domain;
using rh.api.DTO;
using rh.api.Services.Interface;

namespace rh.api.Services.Services
{
    public class BancoService : IBancoService
    {
        private readonly List<Banco> _contas = new List<Banco>();

        public BancoDTO CriarConta(string titular, int numeroConta, decimal saldoInicial)
        {
            try
            {
                // Validação do titular
                if (string.IsNullOrEmpty(titular))
                    throw new ArgumentException("O titular da conta não pode ser nulo ou vazio.");

                // Validação do número da conta
                if (numeroConta <= 0)
                    throw new ArgumentException("O número da conta deve ser positivo e maior que zero.");

                // Validação do saldo inicial
                if (saldoInicial < 0)
                    throw new ArgumentException("O saldo inicial não pode ser negativo.");

                // Verifica se a conta já existe
                var contaExistente = _contas.Find(c => c.NumeroConta == numeroConta);
                if (contaExistente != null)
                    throw new InvalidOperationException("Já existe uma conta com esse número.");

                // Cria a nova conta
                var conta = new Banco(titular, numeroConta, saldoInicial);
                _contas.Add(conta);

                // Converte a entidade para DTO
                return new BancoDTO
                {
                    Titular = conta.Titular,
                    NumeroConta = conta.NumeroConta,
                    Saldo = conta.Saldo
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Depositar(int numeroConta, decimal valor)
        {
            try
            {
                var conta = ObterConta(numeroConta);
                conta.Depositar(valor);
                return $"Depósito de {valor:C2} realizado com sucesso na conta {numeroConta}. Novo saldo: {conta.Saldo:C2}.";
            }
            catch (Exception) { throw; }
        }

        public string Sacar(int numeroConta, decimal valor)
        {
            try
            {
                var conta = ObterConta(numeroConta);
                conta.Sacar(valor);
                return $"Saque de {valor:C2} realizado com sucesso na conta {numeroConta}. Novo saldo: {conta.Saldo:C2}.";
            }
            catch (Exception) { throw; }
        }

        public string ConsultarSaldo(int numeroConta)
        {
            try
            {
                var conta = ObterConta(numeroConta);
                return $"O saldo da conta {numeroConta} é {conta.Saldo:C2}.";
            }
            catch (Exception) { throw; }
        }

        private Banco ObterConta(int numeroConta)
        {
            try
            {
                var conta = _contas.Find(c => c.NumeroConta == numeroConta);
                if (conta == null)
                    throw new KeyNotFoundException("Conta não encontrada.");

                return conta;
            }
            catch (Exception) { throw; }
        }
    }
}

