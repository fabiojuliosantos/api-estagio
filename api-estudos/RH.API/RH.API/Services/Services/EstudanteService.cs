using RH.API.Domain;
using RH.API.Services.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RH.API.Services
{
    public class EstudanteService : IEstudanteService
    {
        private static List<Estudante> estudantes = new List<Estudante>();
        public (bool Sucesso, string Mensagem) AdicionarEstudante(Estudante estudante)
        {

            if (estudantes.Any(e => e.Matricula == estudante.Matricula))
            {
                return (false, "Matrícula já cadastrada.");
            }

            if (!Regex.IsMatch(estudante.Nome, @"^[a-zA-Z]+$"))
            {
                return (false, "O nome deve conter apenas letras.");
            }

            if (!Regex.IsMatch(estudante.Curso, @"^[a-zA-Z]+$"))
            {
                return (false, "O curso deve conter apenas letras.");
            }

            if (estudante.Idade <= 0)
            {
                return (false, "A idade deve ser um número válido maior que 0.");
            }

            // Adiciona o estudante à lista se todas as validações passarem
            estudantes.Add(estudante);
            return (true, "Estudante adicionado com sucesso.");
        }

        public (bool Sucesso, string Mensagem, IEnumerable<Estudante> Estudantes) ListarEstudantes()
        {
            return (true, "Estudantes listados com sucesso.", estudantes);
        }

        public (bool Sucesso, string Mensagem, Estudante Estudante) ObterEstudantePorMatricula(int matricula)
        {
            var estudante = estudantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudante == null)
            {
                return (false, "Estudante não encontrado.", null);
            }
            return (true, "Estudante encontrado.", estudante);
        }

        public (bool Sucesso, string Mensagem) AtualizarEstudante(int matricula, Estudante estudanteAtualizado)
        {
            var estudanteExistente = estudantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudanteExistente == null)
            {
                return (false, "Estudante não encontrado.");
            }

            estudanteExistente.Nome = estudanteAtualizado.Nome;
            estudanteExistente.Idade = estudanteAtualizado.Idade;
            estudanteExistente.Curso = estudanteAtualizado.Curso;

            return (true, "Dados do estudante atualizados com sucesso.");
        }
    }
}
