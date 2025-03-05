using RH.API.Domain;
using RH.API.Services.Interface;
using System.Text.RegularExpressions;

namespace RH.API.Services.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly List<Funcionario> _funcionarios = new List<Funcionario>();

        public (bool Sucesso, string Mensagem) AdicionarFuncionario(Funcionario funcionario)
        {
            try
            {
                // Valida se o nome não está vazio e contém apenas letras e espaços
                if (string.IsNullOrWhiteSpace(funcionario.Nome))
                    return (false, "O nome do funcionário não pode estar vazio.");
                if (!Regex.IsMatch(funcionario.Nome, @"^[A-Za-zÀ-ÿ\s]+$"))
                    return (false, "O nome do funcionário deve conter apenas letras.");

                // Valida se o cargo não está vazio e contém apenas letras e espaços
                if (string.IsNullOrWhiteSpace(funcionario.Cargo))
                    return (false, "O cargo do funcionário não pode estar vazio.");
                if (!Regex.IsMatch(funcionario.Cargo, @"^[A-Za-zÀ-ÿ\s]+$"))
                    return (false, "O cargo do funcionário deve conter apenas letras.");

                // Valida se o salário é um número válido e positivo
                if (funcionario.Salario <= 0)
                    return (false, "O salário deve ser um valor positivo.");

                // Adiciona o funcionário à lista
                _funcionarios.Add(funcionario);
                return (true, "Funcionário adicionado com sucesso.");
            }
            catch (Exception)
            {
                return (false, "Ocorreu um erro ao adicionar o funcionário.");
            }
        }

        public List<Funcionario> ListarFuncionarios()
        {
            try
            {
                // Retorna todos os funcionários
                return _funcionarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao listar os funcionários.", ex);
            }
        }

        public double CalcularMediaSalarial()
        {
            try
            {
                return _funcionarios.Any() ? _funcionarios.Average(f => f.Salario) : 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao calcular a média salarial.", ex);
            }
        }
    }
}
