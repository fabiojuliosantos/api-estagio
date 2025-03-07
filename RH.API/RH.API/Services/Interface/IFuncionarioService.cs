using FluentValidation;
using RH.API.Domain.Entities;

namespace RH.API.Services.Interface
{
    public interface IFuncionarioService
    {
        Task<TOutputModel> AtualizarAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<Funcionario>;
        Task<bool> Excluir(int id);
        Task<TOutputModel> InserirAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<Funcionario>;
        Task<Funcionario> ListarAsync(int id);
        Task<List<Funcionario>> ListarAsync();
    }
}
