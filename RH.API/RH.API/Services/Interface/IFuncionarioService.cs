using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IFuncionarioService
{
    IEnumerable<Funcionario> ListarFuncionarios();
    Funcionario BuscarFuncionariosPorId(int id);
    Funcionario AdicionarFuncionario(Funcionario funcionario);
    bool AtualizarFuncionario(Funcionario funcionario);
    bool RemoverFuncionario(int id);
    double CalcularMediaSalarial();
}
