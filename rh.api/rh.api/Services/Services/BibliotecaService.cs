using Biblioteca.Domain;
using Biblioteca.Services.Interface;

namespace Biblioteca.Services.Services
{
    public class BibliotecaService : IBibliotecaService
    {
        private static List<Livro> _livros = new List<Livro>();
        private static int _nextId = 1; // Gerador de IDs únicos

        public List<Livro> ListarLivros()
        {
            return _livros;
        }

        public Livro CadastrarLivro(LivroDto livroDto)
        {
            try
            { //Validações
                if (string.IsNullOrEmpty(livroDto.Titulo))
                    throw new ArgumentException("O título do livro não pode ser vazio.");

                if (string.IsNullOrEmpty(livroDto.Autor))
                    throw new ArgumentException("O autor do livro não pode ser vazio.");

                if (livroDto.AnoPublicacao <= 0)
                    throw new ArgumentException("O ano de publicação deve ser maior que 0.");

                if (_livros.Any(l => l.CodigoBarras == livroDto.CodigoBarras))
                    throw new ArgumentException("Código de barras já cadastrado.");

                //Cria o livro
                var livro = new Livro
                {
                    Id = _nextId++,
                    Titulo = livroDto.Titulo,
                    Autor = livroDto.Autor,
                    AnoPublicacao = livroDto.AnoPublicacao,
                    CodigoBarras = livroDto.CodigoBarras,
                    Disponivel = true //Por padrão, o livro está disponível
                };

                _livros.Add(livro);
                return livro;

            }
            catch (Exception) { throw; }

        }

        public Livro EmprestarLivro(int id)
        {
            try
            {
                var livro = _livros.FirstOrDefault(l => l.Id == id);
                if (livro == null)
                    throw new ArgumentException("Livro não encontrado.");

                if (!livro.Disponivel)
                    throw new ArgumentException("O livro já está emprestado.");

                livro.Disponivel = false; //Marca o livro como emprestado
                return livro;
            }
            catch (Exception) { throw; }

        }

        public Livro DevolverLivro(int id)
        {
            try
            {
                var livro = _livros.FirstOrDefault(l => l.Id == id);
                if (livro == null)
                    throw new ArgumentException("Desculpe, livro não encontrado.");

                if (livro.Disponivel)
                    throw new ArgumentException("O livro já está disponível no momento.");

                livro.Disponivel = true; //Marca o livro como disponível
                return livro;
            }
            catch (Exception) { throw; }

        }
    }
}