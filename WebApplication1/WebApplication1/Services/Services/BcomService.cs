using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class BcomService : IBcomService
{
    List<Bcom> bcomList = new List<Bcom>();
    public Bcom CriarConta(Bcom conta)
    {
        try
        {
            if (conta == null)
            {
                throw new Exception("Erro !!! Conta inválida!");
            }
            else if (bcomList.Find(b => conta.NumeroDaConta == b.NumeroDaConta) != null)
            {
                throw new Exception($"A conta com o número {conta.NumeroDaConta} já existe!");
            }
            else
            {
                bcomList.Add(conta);
                return conta;
            }
        }
        catch (Exception e) { throw e; }
    }

    public bool Depositar(int numeroDaConta, double valor)
    {
        try
        {
            var banco = bcomList.Find(b => b.NumeroDaConta == numeroDaConta);
            if (banco != null)
            {
                banco.Saldo += valor;
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e) { throw; }
    }
    public int Sacar(int numeroDaConta, double valor)
    {
        try
        {
            var banco = bcomList.Find(b => b.NumeroDaConta == numeroDaConta);
            if (banco != null)
            {
                if(banco.Saldo < valor)
                {
                    return 2;
                }
                else
                {
                    banco.Saldo -= valor;
                    return 1;
                }
            }
            else { return 3; }
        }
        catch (Exception e) { throw; }
    }

    public Bcom ExibirSaldo(int numeroDaConta)
    {
        try
        {
            var banco = bcomList.Find(b => b.NumeroDaConta == numeroDaConta);
            if (banco != null)
            {
                return banco;
            }
            else
            {
                return null;
            }
        }
        catch (Exception e) { throw; }
    }
}
