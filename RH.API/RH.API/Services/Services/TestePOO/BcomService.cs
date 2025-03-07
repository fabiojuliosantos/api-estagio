using System.Data;
using System.Globalization;
using RH.API.Domain.Entities.TestePOO;
using RH.API.Services.Interface.TestePOO;

namespace RH.API.Services.Services.TestePOO;

public class BcomService : IBcomService
{
    private readonly List<Bcom> _contas = [];

    public Task<bool> Depositar(string numeroContaInserido, string depositoDesejado)
    {
        try
        {
            if (!int.TryParse(numeroContaInserido, CultureInfo.InvariantCulture, out int numeroConta))
                throw new Exception("Número da conta inválido!");

            if (!double.TryParse(depositoDesejado, CultureInfo.InvariantCulture, out double deposito))
                throw new Exception("Valor do deposito inválido");
            
            var conta = _contas.FirstOrDefault(c => c.NumeroConta == numeroConta);

            if (conta == null)
                throw new Exception("A conta não está registrada!");
            else
            {
                conta.Saldo += deposito;
                return Task.FromResult(true);
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

    public Task<double> ExibirSaldo(string numeroContaInserido)
    {
        if (!int.TryParse(numeroContaInserido, CultureInfo.InvariantCulture, out int numeroConta))
            throw new Exception("Número da conta inválido!");

        var conta = _contas.FirstOrDefault(c => c.NumeroConta == numeroConta);

        if (conta == null) return Task.FromResult(-1.0);

        return Task.FromResult(conta.Saldo);
    }

    public Task<bool> Sacar(string numeroContaInserido, string saqueDesejado)
    {
        try
        {
            if (!int.TryParse(numeroContaInserido, out int numeroConta))
                throw new Exception("Informe um número válido!");

            if (!double.TryParse(saqueDesejado, CultureInfo.InvariantCulture, out double saque))
                return Task.FromResult(false);

            var conta = _contas.FirstOrDefault(c => c.NumeroConta == numeroConta);

            if (conta == null)
                throw new Exception("A conta não está registrada!");

            if (conta.Saldo < saque)
                throw new Exception("Saldo insuficiente!");
            else
            {
                conta.Saldo -= saque;
                return Task.FromResult(true);
            }
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }
    public Task<bool> InserirConta(Bcom conta)
    {
        try
        {
            if (_contas.Any(c => c.NumeroConta == conta.NumeroConta))
                throw new Exception("O número da conta já existe!"); // Já retorna false por default
            else
            {
                _contas.Add(conta);
                return Task.FromResult(true);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
