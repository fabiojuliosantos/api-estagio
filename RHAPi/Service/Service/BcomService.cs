using RHAPI.Domain;
using RHAPI.Infra.Dto;
using RHAPI.Service.Interfaces;
using RHAPI.Utils;

namespace RHAPI.Service.Service;

public class BcomService : IBcomService
{
    private List<Bcom> ListaContasBancarias { get; set; } = [];
    public Bcom CriarConta(CreateBcomDto contaBancaria)
    {
        try
        {
            var contaCriada = new Bcom(contaBancaria.Titular, contaBancaria.Saldo);
            ListaContasBancarias.Add(contaCriada);
            return contaCriada;
        }
        catch (Exception) { throw; }
    }

    public string Depositar(decimal valorDeposito, string numeroConta)
    {
        try
        {
            if (valorDeposito <= 0) throw new CustomerException("O valor do depósito deve ser positivo");
    
            var contaAReceberDeposito = BuscaContaBancaria(numeroConta);
            
            contaAReceberDeposito.Saldo += valorDeposito;
    
            return GeraInformacoesConta(contaAReceberDeposito);
        }
        catch (Exception) { throw; }
    }

    public string ExibirSaldo(string numeroConta)
    {
        try
        {
            var contaAExibirSaldo = BuscaContaBancaria(numeroConta);
    
            return GeraInformacoesConta(contaAExibirSaldo);
        }
        catch (Exception) { throw; }
    }

    public string Sacar(decimal ValorSaque, string numeroConta)
    {
        if (ValorSaque <= 0) throw new CustomerException("O valor do saque deve ser positivo.");
        
        var conta = BuscaContaBancaria(numeroConta);

        if (conta.Saldo <= 0)  throw new CustomerException("Saldo insuficiente para o saque.");

        if (conta.Saldo < ValorSaque) throw new CustomerException("Saldo insuficiente para o saque.");

        conta.Saldo -= ValorSaque;

        return GeraInformacoesConta(conta);
    }

    private Bcom BuscaContaBancaria(string numeroConta)
    {
        try
        {
            var contaAReceberDeposito = ListaContasBancarias.Find(bcom => bcom.NumeroConta == numeroConta);
            
            if (contaAReceberDeposito is null) throw new CustomerException("A conta não foi encontrada no nosso sistema");
    
            return contaAReceberDeposito;
        }
        catch (Exception) { throw; }
    }

    private static string GeraInformacoesConta(Bcom contaBancaria)
    {
        return $"Operação realizada com sucesso! Titular: {contaBancaria.Titular} - Salto: {contaBancaria.Saldo} - Conta: {contaBancaria.NumeroConta}";
    }
}