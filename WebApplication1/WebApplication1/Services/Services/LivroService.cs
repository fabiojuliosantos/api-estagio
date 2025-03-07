using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class LivroService : ILivroService
{
    List<Livro> livros = new List<Livro>();
    public Livro AdicionarLivro(Livro livro)
    {
        try
        {
            if (livro == null)
            {
                throw new Exception("Livro inválido!");
            }
            else if (livros.Find(l => l.CodigoDeBarras == livro.CodigoDeBarras) != null)
            {
                throw new Exception($"O livro com código de barras {livro.CodigoDeBarras} já existe!");
            }
            else
            {
                livro.Disponibilidade = "disponível";
                livros.Add(livro);
                return livro;
            }
        }
        catch (Exception e) { throw e; }
    }

    public void DevolverLivro(int codigoDeBarras)
    {
        try
        {
            var verificacaoLivro = livros.Find(l => l.CodigoDeBarras == codigoDeBarras);
            if (verificacaoLivro == null)
            {
                throw new Exception($"O livro com o código de barras {codigoDeBarras} não pertence ao nosso catálogo.");
            }
            else if (verificacaoLivro != null && verificacaoLivro.Disponibilidade == "disponível")
            {
                throw new Exception("O livro já foi devolvido, algo de errado não está certo.");
            }
            else
            {
                verificacaoLivro.Disponibilidade = "disponível";
            }
        }
        catch (Exception e) { throw e; }
    }

    public void EmprestarLivro(int codigoDeBarras)
    {
        try
        {
            var verificacaoLivro = livros.Find(l => l.CodigoDeBarras == codigoDeBarras);
            if (verificacaoLivro == null)
            {
                throw new Exception($"O livro com o código de barras {codigoDeBarras} não pertence ao nosso catálogo.");
            }
            else if (verificacaoLivro != null && verificacaoLivro.Disponibilidade == "indisponível")
            {
                throw new Exception($"Não temos o livro '{verificacaoLivro.Titulo}' atualmente disponível para o empréstimo.");
            }
            else
            {
                verificacaoLivro.Disponibilidade = "indisponível";
            }
        }
        catch (Exception e) { throw e; }
    }

    public List<Livro> ListarLivros()
    {
        try
        {
            return livros;
        }
        catch (Exception e) { throw e; }
    }
}
