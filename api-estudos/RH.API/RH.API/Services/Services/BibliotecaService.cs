using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services
{
    public class BibliotecaService : IBibliotecaService
    {
        private readonly List<Biblioteca> _livros = new List<Biblioteca>();

        public (bool Sucesso, string Mensagem) CadastrarLivro(Biblioteca livro)
        {
            try
            {
                if (_livros.Any(l => l.CodigoDeBarras == livro.CodigoDeBarras))
                {
                    return (false, "Livro com esse código de barras já existe.");
                }

                if (livro.AnoPublicacao < 0 || livro.AnoPublicacao > 2025)
                {
                    return (false, "O ano de publicação não pode ser negativo ou maior que 2025.");
                }

                if (livro.CodigoDeBarras <= 0)
                {
                    return (false, "O código de barras não pode ser menor ou igual a zero.");
                }

                _livros.Add(livro);
                return (true, "Livro cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao cadastrar livro: {ex.Message}");
            }
        }

        public (bool Sucesso, string Mensagem) EmprestarLivro(int codigoDeBarras)
        {
            try
            {
                var livro = _livros.FirstOrDefault(l => l.CodigoDeBarras == codigoDeBarras);
                if (livro == null)
                {
                    return (false, "Livro não encontrado.");
                }

                if (livro.Status == "Emprestado")
                {
                    return (false, "O livro já está emprestado.");
                }

                livro.Status = "Emprestado";
                return (true, "Livro emprestado com sucesso.");
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao emprestar livro: {ex.Message}");
            }
        }

        public (bool Sucesso, string Mensagem) DevolverLivro(int codigoDeBarras)
        {
            try
            {
                var livro = _livros.FirstOrDefault(l => l.CodigoDeBarras == codigoDeBarras);
                if (livro == null)
                {
                    return (false, "Livro não encontrado.");
                }

                livro.Status = "Disponível";
                return (true, "Livro devolvido com sucesso.");
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao devolver livro: {ex.Message}");
            }
        }

        public (bool Sucesso, string Mensagem, IEnumerable<Biblioteca> Livros) ListarLivros()
        {
            try
            {
                return (true, "Livros listados com sucesso.", _livros);
            }
            catch (Exception ex)
            {
                return (false, $"Erro ao listar livros: {ex.Message}", null);
            }
        }
    }
}
