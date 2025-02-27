namespace RHAPI.Utils;

public class Validator
{
    public static bool ValidaCPF(string cpf)
    {
        // valida se cpf nao tem 11 caracteres e se os caracteres não sao digitos numericos
        if (cpf.Length != 11 || !cpf.All(char.IsDigit)) 
        {
            return false;
        }

        var penultimoDigitoCpfInserido = int.Parse(cpf[9].ToString());
        var ultimoDigitoCpfInserido = int.Parse(cpf[10].ToString());

        string noveCaracteresCpfInserido = cpf[..9]; // Esta variavel armazena os nove primeiros caracteres.
        string dezCaracteresCpfInserido = cpf[..10]; // Esta variavel armazena os dez primeiros caracteres.

        var primeiroDigitoVerificador = CalculaDigitoVerificador(10, noveCaracteresCpfInserido);
        var segundoDigitoVerificador = CalculaDigitoVerificador(11, dezCaracteresCpfInserido);

        // Valida se os dígitos batem
        if (primeiroDigitoVerificador == penultimoDigitoCpfInserido && segundoDigitoVerificador == ultimoDigitoCpfInserido)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static int CalculaDigitoVerificador(int peso, string cadeiaDeCaracteres)
    {
        
        List<int> resultado = []; // lista para armazenar a multiplicação do dígito pelo peso.
    
        for(int i = 0; i < cadeiaDeCaracteres.Length; i++) 
        {
            var numeroInteiro = int.Parse(cadeiaDeCaracteres[i].ToString());
            var resultadoMultiplicacaoDigitoPeso = numeroInteiro * peso;
            resultado.Add(resultadoMultiplicacaoDigitoPeso);
            peso--;
        }      

        var resto = resultado.Sum() % 11; 
        
        return (resto < 2) ? 0 : 11 - resto;
        
    }
}