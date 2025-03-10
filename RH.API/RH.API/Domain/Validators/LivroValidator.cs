using FluentValidation;
using RH.API.Domain.Entities.TestePOO;

namespace RH.API.Domain.Validators;

public class LivroValidator : AbstractValidator<Livro>
{
    public LivroValidator()
    {
        RuleFor(x => x.CodigoBarras)
            .NotNull().GreaterThan(0).WithMessage("O campo '{PropertyName}' deve ser um número positivo");

        RuleFor(x => x.Titulo)
            .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório!")
            .MaximumLength(50).WithMessage("O campo '{PropertyName}' deve ter até {MaxLenght} caracteres!");

        RuleFor(x => x.Autor)
            .NotNull().NotEmpty().WithMessage("O campo '{PropertyName}' é obrigatório!")
            .MaximumLength(50).WithMessage("O campo '{PropertyName}' deve ter até {MaxLenght} caracteres!");

        RuleFor(x => x.AnoPublicacao)
            .NotNull().WithMessage("O campo '{PropertyName}' é obrigatório!")
            .NotEmpty().WithMessage("O campo '{PropertyName}' não pode estar vazio!")
            .InclusiveBetween(1800, DateTime.Now.Year)
            .WithMessage($"O campo '{{PropertyName}}' deve estar entre 1800 e {DateTime.Now.Year}!");

        RuleFor(x => x.Disponibilidade)
            .NotNull().WithMessage("O campo '{PropertyName}' é obrigatório!")
            .Equal(true).WithMessage("O campo '{PropertyName}' deve ser verdadeiro para cadastro!");
    }
}
