namespace RH.API.Data.Dtos;

public class RespostaDTO
{
    public RespostaDTO(bool sucesso, string mensagem)
    {
        Sucesso = sucesso;
        Mensagem = mensagem;
    }

    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
}
