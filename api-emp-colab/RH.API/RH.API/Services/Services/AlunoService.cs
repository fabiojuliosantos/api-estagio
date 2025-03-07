using RH.API.Domain;
using RH.API.Dto;
using RH.API.Services.Interface;

namespace RH.API.Services.Services
{
    public class AlunoService : IAluno
    {
        private readonly List<Aluno> _alunos = new List<Aluno>();
        public (bool Sucesso, string Mensagem) AdicionarAluno(Aluno aluno)
        {
            try
            {
                if (_alunos.Any(a => a.Matricula == aluno.Matricula))
                {
                    return (false, "Matrícula já cadastrada");
                }
                if (string.IsNullOrEmpty(aluno.Nome))
                {
                    return (false, "Nome do aluno não informado");
                }
                if (aluno.Idade <= 0)
                {
                    return (false, "Idade do aluno inválida");
                }
                if (aluno.Matricula <= 0)
                {
                    return (false, "Matrícula do aluno inválida");
                }
                if (string.IsNullOrEmpty(aluno.Curso))
                {
                    return (false, "Curso do aluno não informado");
                }
                _alunos.Add(aluno);
                return (true, "Aluno adicionado com sucesso");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool Sucesso, string Mensagem) AtualizarMatricula(int matricula, UpdateAlunoDto alunoDto)
        {
            try
            {
                var alunoExistente = _alunos.FirstOrDefault(a => a.Matricula == matricula);

                if (alunoExistente == null)
                {
                    return (false, "Aluno não encontrado.");
                }

                alunoExistente.Nome = alunoDto.Nome;
                alunoExistente.Idade = alunoDto.Idade;
                alunoExistente.Curso = alunoDto.Curso;

                return (true, "Matrícula atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public List<Aluno> ListarAlunos()
        {
            return _alunos;
        }
    }
}


