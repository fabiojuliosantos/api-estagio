using System.Collections.Generic;
using System.Text.RegularExpressions;
using RH.API.Domain;

namespace RH.API.Services.Services
{
    public static class Validacoes
    {
        public static List<string> ValidarColaborador(Colaborador colaborador)
        {
            var mensagensDeErro = new List<string>();

            if (string.IsNullOrEmpty(colaborador.Nome) || colaborador.Nome.Length < 3 || colaborador.Nome.Length > 100 || !Regex.IsMatch(colaborador.Nome, "^[a-zA-Z\\s]+$"))
            {
                mensagensDeErro.Add("Nome inválido: deve ter entre 3 e 100 caracteres e conter apenas letras e espaços.");
            }

            if (!ValidarCpf(colaborador.Cpf))
            {
                mensagensDeErro.Add("CPF inválido.");
            }

            if (colaborador.Matricula <= 0)
            {
                mensagensDeErro.Add("Matrícula inválida: deve ser maior que zero.");
            }

            if (colaborador.EmpresaID <= 0)
            {
                mensagensDeErro.Add("ID da empresa inválido.");
            }

            return mensagensDeErro;
        }

        public static bool ValidarCpf(string cpf)
        {
            cpf = cpf?.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
            {
                return false;
            }

            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }

            var numeros = cpf.Substring(0, 9);
            var digitos = cpf.Substring(9, 2);

            int soma = 0, peso = 10;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(numeros[i].ToString()) * peso--;
            }

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            soma = 0;
            peso = 11;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(numeros[i].ToString()) * peso--;
            }

            soma += digito1 * peso--;

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return digitos == $"{digito1}{digito2}";
        }
    }
}
