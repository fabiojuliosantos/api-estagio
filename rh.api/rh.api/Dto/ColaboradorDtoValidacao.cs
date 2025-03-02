using FluentValidation;
using rh.api.Dto.rh.api.Domain;

public class ColaboradorDTOValidacao : AbstractValidator<ColaboradorDTO>
{
    public ColaboradorDTOValidacao()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .Length(1, 100).WithMessage("O nome não pode ter mais que 100 caracteres.");

        RuleFor(c => c.Cpf)
            .NotEmpty().WithMessage("O CPF é obrigatório.")
            .Length(11).WithMessage("O CPF deve ter 11 caracteres.")
            .Matches(@"^\d{11}$").WithMessage("O CPF deve ser numérico e ter 11 caracteres.");

        RuleFor(c => c.Matricula)
            .NotEmpty().WithMessage("A matrícula é obrigatória.");

        RuleFor(c => c.EmpresaID)
            .NotEmpty().WithMessage("O ID da empresa é obrigatório.");
    }
}


