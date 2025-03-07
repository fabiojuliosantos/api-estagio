using RH.API.DTOs;

namespace RH.API.Services.Interface;

public interface IBibliotecaService
{
    IEnumerable<LivroDTO> ListarLivros();
    LivroDTO BuscarLivroPorCodigoBarras(string codigoBarras);
    LivroDTO AdicionarLivro(LivroDTO livroDTO);
    bool EmprestarLivro(string codigoBarras);
    bool DevolverLivro(string codigoBarras);
    bool RemoverLivro(string codigoBarras);
}
