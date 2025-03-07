using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class BibliotecaService : IBibliotecaService
{
    public LivroDTO AdicionarLivro(LivroDTO livroDTO)
    {
        throw new NotImplementedException();
    }

    public LivroDTO BuscarLivroPorCodigoBarras(string codigoBarras)
    {
        throw new NotImplementedException();
    }

    public bool DevolverLivro(string codigoBarras)
    {
        throw new NotImplementedException();
    }

    public bool EmprestarLivro(string codigoBarras)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<LivroDTO> ListarLivros()
    {
        throw new NotImplementedException();
    }

    public bool RemoverLivro(string codigoBarras)
    {
        throw new NotImplementedException();
    }
}
