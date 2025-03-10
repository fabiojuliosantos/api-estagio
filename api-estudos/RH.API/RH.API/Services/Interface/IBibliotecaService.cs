using RH.API.Domain;

namespace RH.API.Services.Interface
{
    public interface IBibliotecaService
    {
        (bool Sucesso, string Mensagem) CadastrarLivro(Biblioteca livro);
        (bool Sucesso, string Mensagem) EmprestarLivro(int codigoDeBarras);
        (bool Sucesso, string Mensagem) DevolverLivro(int codigoDeBarras);
        (bool Sucesso, string Mensagem, IEnumerable<Biblioteca> Livros) ListarLivros();
    }
}
