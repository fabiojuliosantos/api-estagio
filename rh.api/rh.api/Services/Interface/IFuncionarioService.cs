using rh.api.Domain;

namespace rh.api.Services.Interface
{
    public interface IFuncionarioService
    {
        void AdicionarFuncionario(Funcionario funcionario);
        IEnumerable<Funcionario> ListarFuncionarios();
        decimal CalcularMediaSalarial();
    }
}