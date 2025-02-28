namespace RH.API.DTOs;

public class CpfValidation
{
    public required string Cpf { get; set; }

    public bool Validacao()
    {
        // Remover caracteres não numéricos (pontos e traços)
        var cpf = Cpf?.Replace(".", "").Replace("-", "");

        // Verificar se o CPF é nulo ou não tem exatamente 11 caracteres
        if (cpf == null || cpf.Length != 11)
            return false;

        // Verificar se o CPF é uma sequência de números repetidos (exemplo: 111.111.111-11)
        if (cpf.All(c => c == cpf[0]))
            return false;

        // Calcular e validar o primeiro dígito verificador
        var firstDigit = CalcularDigitos(cpf, 10);

        // Calcular e validar o segundo dígito verificador
        var secondDigit = CalcularDigitos(cpf, 11);

        // Comparar os dígitos verificadores calculados com os dígitos presentes no CPF
        return cpf[9] == firstDigit && cpf[10] == secondDigit;
    }

    private static char CalcularDigitos(string cpf, int fator)
    {
        int soma = 0;

        // Laço para calcular a soma ponderada dos primeiros dígitos do CPF
        for (int i = 0; i < fator - 1; i++)
        {
            soma += (cpf[i] - '0') * (fator - i);
        }

        // Calcular o resto da divisão da soma por 11
        int sobra = soma % 11;

        // Se o resto for menor que 2, o dígito verificador é 0, senão, é 11 - o resto
        return sobra < 2 ? '0' : (char)(11 - sobra + '0');
    }
}