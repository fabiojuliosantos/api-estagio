using FluentValidation;
using RH.API.Domain.Entities;

namespace RH.API.Domain.Validators
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        public FuncionarioValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório.")
                .MaximumLength(50).WithMessage("O campo '{PropertyName}' deve ter até {MaxLength} caracteres.");

            RuleFor(x => x.Salario)
                .NotNull().GreaterThan(0).WithMessage("O campo '{PropertyName}' deve ser um número positivo");
        }
    }
}
