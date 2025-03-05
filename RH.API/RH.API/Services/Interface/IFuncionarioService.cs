using System.Collections.Frozen;
using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IFuncionarioService
{
    private static List<Funcionario> _funcionarios = new();
    private static int _nextId = 1;

    IEnumerable<Funcionario> ListarFuncionarios();
    Funcionario BuscarFuncionariosPorId(int id);
    Funcionario AdicionarFuncionario(Funcionario funcionario);
    bool AtualizarFuncionario(Funcionario funcionario);
    bool RemoverFuncionario(int id);
    double CalcularMediaSalarial();
}
