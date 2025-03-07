using rh.api.Domain;
using rh.api.Services.Interface;

namespace rh.api.Services.Services
{
    public class EstudanteService : IEstudanteService
    {
        private static List<Estudante> _estudantes = new List<Estudante>();
        //constante
        private static int _nextId = 1; 

        public List<Estudante> ListarEstudantes()
        {
            return _estudantes;
        }

        public Estudante AdicionarEstudante(EstudanteDto estudanteDto)
        {
            // Validações
            if (string.IsNullOrEmpty(estudanteDto.Nome))
                throw new ArgumentException("O nome não pode ser vazio.");

            if (estudanteDto.Idade <= 0)
                throw new ArgumentException("A idade deve ser maior que 0.");

            if (_estudantes.Any(e => e.Matricula == estudanteDto.Matricula))
                throw new ArgumentException("Matrícula digitada já existe, corrija.");

            // Cria um novo estudante com o ID gerado automaticamente
            var estudante = new Estudante
            {
                Id = _nextId++,
                Nome = estudanteDto.Nome,
                Idade = estudanteDto.Idade,
                Curso = estudanteDto.Curso,
                Matricula = estudanteDto.Matricula
            };

            _estudantes.Add(estudante);

            return estudante;
        }

        public Estudante AtualizarEstudante(int id, EstudanteDto estudanteAtualizado)
        {
            var estudante = _estudantes.FirstOrDefault(e => e.Id == id);
            if (estudante == null)
                throw new ArgumentException("O estudante não encontrado em nossa base de dados.");

            // Validações
            if (!string.IsNullOrEmpty(estudanteAtualizado.Nome))
                estudante.Nome = estudanteAtualizado.Nome;

            if (estudanteAtualizado.Idade > 0)
                estudante.Idade = estudanteAtualizado.Idade;

            if (!string.IsNullOrEmpty(estudanteAtualizado.Curso))
                estudante.Curso = estudanteAtualizado.Curso;

            if (!string.IsNullOrEmpty(estudanteAtualizado.Matricula))
            {
                if (_estudantes.Any(e => e.Matricula == estudanteAtualizado.Matricula && e.Id != id))
                    throw new ArgumentException("Matrícula digitada já existe, corrija.");
                estudante.Matricula = estudanteAtualizado.Matricula;
            }

            return estudante;
        }
    }
}