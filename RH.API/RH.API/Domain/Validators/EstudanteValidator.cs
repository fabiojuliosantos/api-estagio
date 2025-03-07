using FluentValidation;
using RH.API.Domain.Entities;

namespace RH.API.Domain.Validators
{
    public class EstudanteValidator : AbstractValidator<Estudante>
    {
        public EstudanteValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório.")
                .MaximumLength(50).WithMessage("O campo '{PropertyName}' deve ter até {MaxLength} caracteres.");

            RuleFor(x => x.Curso)
                .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório.")
                .MaximumLength(50).WithMessage("O campo '{PropertyName}' deve ter até {MaxLength} caracteres.");

            RuleFor(x => x.Idade)
                .NotNull().GreaterThan(0).WithMessage("O campo '{PropertyName}' deve ser um número positivo");
        }
    }
}
