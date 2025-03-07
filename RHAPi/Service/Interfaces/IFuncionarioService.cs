using RHAPi.Domain;

namespace RHAPI.Service.Interfaces;

public interface IFuncionarioService
{

  // public List<Funcionario> FuncionariosList { get; set; }
  Funcionario AdicionaFuncionario(Funcionario funcionario);
  List<Funcionario> ListarFuncionarios();
  decimal CalcularMediaSalaria();
}