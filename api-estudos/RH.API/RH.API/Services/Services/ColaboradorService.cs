using System.Text.RegularExpressions;
using RH.API.Domain;
using RH.API.Infra.Interfaces;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class ColaboradorService : IColaboradorService
{
    private readonly IColaboradorRepository _repository;

    public ColaboradorService(IColaboradorRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AtualizarColaborador(Colaborador colaborador)
    {
        try
        {
            if (!ValidarColaborador(colaborador))
            {
                return false;
            }

            return await _repository.AtualizarColaborador(colaborador);
        }
        catch (Exception ex) { throw; }
    }

    public async Task<Colaborador> BuscarColaboradorPorId(int id)
    {
        try
        {
            return await _repository.BuscarColaboradorPorId(id);
        }
        catch (Exception ex) { throw; }
    }

    public async Task<List<Colaborador>> BuscarTodosColaboradores()
    {
        try
        {
            var colaboradores = await _repository.BuscarTodosColaboradores();
            return colaboradores;
        }
        catch (Exception) { throw; }
    }

    public async Task<bool> ExcluirColaborador(int id)
    {
        return await _repository.ExcluirColaborador(id);
    }

    public async Task<bool> InserirColaborador(Colaborador colaborador)
    {
        if (!ValidarColaborador(colaborador))
        {
            return false;
        }

        return await _repository.InserirColaborador(colaborador);
    }

    private bool ValidarColaborador(Colaborador colaborador)
    {
        // 1. Validação do nome
        if (string.IsNullOrEmpty(colaborador.Nome) || colaborador.Nome.Length < 3 || colaborador.Nome.Length > 100 || !Regex.IsMatch(colaborador.Nome, "^[a-zA-Z\\s]+$"))
        {
            Console.WriteLine("Nome inválido: deve ter entre 3 e 100 caracteres e conter apenas letras e espaços.");
            return false;
        }

        // 2. Validação do CPF
        if (!ValidarCpf(colaborador.Cpf))
        {
            Console.WriteLine("CPF inválido.");
            return false;
        }

        // 3. Validação da matrícula
        if (colaborador.Matricula <= 0)
        {
            Console.WriteLine("Matrícula inválida: deve ser maior que zero.");
            return false;
        }

        // 4. Validação do EmpresaID
        if (colaborador.EmpresaID <= 0)
        {
            Console.WriteLine("EmpresaID inválido: deve ser maior que zero.");
            return false;
        }

        return true;
    }

    // Método para validar o CPF
    private bool ValidarCpf(string cpf)
    {
        // Remove caracteres especiais do CPF
        cpf = cpf?.Replace(".", "").Replace("-", "");

        // Verifica se o CPF tem 11 dígitos
        if (cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            return false;
        }

        // Validação para CPF repetido, como 111.111.111-11.
        if (cpf.Distinct().Count() == 1)
        {
            return false;
        }

        // Validação dos dígitos verificadores do CPF
        var numeros = cpf.Substring(0, 9);
        var digitos = cpf.Substring(9, 2);

        int soma = 0;
        int peso = 10;
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

        resto = soma % 11;
        int digito2 = resto < 2 ? 0 : 11 - resto;

        return digitos == $"{digito1}{digito2}";
    }
}
