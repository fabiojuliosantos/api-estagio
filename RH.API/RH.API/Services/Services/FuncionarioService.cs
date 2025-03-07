using System.Xml;
using Microsoft.AspNetCore.Http.HttpResults;
using RH.API.Data.Dtos;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;



public class FuncionarioService : IFuncionarioService
{
    private List<Funcionario> _funcionario = new List<Funcionario>();

    public  List<Funcionario> BuscarTodosFuncionarios()
    {
        try
        {

            if (!_funcionario.Any())
            {
                throw new Exception("Nenhum funcionario foi encontrado");

            }


            foreach (var funcionario in _funcionario)
            {
                Console.WriteLine($"Nome:{funcionario.Nome}, Cargo: {funcionario.Cargo}, Salário: {funcionario.Salario:C}");

            }
            return _funcionario;
        }
        catch (Exception ex)
        {
            { throw new Exception("Ocorreu um erro ao processar a lista de estudantes. Detalhes: " + ex.Message); }
        }
    }

    public RespostaDTO CalcularMediaSalarial()
    {
        try
        {
            if (!_funcionario.Any())
                return new RespostaDTO(false, "Nenhum funcionário cadastrado para calcular a média salarial.");


            double somaSalario = _funcionario.Sum(f => f.Salario);

            double mediaSalario = somaSalario / _funcionario.Count();

            return new RespostaDTO (true,$"Média salarial dos funcionários: {mediaSalario:C}");
        }
        catch (Exception)
        {

            return new RespostaDTO(false, "Erro ao calcular média salarial");
        }
    }

    public RespostaDTO InserirFuncionario(Funcionario funcionario)
    {
        try
        {
            if(funcionario == null)
            {
                return new RespostaDTO(false, "Funcionario não pode ser Nulo");
            }
            
            if (String.IsNullOrEmpty(funcionario.Nome))
            {
                return new RespostaDTO(false, "Nome não pode ser Nulo");
            }
            if (String.IsNullOrEmpty(funcionario.Cargo))
            {
                return new RespostaDTO(false, "Cargo não pode ser Nulo");
            }
            if(funcionario.Salario <= 0)
            {
                return new RespostaDTO(false, "Salário deve ser positivo");
            }
                _funcionario.Add(funcionario);
            return new RespostaDTO(true, "Funcionario cadastrado com sucesso");

           


        }
        catch (Exception)
        {

            return new RespostaDTO(false, "Erro ao cadastrar Funcionario");
        }
    }
}
