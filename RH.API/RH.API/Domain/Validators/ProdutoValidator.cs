using FluentValidation;
using RH.API.Domain.Entities;

namespace RH.API.Domain.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
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
}
