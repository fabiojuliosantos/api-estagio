using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface ILivroService
{
    Livro AdicionarLivro (Livro livro);
    void EmprestarLivro(int codigoDeBarras);
    void DevolverLivro (int codigoDeBarras);
    List<Livro> ListarLivros();

}
