using RHAPI.Domain;
using RHAPI.Infra.Dto;
using RHAPI.Service.Interfaces;
using RHAPI.Utils;

namespace RHAPI.Service.Service;

public class LivroService : ILivroService
{
    public  List<Livro>  livros { get; set; } = [];
    public Livro CadastraLivro(CreateLivroDto livroDto)
    {
        try
        {
            var ExisteCodigoDeBarra = livros.Find(l => l.CodigoBarras == livroDto.CodigoBarras);
    
            if (ExisteCodigoDeBarra is not null) 
            {
                throw new CustomerException("Código de barras ja existe");
            }
    
            Livro livro = new(livroDto.Titulo, livroDto.Autor, livroDto.AnoPublicacao, livroDto.CodigoBarras, true);
    
            livros.Add(livro);
    
            return livro;
        }
        catch (Exception) { throw; }
    }

    public Livro EmprestaLivro(string codigoDeBarra)
    {
        try
        {
            int index = livros.FindIndex(l => l.CodigoBarras == codigoDeBarra);
            if (index == -1)
            {
                throw new CustomerException("Não foi encontrado livro para o codigo de barra fornecido");
            }

            Livro livroEncontrado = livros[index];

            if (!livroEncontrado.Disponivel) 
            {
                throw new CustomerException("O livro solicitado não está disponivel");
            }

            livroEncontrado.Disponivel = false;

            livros[index] = livroEncontrado;

            return livros[index];
        }
        catch (Exception) { throw; }
    }

    public Livro DevolveLivro(string codigoDeBarra)
    {
        try
        {
            int index = livros.FindIndex(l => l.CodigoBarras == codigoDeBarra);
            if (index == -1)
            {
                throw new CustomerException("Não foi encontrado livro para o codigo de barra fornecido");
            }

            Livro livroEncontrado = livros[index];

            if (livroEncontrado.Disponivel) 
            {
                throw new CustomerException("O livro solicitado está disponivel");
            }

            livroEncontrado.Disponivel = true;

            livros[index] = livroEncontrado;

            return livros[index];
        }
        catch (Exception) { throw; }
    }

    public List<Livro> ListaLivros()
    {
        try
        {
            return [.. livros];
        }
        catch (Exception) { throw; }
    }
}