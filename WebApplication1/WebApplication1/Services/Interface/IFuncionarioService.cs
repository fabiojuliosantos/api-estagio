using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IFuncionarioService
{
    bool AdicionarFuncionario (Funcionario funcionario);
    List<Funcionario> ListarFuncionarios ();
    double CalcularMediaSalario();
}
