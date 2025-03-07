using System.Drawing;
using RH.API.Data.Dtos;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class BcomService : IbcomService
{
    private List<Bcom> _Bcom = new();

    public RespostaDTO CriarConta(Bcom bcom)
    {
        try
        {
            if (String.IsNullOrEmpty(bcom.Titular))
            {
                return new RespostaDTO(false, "Titular não pode ser nulo");
            }
            if(bcom.NumeroConta == null)
            {
                return new RespostaDTO(false, "Numero da conta não pode ser nulo! ");
            }
            if(bcom.NumeroConta <=0)
            {
                return new RespostaDTO(false, "Número da conta não pode ser menor que zero! ");
            }
            if(bcom.Saldo < 0)
            {
                return new RespostaDTO(false, "O saldo inicial não pode ser menor que zero! ");
            }
            if(_Bcom.Any(conta => conta.NumeroConta == bcom.NumeroConta))
            {
                return new RespostaDTO(false, "O numero da conta já existe!");
            }
            _Bcom.Add(bcom);
            return new RespostaDTO(true, "Conta criada com sucesso");
        }
        catch (Exception)
        {

            throw;
        }
    }

    public RespostaDTO Depositar(int numeroConta, double valor)
    {
        try
        {
          
            if(valor <= 0)
            {
                return new RespostaDTO(false, "valor do depositso não pode ser menor que zero");
            }

            var conta = _Bcom.FirstOrDefault(contas => contas.NumeroConta == numeroConta);

            if(conta == null)
            {
                return new RespostaDTO(false, "Conta não encontrada");
            }
            conta.Saldo += valor;
            return new RespostaDTO(true, "Saldo depositado com sucesso");

            

        }
        catch (Exception)
        {

            throw;
        }
    }

    public RespostaDTO ExibirSaldo(int numeroConta)
    {
        try
        {
            var conta = _Bcom.FirstOrDefault(contas => contas.NumeroConta == numeroConta);

            if(conta == null)
            {
                return new RespostaDTO(false, "Conta não encontrada");
            }

            return new RespostaDTO(true, $"Conta encontrada! {conta.Saldo:C}");
        }
        catch (Exception)
        {

            throw;
        }
    }

    public RespostaDTO Sacar(int numeroConta, double saque)
    {
        try
        {
            if (saque <= 0)
            {
                return new RespostaDTO(false, "valor do saque não pode ser menor que zero");
            }

            var conta = _Bcom.FirstOrDefault(contas => contas.NumeroConta == numeroConta);

            if (conta == null)
            {
                return new RespostaDTO(false, "Conta não encontrada");
            }

            if(conta.Saldo < saque)
            {
                return new RespostaDTO(false, "Saldo Insuficente para realizar o saque ");
            }
            conta.Saldo -= saque;
            return new RespostaDTO(true, "Saque realizado com sucesso");
            

        }
        catch (Exception)
        {

            throw;
        }
    }
}

   

 
