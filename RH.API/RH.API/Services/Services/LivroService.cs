using RH.API.Data.Dtos;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services
{
    public class LivroService : ILivroService
    {
        private List<Livro> _livros = new();
        public RespostaDTO CadastrarLivro(Livro livro)
        {
            try
            {
                if (string.IsNullOrEmpty(livro.Titulo))
                {
                    return new RespostaDTO(false, "Titulo não pode ser nulo");
                }
                if (string.IsNullOrEmpty(livro.Autor))
                {
                    return new RespostaDTO(false, "Autor não pode ser nulo");
                }
                if (livro.AnoPublicacao <= 0 || livro.AnoPublicacao > 2025)
                {
                    return new RespostaDTO(false, "Insira um ano de publicação válido!");
                }
                if (_livros.Any(l => l.CodigoBarras == livro.CodigoBarras))
                {
                    return new RespostaDTO(false, "Codigo de barras já cadastrado");
                }

                var livros = new Livro
                {
                    Titulo = livro.Titulo,
                    Autor = livro.Autor,
                    AnoPublicacao = livro.AnoPublicacao,
                    CodigoBarras = livro.CodigoBarras,
                    Disponibilidade = true

                };
                _livros.Add(livros);
                return new RespostaDTO(true, "Livro cadastrado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public RespostaDTO DevolveLivros(int codigoBarras)
        {
            try
            {
                var livro = _livros.FirstOrDefault(l => l.CodigoBarras == codigoBarras);
                if (livro == null)
                {
                    return new RespostaDTO(false, "Livro não encotrado");
                }
                if (livro.Disponibilidade)
                {
                    return new RespostaDTO(false, "Livro já disponivel!");
                }
                livro.Disponibilidade = true;

                return new RespostaDTO(true, "Livro devolvido com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public RespostaDTO EmprestaLivro(int codigoBarras)
        {
            try
            {
                var livro = _livros.FirstOrDefault(l => l.CodigoBarras == codigoBarras);
                if (livro == null)
                {
                    return new RespostaDTO(false, "Livro não encontrado");
                }

                if (!livro.Disponibilidade)
                {
                    return new RespostaDTO(false, "Livro não disponivel para emprestimo");
                }
                livro.Disponibilidade = false;

                return new RespostaDTO(true, "Livro emprestado com sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Livro> ListarLivros()
        {
            try
            {
                if (!_livros.Any())
                {
                    throw new Exception("Nenhum livro foi encontrado");
                }
                foreach (var livros in _livros)
                {
                    Console.WriteLine($"Titulo:{livros.Titulo}\n{livros.Autor}\n{livros.AnoPublicacao}\n{livros.Disponibilidade}");
                }
                return _livros;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao processar a lista de estudantes. Detalhes: " + ex.Message);
            }
        }
    }
}
