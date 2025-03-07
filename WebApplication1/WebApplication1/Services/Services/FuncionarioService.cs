using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class FuncionarioService : IFuncionarioService
{
    private readonly List<Funcionario> funcionarios = new List<Funcionario>();
    private static int _id = 1;
    public bool AdicionarFuncionario(Funcionario funcionario)
    {
        funcionario.Id = _id;
        funcionarios.Add(funcionario);
        _id++;
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
