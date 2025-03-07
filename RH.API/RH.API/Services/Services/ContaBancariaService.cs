using RH.API.Domain;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class ContaBancariaService : IContaBancariaService
{
    private static List<ContaBancaria> _contas = new();
    private static int _proximoId = 1;

    public IEnumerable<ContaBancariaDTO> ListarContas()
    {
        return _contas.Select(c => new ContaBancariaDTO
        {
            Titular = c.Titular,
            NumeroConta = c.NumeroConta,
            Saldo = Math.Round(c.Saldo, 2)
        });
    }

    public ContaBancariaDTO BuscarContaPorNumero(string numeroConta)
    {
        var conta = _contas.FirstOrDefault(c => c.NumeroConta == numeroConta);
        if (conta == null)
        {
            return null;
        }
        return new ContaBancariaDTO
        {
            Titular = conta.Titular,
            NumeroConta = conta.NumeroConta,
            Saldo = Math.Round(conta.Saldo, 2)
        };
    }

    public ContaBancariaDTO AdicionarConta(ContaBancariaDTO contaDTO)
    {
        if (string.IsNullOrEmpty(contaDTO.Titular) || string.IsNullOrEmpty(contaDTO.NumeroConta))
        {
            throw new Exception("Titular e número da conta são obrigatórios.");
        }

        if (_contas.Any(c => c.NumeroConta == contaDTO.NumeroConta))
        {
            throw new Exception("Número da conta já existe.");
        }

        double saldoConvertido = ValidarNumerosPositivos.ValidarValorPositivo(contaDTO.Saldo, "O saldo inicial deve ser válido e positivo.");

        var novaConta = new ContaBancaria
        {
            Id = _proximoId++,
            Titular = contaDTO.Titular,
            NumeroConta = contaDTO.NumeroConta,
            Saldo = Math.Round(saldoConvertido, 2)
        };

        _contas.Add(novaConta);

        return new ContaBancariaDTO
        {
            Titular = novaConta.Titular,
            NumeroConta = novaConta.NumeroConta,
            Saldo = Math.Round(novaConta.Saldo, 2)
        };
    }

    public bool AtualizarConta(ContaBancariaDTO contaDTO)
    {
        var contaExistente = _contas.FirstOrDefault(c => c.NumeroConta == contaDTO.NumeroConta);
        if (contaExistente == null)
        {
            return false;
        }

        contaExistente.Titular = contaDTO.Titular ?? contaExistente.Titular;
        contaExistente.Saldo = Math.Round(contaDTO.Saldo, 2);

        return true;
    }

    public bool RemoverConta(string numeroConta)
    {
        var conta = _contas.FirstOrDefault(c => c.NumeroConta == numeroConta);
        if (conta == null)
        {
            return false;
        }
        return _contas.Remove(conta);
    }

    public void Depositar(string numeroConta, double valor)
    {
        var conta = _contas.FirstOrDefault(c => c.NumeroConta == numeroConta);
        if (conta == null)
        {
            throw new Exception("Conta não encontrada.");
        }

        double valorConvertido = ValidarNumerosPositivos.ValidarValorPositivo(valor, "O valor do depósito deve ser válido e positivo.");
        conta.Depositar(valorConvertido);
        conta.Saldo = Math.Round(conta.Saldo, 2);
    }

    public bool Sacar(string numeroConta, double valor)
    {
        var conta = _contas.FirstOrDefault(c => c.NumeroConta == numeroConta);
        if (conta == null)
        {
            throw new Exception("Conta não encontrada.");
        }

        double valorConvertido = ValidarNumerosPositivos.ValidarValorPositivo(valor, "O valor do saque deve ser válido e positivo.");
        bool sucesso = conta.Sacar(valorConvertido);
        if (sucesso)
        {
            conta.Saldo = Math.Round(conta.Saldo, 2);
        }
        return sucesso;
    }

    public double ConsultarSaldo(string numeroConta)
    {
        var conta = _contas.FirstOrDefault(c => c.NumeroConta == numeroConta);
        if (conta == null)
        {
            throw new Exception("Conta não encontrada.");
        }
        return Math.Round(conta.Saldo, 2);
    }
}