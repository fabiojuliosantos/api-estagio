using FluentValidation;
using RH.API.Domain.Entities;

namespace RH.API.Services.Interface
{
    public interface IEstudanteService
    {
        Task<TOutputModel> AtualizarAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<Estudante>;
        Task<bool> Excluir(int matricula);
        Task<TOutputModel> InserirAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<Estudante>;
        Task<Estudante> ListarAsync(int matricula);
        Task<List<Estudante>> ListarAsync();
    }
}
