using RHAPi.Domain;
using RHAPI.Service.Interfaces;
using RHAPI.Utils;

namespace RHAPI.Service.Service;

public class FuncionarioService : IFuncionarioService
{
    public List<Funcionario> FuncionariosList { get; set; } = [];
    public Funcionario AdicionaFuncionario(Funcionario funcionario)
    {
        if (funcionario.Nome is null) throw new CustomerException("O nome do funcionário não pode ser nulo");

        if (funcionario.Salario <= 0) throw new CustomerException("O salário do funcionário precisa ser maior que zero");

        FuncionariosList.Add(funcionario);
        
        return FuncionariosList.Last();
    }

    public decimal CalcularMediaSalaria()
    {
        if (FuncionariosList.Count == 0)
        {
            return 0;
        }

        return FuncionariosList.Average(f => f.Salario);
    }

    public List<Funcionario> ListarFuncionarios()
    {
        return [.. FuncionariosList];
    }
}