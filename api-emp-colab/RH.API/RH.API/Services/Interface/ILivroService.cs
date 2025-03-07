using RH.API.Domain;

namespace RH.API.Services.Interface
{
    public interface ILivroService
    {
        (bool Sucesso, string Mensagem) AdicionarLivro(Livro livro);
        (bool Sucesso, string Mensagem) EmprestarLivro(int id);
        (bool Sucesso, string Mensagem) DevolverLivro(int id);
        List<Livro> ListarLivros();
    }
}
