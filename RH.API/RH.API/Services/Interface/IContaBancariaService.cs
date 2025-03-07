using FluentValidation;
using RH.API.Domain.Entities;

namespace RH.API.Services.Interface
{
    public interface IContaBancariaService
    {
        Task<TOutputModel> InserirAsync<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<ContaBancaria>;

        Task<string> ExibirSaldo(string numeroConta);
        Task<string> Depositar(string numeroConta, double saldo);
        Task<string> Sacar(string numeroConta, double saque);
    }
}
