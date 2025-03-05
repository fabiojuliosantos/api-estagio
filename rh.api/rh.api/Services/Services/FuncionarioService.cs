using rh.api.Domain;
using rh.api.Services.Interface;

namespace rh.api.Services.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        //Lista para armazenar os funcionários
        private static readonly List<Funcionario> _funcionarios = new List<Funcionario>();

        //Variável para controlar id
        private static int _nextId = 1;

        public void AdicionarFuncionario(Funcionario funcionario)
        {
            //Atribui o próximo ID ao funcionário
            funcionario.Id = _nextId++;
            //Adiciona o funcionário à lista
            _funcionarios.Add(funcionario);
        }

        //usada para representar uma coleção de objetos que pode ser enumerada,
        //ou seja, que pode ser percorrida item por item
        public IEnumerable<Funcionario> ListarFuncionarios()
        {
            return _funcionarios;
        }

        public decimal CalcularMediaSalarial()
        {
            try {   if (!_funcionarios.Any())
                return 0;

            return _funcionarios.Average(f => f.Salario);
            }
            catch (Exception)
            {
                throw;
            }
          
        }
    }
}