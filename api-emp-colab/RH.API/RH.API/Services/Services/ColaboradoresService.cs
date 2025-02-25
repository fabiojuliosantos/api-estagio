using RH.API.Domain;
using RH.API.Infra.Interfaces;
using RH.API.Services.Interface;

namespace RH.API.Services.Services
{
    public class ColaboradoresService : IColaboradorService
    {
        private readonly IColaboradoresRepository _repository;
        public ColaboradoresService(IColaboradoresRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AtualizarColaborador(Colaborador colaborador)
        {
            try
            {
                return await _repository.AtualizarColaborador(colaborador);
            }
            catch { throw; }
        }

        public async Task<Colaborador> BuscarColaboradoresPorId(int id)
        {
            try
            {
                return await _repository.BuscarColaboradoresPorId(id);
            }
            catch { throw; }
        }

        public async Task<List<Colaborador>> BuscarTodosColaboradores()
        {
            try
            {
                return await _repository.BuscarTodosColaboradores();
            }
            catch { throw; }
        }

        public async Task<bool> ExcluirColaborador(int id)
        {
            return await _repository.ExcluirColaborador(id);
        }

        public async Task<bool> InserirColaborador(Colaborador colaborador)
        {
            return await _repository.InserirColaborador(colaborador); 
        }
    }
}
