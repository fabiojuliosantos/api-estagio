using System.ComponentModel;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class BcomService : IBcomService
{
    List<Bcom> bcomList = new List<Bcom>();
    public int CriarConta(Bcom conta)
    {
        try
        {
            if (conta == null)
            {
                return 2;
            }
            else if (bcomList.Find(b => conta.NumeroDaConta == b.NumeroDaConta) != null)
            {
                return 3;
            }
            else
            {
                bcomList.Add(conta);
                return 1;
            }
        }
        catch (Exception e) { throw; }
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
