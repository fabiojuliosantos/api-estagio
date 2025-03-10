using FluentValidation;
using RH.API.Domain.Entities.TestePOO;

namespace RH.API.Services.Interface.TestePOO;

public interface ILivroService
{
    Task<TOutputModel> CadastrarAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
        where TInputModel : class
        where TOutputModel : class
        where TValidator : AbstractValidator<Livro>;
    Task<bool> Emprestar(int codigoBarras);
    Task<bool> Devolver(int codigoBarras);
    Task<List<Livro>> ListarAsync();
}
