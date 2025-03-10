using RH.API.Domain;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class BibliotecaService : IBibliotecaService
{
    private static List<Livro> _livros = new();
    private static int _proximoId = 1;
    public LivroDTO AdicionarLivro(LivroDTO livroDTO)
    {
        if (livroDTO == null)
        {
            throw new Exception("O livro nao pode ser nulo");
        }
        if(_livros.Any(l => l.CodigoBarras == livroDTO.CodigoBarras))
        {
            throw new Exception("ja existe um livro com o mesmo codigo de barras");
        }

        var livro = new Livro
        {
            Id = _proximoId++,
            Titulo = livroDTO.Titulo,
            Autor = livroDTO.Autor,
            AnoPublicacao = livroDTO.AnoPublicacao,
            CodigoBarras = livroDTO.CodigoBarras,
            Emprestado = false
        };

        _livros.Add(livro);

        return new LivroDTO
        {
            Titulo = livro.Titulo,
            Autor = livro.Autor,
            AnoPublicacao = livro.AnoPublicacao,
            CodigoBarras = livro.CodigoBarras,
            Disponivel = !livro.Emprestado
        };
    }

    public LivroDTO BuscarLivroPorCodigoBarras(string codigoBarras)
    {
        var livro = _livros.FirstOrDefault(l => l.CodigoBarras == codigoBarras);
        if (livro == null)
        {
            throw new Exception("Livro nao encontrado");
        }

        return new LivroDTO
        {
            Titulo = livro.Titulo,
            Autor = livro.Autor,
            AnoPublicacao = livro.AnoPublicacao,
            CodigoBarras = livro.CodigoBarras,
            Disponivel = !livro.Emprestado
        };
    }

    public bool DevolverLivro(string codigoBarras)
    {
        var livro = _livros.FirstOrDefault(l => l.CodigoBarras == codigoBarras);
        if (livro == null)
        {
            throw new Exception("Livro nao encontrado");
        }
        if (!livro.Emprestado)
        {
            throw new Exception("O livro ja esta disponivel");
        }
        livro.Emprestado = false;
        return true;
    }

    public bool EmprestarLivro(string codigoBarras)
    {
        var livro = _livros.FirstOrDefault(l => l.CodigoBarras == codigoBarras);
        if (livro == null)
        {
            throw new Exception("Livro nao encontrado");
        }
        if (livro.Emprestado)
        {
            throw new Exception("O livro ja esta emprestado");
        }
        livro.Emprestado = true;
        return true;
    }

    public IEnumerable<LivroDTO> ListarLivros()
    {
        return _livros.Select(l => new LivroDTO
        {
            Titulo = l.Titulo,
            Autor = l.Autor,
            AnoPublicacao = l.AnoPublicacao,
            CodigoBarras = l.CodigoBarras,
            Disponivel = !l.Emprestado
        }).ToList();
    }

    public bool RemoverLivro(string codigoBarras)
    {
        var livro = _livros.FirstOrDefault(l => l.CodigoBarras == codigoBarras);
        if (livro == null)
        {
            throw new Exception("Livro nao encontrado");
        }

        return _livros.Remove(livro);
    }
}
