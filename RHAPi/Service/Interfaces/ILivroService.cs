using RHAPI.Domain;
using RHAPI.Infra.Dto;

namespace RHAPI.Service.Interfaces;

public interface ILivroService
{
    Livro CadastraLivro(CreateLivroDto livroDto);
    Livro EmprestaLivro(string codigoDeBarra);
    Livro DevolveLivro(string codigoDeBarra);
    List<Livro> ListaLivros();
}