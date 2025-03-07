using RH.API.Data.Dtos;
using RH.API.Domain;

namespace RH.API.Services.Interface;

public interface ILivroService 
{
    RespostaDTO CadastrarLivro(Livro livro);
    RespostaDTO EmprestaLivro(int codigoBarras);
    RespostaDTO DevolveLivros(int codigoBarras);
    List<Livro> ListarLivros();
}
