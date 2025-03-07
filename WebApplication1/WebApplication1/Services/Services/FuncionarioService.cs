using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class FuncionarioService : IFuncionarioService
{
    private readonly List<Funcionario> funcionarios = new List<Funcionario>();
    public bool AdicionarFuncionario(Funcionario funcionario)
    {
            funcionarios.Add(funcionario);
            return true;
    }

    public double CalcularMediaSalario()
    {
        if (funcionarios == null || funcionarios.Count == 0)
        {
            return 0;
        }
        else
        {
            var mediaSalarial = Math.Round(funcionarios.Average(funcionario => funcionario.Salario), 2);
            return mediaSalarial;
        }
    }


    public List<Funcionario> ListarFuncionarios()
    {
        return funcionarios;
    }
}
