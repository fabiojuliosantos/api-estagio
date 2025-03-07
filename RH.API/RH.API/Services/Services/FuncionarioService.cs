using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class FuncionarioService : IFuncionarioService
{
    private static List<Funcionario> _funcionarios = new();
    private static int _proximoId = 1;

    public IEnumerable<Funcionario> ListarFuncionarios()
    {
        return _funcionarios;
    }
    public Funcionario BuscarFuncionariosPorId(int id)
    {
        try
        {
            return _funcionarios.FirstOrDefault(f => f.Id == id);
        }
        catch (Exception) { throw; }
    }
    public Funcionario AdicionarFuncionario(Funcionario funcionario)
    {
        try
        {
            if (string.IsNullOrEmpty(funcionario.Nome) || funcionario.Salario <= 0)
            {
                throw new Exception("Nome e salario sao obrigatorios e salario maior que zero");
            }
            funcionario.Id = _proximoId++;
            _funcionarios.Add(funcionario);
            return funcionario;
        }
        catch (Exception) { throw; }
    }
    public bool AtualizarFuncionario(Funcionario funcionario)
    {
        try
        {
            var funcionarioExistente = _funcionarios.FirstOrDefault(f => f.Id == funcionario.Id);
            if (funcionarioExistente == null)
            {
                return false;
            }

            funcionarioExistente.Nome = funcionario.Nome ?? funcionarioExistente.Nome;
            funcionarioExistente.Cargo = funcionario.Cargo ?? funcionarioExistente.Cargo;
            funcionarioExistente.Salario = funcionario.Salario > 0 ? funcionario.Salario : funcionarioExistente.Salario;

            return true;
        }
        catch (Exception) { throw; }
    }
    public bool RemoverFuncionario(int id)
    {
        try
        {
            var funcionario = _funcionarios.FirstOrDefault(f => f.Id == id);
            if (funcionario == null)
            {
                return false;
            }
            return _funcionarios.Remove(funcionario);
        }
        catch (Exception) { throw; }
    }
    public double CalcularMediaSalarial()
    {
        try
        {
            if (!_funcionarios.Any())
            {
                return 0;
            }
            return _funcionarios.Average(f => f.Salario);
        }
        catch (Exception) { throw; }
    }
}
