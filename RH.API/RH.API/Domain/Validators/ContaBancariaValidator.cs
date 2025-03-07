using FluentValidation;
using RH.API.Domain.Entities;

namespace RH.API.Domain.Validators
{
    public class ContaBancariaValidator : AbstractValidator<ContaBancaria>
    {
        public ContaBancariaValidator()
        {
            RuleFor(x => x.Titular)
               .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório.")
               .MaximumLength(50).WithMessage("O campo '{PropertyName}' deve ter até {MaxLength} caracteres.");

            RuleFor(x => x.NumeroConta)
               .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório.")
               .MaximumLength(50).WithMessage("O campo '{PropertyName}' deve ter até {MaxLength} caracteres.");

            RuleFor(x => x.Saldo)
                .NotNull().GreaterThan(0).WithMessage("O campo '{PropertyName}' deve ser um número positivo");
        }
    }
}
