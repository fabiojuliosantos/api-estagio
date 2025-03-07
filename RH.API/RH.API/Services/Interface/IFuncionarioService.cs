using RH.API.Data.Dtos;
using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface IFuncionarioService
{
     List<Funcionario> BuscarTodosFuncionarios();

    RespostaDTO InserirFuncionario(Funcionario funcionario);
    RespostaDTO CalcularMediaSalarial();


}
