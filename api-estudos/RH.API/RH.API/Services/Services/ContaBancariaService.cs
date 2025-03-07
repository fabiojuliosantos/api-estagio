using RH.API.Domain;
using RH.API.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RH.API.Services
{
    public class ContaBancariaService : IContaBancariaService
    {
        private readonly List<ContaBancaria> _contas = new List<ContaBancaria>();

        public (bool Sucesso, string Mensagem) AdicionarContaBancaria(ContaBancaria contaBancaria)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(contaBancaria.Titular))
                {
                    return (false, "O titular precisa ter nome.");
                }

                if (!Regex.IsMatch(contaBancaria.Titular, @"^[A-Za-zÀ-ÿ\s]+$"))
                {
                    return (false, "O nome do titular deve conter apenas letras.");
                }

                if (contaBancaria.Saldo < 0)
                {
                    return (false, "O saldo não pode ser negativo.");
                }

                if (_contas.Any(c => c.NumeroDaConta == contaBancaria.NumeroDaConta))
                {
                    return (false, "Conta já existe.");
                }

                _contas.Add(contaBancaria);
                return (true, "Conta bancária adicionada com sucesso.");
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao adicionar conta: {ex.Message}");
            }
        }

        public (bool Sucesso, string Mensagem, decimal NovoSaldo) Depositar(int numeroDaConta, decimal valor)
        {
            try
            {
                var conta = _contas.FirstOrDefault(c => c.NumeroDaConta == numeroDaConta);
                if (conta == null)
                {
                    return (false, "Conta não encontrada.", 0);
                }

                conta.Saldo += valor;
                return (true, "Depósito realizado com sucesso.", conta.Saldo);
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao depositar: {ex.Message}", 0);
            }
        }

        public (bool Sucesso, string Mensagem, decimal NovoSaldo) Sacar(int numeroDaConta, decimal valor)
        {
            try
            {
                var conta = _contas.FirstOrDefault(c => c.NumeroDaConta == numeroDaConta);
                if (conta == null)
                {
                    return (false, "Conta não encontrada.", 0);
                }

                if (conta.Saldo < valor)
                {
                    return (false, "Saldo insuficiente.", conta.Saldo);
                }

                conta.Saldo -= valor;
                return (true, "Saque realizado com sucesso.", conta.Saldo);
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao sacar: {ex.Message}", 0);
            }
        }

        public decimal? ObterSaldo(int numeroDaConta)
        {
            try
            {
                var conta = _contas.FirstOrDefault(c => c.NumeroDaConta == numeroDaConta);
                return conta?.Saldo;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
