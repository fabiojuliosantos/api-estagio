using RH.API.Domain;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class ColaboradorService : IColaboradorService
{
    private readonly IColaboradorRepository _repository;

    public ColaboradorService(IColaboradorRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ColaboradorDTO>> BuscarTodosColaboradores()
    {
        try
        {
            return await _repository.BuscarTodosColaboradores();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao buscar todos os colaboradores: {ex.Message}");
            throw;
        }
    }

    public async Task<ColaboradorDTO> BuscarColaboradorPorId(int id)
    {
        try
        {
            var colaborador = await _repository.BuscarColaboradorPorId(id);
            if (colaborador == null)
            {
                throw new KeyNotFoundException("Colaborador não encontrado.");
            }
            return colaborador;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao buscar colaborador por ID: {ex.Message}");
            throw;
        }
    }
    public async Task<bool> InserirColaborador(CreateColaboradorDTO colaboradorDTO)
    {
        try
        {
            // Validação de CPF
            var validador = new CpfValidation { Cpf = colaboradorDTO.CPF };
            if (!validador.Validacao())
            {
                throw new ArgumentException("CPF inválido.");
            }

            var colaborador = new Colaborador
            {
                Nome = colaboradorDTO.Nome,
                CPF = colaboradorDTO.CPF,
                Matricula = colaboradorDTO.Matricula,
                EmpresaID = colaboradorDTO.EmpresaID
            };

            return await _repository.InserirColaborador(colaborador);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao inserir colaborador: {ex.Message}");
            throw;
        }
    }
    public async Task<bool> AtualizarColaborador(UpdateColaboradorDTO colaboradorDTO)
    {
        try
        {
            var colaboradorExistente = await _repository.BuscarColaboradorPorId(colaboradorDTO.ColaboradorId);
            if (colaboradorExistente == null)
            {
                throw new KeyNotFoundException("Colaborador não encontrado.");
            }

            var colaborador = new Colaborador
            {
                ColaboradorID = colaboradorDTO.ColaboradorId,
                Nome = colaboradorDTO.Nome ?? colaboradorExistente.Nome,
                Matricula = colaboradorDTO.Matricula ?? colaboradorExistente.Matricula,
                EmpresaID = colaboradorDTO.EmpresaId ?? colaboradorExistente.EmpresaID
            };

            return await _repository.AtualizarColaborador(colaborador);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar colaborador: {ex.Message}");
            throw;
        }
    }
    public async Task<bool> ExcluirColaborador(int id)
    {
        try
        {
            var colaborador = await _repository.BuscarColaboradorPorId(id);
            if (colaborador == null)
            {
                throw new KeyNotFoundException("Colaborador não encontrado.");
            }
            return await _repository.ExcluirColaborador(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao excluir colaborador: {ex.Message}");
            throw;
        }
    }
    public async Task<RetornoPaginadoColaborador<Colaborador>> BuscarColaboradorPorPaginaAsync(int pagina, int quantidade)
    {
        try
        {
            return await _repository.BuscarColaboradorPorPaginaAsync(pagina, quantidade);
        }
        catch (Exception) { throw; }
    }
}
