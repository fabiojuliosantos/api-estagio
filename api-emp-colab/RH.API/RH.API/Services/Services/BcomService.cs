using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services
{
    public class BcomService : IBcom
    {
        private readonly List<Bcom> _bcom = new List<Bcom>(); 
        public (bool Sucesso, string Mensagem) AdicionarConta(Bcom bcom)
        {
            try
            {
                // validações de dados
                if (bcom == null) return (false, "Conta não pode ser nula.");
                if (bcom.NumeroConta <= 0) return (false, "Número da conta deve ser maior que zero.");
                if (string.IsNullOrWhiteSpace(bcom.Titular)) return (false, "Titular da conta não pode ser vazio.");
                if (bcom.Saldo < 0) return (false, "Saldo da conta não pode ser negativo.");
                if (_bcom.Any(b => b.NumeroConta == bcom.NumeroConta)) return (false, "Número da conta já existe.");

                _bcom.Add(bcom);
                return (true, "Conta adicionada com sucesso.");
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao adicionar conta: {ex.Message}");
            }
        }

        public (bool Sucesso, string Mensagem) Depositar(int numeroConta, double valor)
        {
            try
            {
                if (valor <= 0) return (false, "Valor do depósito deve ser maior que zero.");

                var conta = _bcom.FirstOrDefault(b => b.NumeroConta == numeroConta);
                if (conta == null) return (false, "Conta não encontrada.");

                conta.Saldo += valor; 
                return (true, $"Depósito realizado com sucesso. Saldo atual: {conta.Saldo}");
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao depositar: {ex.Message}");
            }
        }
        public double ExibirSaldo(int numeroConta)
        {
            try
            {
                var conta = _bcom.FirstOrDefault(b => b.NumeroConta == numeroConta);
                if (conta == null) throw new ArgumentException("Conta não encontrada.");

                return conta.Saldo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro ao exibir saldo: {ex.Message}");
            }
        }
        public List<Bcom> ListarContasBancarias()
        {
            return _bcom; 
        }
        public (bool Sucesso, string Mensagem) Sacar(int numeroConta, double valor)
        {
            try
            {
                if (valor <= 0) return (false, "Valor do saque deve ser maior que zero.");

                var conta = _bcom.FirstOrDefault(b => b.NumeroConta == numeroConta);
                if (conta == null) return (false, "Conta não encontrada.");
                if (conta.Saldo < valor) return (false, "Saldo insuficiente para o saque.");

                conta.Saldo -= valor;
                return (true, $"Saque realizado com sucesso. Saldo atual: {conta.Saldo}");
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao sacar: {ex.Message}");
            }
        }
    }
}