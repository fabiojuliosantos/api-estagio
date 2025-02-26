using RH.API.Domain;
using RH.API.Infra.Interfaces;
using RH.API.Services.Interface;

namespace RH.API.Services.Services
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly IColaboradorRepository _repository;

        public ColaboradorService(IColaboradorRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> AtualizarColaboradorAsync(Colaborador colaborador)
        {
            try
            {
                var colaboradorAtualizado = await _repository.AtualizarColaboradorAsync(colaborador);

                return colaboradorAtualizado ? $"Colaborador {colaborador.Nome} Atualizado!" : "Não foi possível atualizar o colaborador.";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Colaborador> BuscarColaboradorPorIdAsync(int id)
        {
            try
            {
                var colaborador = await _repository.BuscarColaboradorPorIdAsync(id);

                return colaborador;
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
                var colaboradores = await _repository.BuscarTodosColaboradoresAsync();

                return colaboradores;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> ExcluirColaboradorAsync(int id)
        {
            try
            {
                var colaborador = await _repository.ExcluirColaboradorAsync(id);

                return colaborador ? "Colaborador excluído com sucesso!" : "Não foi possível excluir o colaborador!";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> InserirColaboradorAsync(Colaborador colaborador)
        {
            try
            {
                var colaboradorCadastrado = await _repository.InserirColaboradorAsync(colaborador);

                return colaboradorCadastrado ? $"Colaborador {colaborador.Nome} cadastrado com sucesso!" : "Não foi possível cadastrar o colaborador.";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
