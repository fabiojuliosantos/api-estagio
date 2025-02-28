using RH.API.Domain;
using RH.API.Infra.Interfaces;

namespace RH.API.Validacao;

public class Validacoes
{
    private readonly IColaboradorRepository _repository;



    public Validacoes(IColaboradorRepository repository)
    {
        _repository = repository;
    }

    #region Validações CPF
    // VERIFICA SE TODOS OS DIGITOS SÂO IGUAIS
    public bool VerificaDigitosIguais(string cpf)
    {
        for (int i = 1; i < cpf.Length; i++)
        {
            if (cpf[i] != cpf[0])
            {
                return false;
            }
        }
        return true;
    }

    // Calcula os dígitos verificadores

    public int CalculaDigitoVerificador(int[] digitos, int pesoInicial)
    {
        int soma = 0;
        for (int i = 0; i < pesoInicial - 1; i++)
        {
            soma += digitos[i] * (pesoInicial - i);
        }

        int resto = soma % 11;

        if (resto < 2)
            return 0;
        else
            return 11 - resto;
    }

    // Validação do CPF
    public async Task<bool> ValidaCpf(string cpf)
    {
        try
        {
            if (await VerificaCpfIgualAsync(cpf)) 
                {
                throw new Exception("O CPF inserido já existe na base de dados!");
            }
            else {
                bool verificacaoDigitosIguais = VerificaDigitosIguais(cpf);

                if (!verificacaoDigitosIguais)
                {
                    int[] digitos = new int[11];
                    for (int i = 0; i < 11; i++)
                    {
                        digitos[i] = int.Parse(cpf[i].ToString());
                    }

                    int primeiroDigitoVerificador = CalculaDigitoVerificador(digitos, 10);

                    int segundoDigitoVerificador = CalculaDigitoVerificador(digitos, 11);

                    // Verifica se os dígitos verificadores estão corretos
                    if (digitos[9] == primeiroDigitoVerificador && digitos[10] == segundoDigitoVerificador)
                        return true;
                    else
                        return false;
                }
                else
                {
                    throw new Exception("CPF inválido. Digitos iguais!");
                }
            }
           
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
        
    }

    public async Task<bool> VerificaCpfIgualAsync(string cpf)
    {
        if (await _repository.CpfExistenteAsync(cpf)) return true; // Retorna true caso exista um cpf
        else return false; // Retorna false caso não exista o cpf
    }
    #endregion

    #region Validação página vazia

    public bool VerificaPaginaVazia(int pagina, int quantidade, int totalColaboradores)
    {
        int totalPaginas = totalColaboradores / quantidade;

        if (pagina > totalPaginas)
            return true; // Falso para quando a pagina solicitada for maior que o total de paginas (retornaria uma pagina vazia)
        else
            return false; // Verdadeiro para quando a pagina solicitada estiver dentro do total de paginas
    }
    #endregion
}

