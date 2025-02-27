using System.ComponentModel.DataAnnotations;

namespace RH.API.Dto
{
    public class CpfValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            try
            {
                string cpf = value.ToString().Replace(".", "").Replace("-", "");
                if (cpf.Length < 11 || cpf.Length > 11)
                {
                    return new ValidationResult("O CPF deve possuir 11 caracteres.");
                }
                if (cpf.Any(letras => Char.IsLetter(letras)) || cpf.Any(letras => Char.IsPunctuation(letras)))
                {
                    return new ValidationResult("O CPF só pode possuir números.");

                }
                int[] cpfSeparado = cpf.Select(numeros => (int)Char.GetNumericValue(numeros)).ToArray();
                //Primeira Verificação do Enunciado da questão

                int peso = 10;
                int valorTotalSoma = 0;
                int compararPrimeiroNumero = 0;
                for (int i = 0; i <= (cpfSeparado.Length - 3); i++)
                {
                    int valor = cpfSeparado[i] * peso;
                    valorTotalSoma += valor;
                    peso--;
                }
                if ((valorTotalSoma % 11) < 2)
                {
                    compararPrimeiroNumero = 0;
                }
                else
                {
                    compararPrimeiroNumero = (11 - (valorTotalSoma % 11));
                }

                //Segunda Verificação do Enunciado da questão
                if (compararPrimeiroNumero == cpfSeparado[9])
                {
                    int novoPeso = 11;
                    int novoValorTotalSoma = 0;
                    int compararSegundoNumero = 0;
                    for (int i = 0; i <= (cpfSeparado.Length - 2); i++)
                    {
                        int valor = (cpfSeparado[i]) * novoPeso;
                        novoValorTotalSoma += valor;
                        novoPeso--;
                    }
                    if ((novoValorTotalSoma % 11) < 2)
                    {
                        compararSegundoNumero = 0;
                    }
                    else
                    {
                        compararSegundoNumero = (11 - (novoValorTotalSoma % 11));
                    }

                    //Ultima verificação

                    if (compararPrimeiroNumero == cpfSeparado[9] && compararSegundoNumero == cpfSeparado[10])
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("CPF é inválido");
                    }
                }
                else { return new ValidationResult("CPF é inválido"); }
            }
            catch (Exception) { throw; }
        }
    }
}
