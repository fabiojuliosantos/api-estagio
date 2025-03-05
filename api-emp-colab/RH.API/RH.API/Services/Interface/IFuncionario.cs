using RH.API.Domain;
using System.Collections.Generic;

namespace RH.API.Services.Interface
{
    public interface IFuncionario
    {
        (bool Sucesso, string Mensagem) AdicionarFuncionario(Funcionario funcionario);
        List<Funcionario> ListarFuncionarios();
        double CalcularMediaSalarial();
    }
}
