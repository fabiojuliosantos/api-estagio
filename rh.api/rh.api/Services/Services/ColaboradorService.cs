using rh.api.Domain;
using rh.api.Infra.Interfaces;
using rh.api.Services.Interface;

namespace rh.api.Services.Services
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly IColaboradorRepository _repository;

        public ColaboradorService(IColaboradorRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AtualizarColaborador(Colaborador colaborador)
        {
            try
            {
                return await _repository.AtualizarColaborador(colaborador);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Colaborador> BuscarColaboradorPorId(int id)
        {
            try
            {
                return await _repository.BuscarColaboradorPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Colaborador>> BuscarTodosColaboradoresAsync()
        {
            try
            {
                var empresas = await _repository.BuscarTodosColaboradores();

                return empresas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ExcluirColaborador(int id)
        {
            try
            {
                return await _repository.ExcluirColaborador(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InserirColaborador(Colaborador colaborador)
        {
            try
            {
                return await _repository.InserirColaborador(colaborador);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
