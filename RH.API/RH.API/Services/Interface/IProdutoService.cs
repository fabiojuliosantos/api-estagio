using FluentValidation;
using RH.API.Domain.Entities;

namespace RH.API.Services.Interface
{
    public interface IProdutoService
    {
        Task<TOutputModel> AtualizarAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<Produto>;
        Task<bool> Excluir(int id);
        Task<TOutputModel> InserirAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<Produto>;
        Task<Produto> ListarAsync(int id);
        Task<List<Produto>> ListarAsync();
    }
}
