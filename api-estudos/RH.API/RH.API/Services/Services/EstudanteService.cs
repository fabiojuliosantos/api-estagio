using AutoMapper;
using RH.API.Domain;
using RH.API.Services.Interface;
using System.Text.RegularExpressions;

namespace RH.API.Services
{
    public class EstudanteService : IEstudanteService
    {
        private static List<Estudante> estudantes = new List<Estudante>();
        private readonly IMapper _mapper;

        public EstudanteService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public (bool Sucesso, string Mensagem) AdicionarEstudante(Estudante estudante)
        {
            if (estudantes.Any(e => e.Matricula == estudante.Matricula))
            {
                return (false, "Matrícula já cadastrada.");
            }

            if (estudante.Matricula <= 0)
            {
                return (false, "A matrícula deve ser um número válido maior que 0.");
            }

            if (!Regex.IsMatch(estudante.Nome, @"^[\p{L} ]+$"))
            {
                return (false, "O nome deve conter apenas letras e espaços.");
            }

            if (!Regex.IsMatch(estudante.Curso, @"^[\p{L} ]+$"))
            {
                return (false, "O curso deve conter apenas letras e espaços.");
            }

            if (estudante.Idade <= 0)
            {
                return (false, "A idade deve ser um número válido maior que 0.");
            }

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

        public (bool Sucesso, string Mensagem) AtualizarEstudante(int matricula, EstudantePutDto estudanteDto)
        {
            var estudanteExistente = estudantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudanteExistente == null)
            {
                return (false, "Estudante não encontrado.");
            }

            if (!Regex.IsMatch(estudanteDto.Nome, @"^[\p{L} ]+$"))
            {
                return (false, "O nome deve conter apenas letras e espaços.");
            }

            if (!Regex.IsMatch(estudanteDto.Curso, @"^[\p{L} ]+$"))
            {
                return (false, "O curso deve conter apenas letras e espaços.");
            }

            if (estudanteDto.Idade <= 0)
            {
                return (false, "A idade deve ser um número válido maior que 0.");
            }

            _mapper.Map(estudanteDto, estudanteExistente);
            return (true, "Dados do estudante atualizados com sucesso.");
        }
    }
}
