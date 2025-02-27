using RH.API.Domain;
using RH.API.Infra.Interfaces;
using RH.API.Services.Interface;

namespace RH.API.Services.Services
{
    public class ColaboradoresService : IColaboradorService
    {
        private readonly IColaboradoresRepository _colaboradoresRepository;

        public ColaboradoresService(IColaboradoresRepository colaboradoresRepository)
        {
            _colaboradoresRepository = colaboradoresRepository;
        }

        public async Task<bool> InserirColaborador(Colaborador colaborador)
        {
            ValidarColaborador(colaborador);
            return await _colaboradoresRepository.InserirColaborador(colaborador);
        }

        public async Task<bool> AtualizarColaborador(Colaborador colaborador)
        {
            ValidarColaborador(colaborador);
            return await _colaboradoresRepository.AtualizarColaborador(colaborador);
        }

        public async Task<Colaborador> BuscarColaboradoresPorId(int id)
        {
            return await _colaboradoresRepository.BuscarColaboradoresPorId(id);
        }

        public async Task<List<Colaborador>> BuscarTodosColaboradores()
        {
            return await _colaboradoresRepository.BuscarTodosColaboradores();
        }

        public async Task<bool> ExcluirColaborador(int id)
        {
            return await _colaboradoresRepository.ExcluirColaborador(id);
        }

        private void ValidarColaborador(Colaborador colaborador)
        {
            if (string.IsNullOrWhiteSpace(colaborador.Nome))
                throw new Exception("O nome do colaborador é obrigatório.");

            if (string.IsNullOrWhiteSpace(colaborador.CPF))
                throw new Exception("O CPF do colaborador é obrigatório.");

            if (colaborador.Matricula <= 0)
                throw new Exception("A matrícula do colaborador deve ser um número positivo.");

            if (colaborador.EmpresaId <= 0)
                throw new Exception("O ID da empresa deve ser um número positivo.");
        }
    }
}
