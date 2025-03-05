using System.Globalization;
using RH.API.Domain;
using RH.API.Services.Interface.TestePOO;

namespace RH.API.Services.Services.TestePOO;

public class FuncionarioService : IFuncionarioService
{
    private readonly List<Funcionario> _funcionarios = new List<Funcionario>(); // Inicializando a lista

    public Task<List<Funcionario>> BuscarTodosFuncionarios()
    {
        try
        {
            if (_funcionarios != null)
            {
                List<Funcionario> funcionarios = _funcionarios;
                return Task.FromResult(funcionarios);
            }
            else
                throw new Exception("Não há registros de funcionários!");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<double> CalcularMediaSalarial()
    {
        if (_funcionarios == null || _funcionarios.Count == 0)
            return Task.FromResult(0.0);

        double somaSalarios = 0;
        
        foreach (var funcionario in _funcionarios)
        {
            double.TryParse(funcionario.Salario, CultureInfo.InvariantCulture, out double salario);

            somaSalarios += salario;
        }

        double media = somaSalarios / _funcionarios.Count;
        return Task.FromResult(media);
    }

    public Task<bool> InserirFuncionario(Funcionario funcionario)
    {
        try
        {
            if (!double.TryParse(funcionario.Salario, CultureInfo.InvariantCulture,out double salario) || salario < 0)
                throw new Exception("Salário inserido inválido!");

            if (salario > 1518)
            {
                _funcionarios.Add(funcionario);
                return Task.FromResult(true);
            }
            else
            {
                throw new Exception("O salário do funcionário não pode ser menor que o salário mínimo de R$1.518,00");
            }
        }
        catch (Exception ex) { throw; }
    }
}
