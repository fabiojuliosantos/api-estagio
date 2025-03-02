using FluentValidation;

namespace rh.api.Domain
{

    public class ColaboradorCpfValidacao : AbstractValidator<Colaborador>
    {
        public ColaboradorCpfValidacao()
        {
            RuleFor(colaborador => colaborador.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(1, 100).WithMessage("O nome não pode ter mais que 100 caracteres.");

            RuleFor(colaborador => colaborador.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Length(11).WithMessage("O CPF deve ter 11 caracteres.")
                .Matches(@"^\d{11}$").WithMessage("O CPF deve ser numérico e ter 11 caracteres.")
                .Must(ValidarCpf).WithMessage("O CPF informado é inválido.");

            RuleFor(colaborador => colaborador.Matricula)
                .NotEmpty().WithMessage("A matrícula é obrigatória.");

            RuleFor(colaborador => colaborador.EmpresaID)
                .NotEmpty().WithMessage("O ID da empresa é obrigatório.");
        }

        private bool ValidarCpf(string cpf)
        {
            // Função para validar CPF (implementar conforme a regra do CPF)
            if (string.IsNullOrEmpty(cpf) || cpf.Length != 11)
                return false;

            // Implementação básica de validação de CPF (verificar se o CPF é válido)
            // Lógica de verificação aqui
            return true; // Retorne true se for válido, false caso contrário
        }
    }
}

