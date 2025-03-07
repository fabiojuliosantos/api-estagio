using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Services.Services
{
    public class LivroService : ILivroService
    {
        private readonly List<Livro> _livros = new List<Livro>();

        public (bool Sucesso, string Mensagem) AdicionarLivro(Livro livro)
        {
            try
            {
                if (livro.Id <= 0)
                {
                    return (false, "ID do livro inválido. O ID deve ser um número positivo.");
                }

                if (_livros.Any(l => l.Id == livro.Id))
                {
                    return (false, "Livro já cadastrado com este ID.");
                }

                if (string.IsNullOrEmpty(livro.Titulo))
                {
                    return (false, "Título do livro não informado.");
                }

                if (string.IsNullOrEmpty(livro.Autor))
                {
                    return (false, "Autor do livro não informado.");
                }

                if (livro.AnoPublicacao <= 0)
                {
                    return (false, "Ano de publicação inválido.");
                }

                livro.Disponivel = true;
                _livros.Add(livro);
                return (true, "Livro adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool Sucesso, string Mensagem) EmprestarLivro(int id)
        {
            try
            {
                var livro = _livros.FirstOrDefault(l => l.Id == id);
                if (livro == null)
                {
                    return (false, "Livro não encontrado.");
                }

                if (!livro.Disponivel)
                {
                    return (false, "Livro já emprestado.");
                }

                livro.Disponivel = false;
                return (true, "Livro emprestado com sucesso.");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool Sucesso, string Mensagem) DevolverLivro(int id)
        {
            try
            {
                var livro = _livros.FirstOrDefault(l => l.Id == id);
                if (livro == null)
                {
                    return (false, "Livro não encontrado.");
                }

                if (livro.Disponivel)
                {
                    return (false, "Livro não está emprestado.");
                }

                livro.Disponivel = true;
                return (true, "Livro devolvido com sucesso.");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public List<Livro> ListarLivros()
        {
            return _livros;
        }
    }
}