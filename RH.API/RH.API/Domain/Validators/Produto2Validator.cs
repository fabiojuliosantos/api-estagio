using FluentValidation;
using RH.API.Domain.Entities.TestePOO;

namespace RH.API.Domain.Validators;

public class Produto2Validator : AbstractValidator<Produto2>
{
    public Produto2Validator()
    {
        RuleFor(x => x.Nome)
            .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório.")
            .MaximumLength(50).WithMessage("O campo '{PropertyName}' deve ter até {MaxLength} caracteres.");

        RuleFor(x => x.Preco)
            .NotNull().GreaterThan(0).WithMessage("O campo '{PropertyName}' deve ser um número positivo");

        RuleFor(x => x.QtdEstoque)
            .NotNull().GreaterThan(0).WithMessage("O campo '{PropertyName}' deve ser um número positivo");
    }
}
