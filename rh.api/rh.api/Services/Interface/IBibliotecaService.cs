using Biblioteca.Domain;

namespace Biblioteca.Services.Interface
{
    public interface IBibliotecaService
    {
        List<Livro> ListarLivros();
        Livro CadastrarLivro(LivroDto livroDto);
        Livro EmprestarLivro(int id);
        Livro DevolverLivro(int id);
    }
}