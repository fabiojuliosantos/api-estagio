using RH.API.Domain;
using RH.API.Services.Interface;
using System.Globalization;

namespace RH.API.Services.Services
{
    public class FuncionarioService : IFuncionario
    {
        private readonly List<Funcionario> _funcionarios = new List<Funcionario>();

        public (bool Sucesso, string Mensagem) AdicionarFuncionario(Funcionario funcionario)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(funcionario.Nome))
                    return (false, "O nome do funcionário não pode estar vazio.");

                if (funcionario.Salario <= 0)
                    return (false, "O salário deve ser um valor positivo.");

                if (string.IsNullOrWhiteSpace(funcionario.Cargo))
                    return (false, "O cargo do funcionário não pode estar vazio.");

                funcionario.Salario = double.Parse(funcionario.Salario.ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);

                _funcionarios.Add(funcionario);
                return (true, "Funcionário adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Funcionario> ListarFuncionarios()
        {
            try
            {
                return _funcionarios;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public double CalcularMediaSalarial()
        {
            try
            {
                return _funcionarios.Average(f => f.Salario);
            }
            catch (Exception ex)
            {
                // Tratar exceções de maneira apropriada
                throw new InvalidOperationException("Ocorreu um erro ao calcular a média salarial.", ex);
            }
        }
    }
}
