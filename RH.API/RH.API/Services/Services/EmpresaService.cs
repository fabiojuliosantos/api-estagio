using RH.API.Data.Dtos;
using RH.API.Domain;
using RH.API.Infra.Interfaces;
using RH.API.Services.Interface;

namespace RH.API.Services.Services;

public class EmpresaService : IEmpresaService
{
    private readonly IEmpresaRepository _repository;

    public EmpresaService(IEmpresaRepository repository)
    {
        _repository = repository;
    }

    #region atualizar empresa
    public async Task<RespostaDTO> AtualizarEmpresa( AtualizarEmpresaDto empresaDto)
    {
        try
        {
            // 🔹 Validação inicial
            if (empresaDto.EmpresaId <= 0)
                return new RespostaDTO(false, "ID inválido");

            if (string.IsNullOrWhiteSpace(empresaDto.Nome))
                return new RespostaDTO(false, "O nome da empresa é obrigatório");

            // 🔹 Buscar empresa no banco
            var empresaExistente = await _repository.BuscarEmpresaPorId(empresaDto.EmpresaId);
            if (empresaExistente == null)
                return new RespostaDTO(false, "Empresa não encontrada");

            // 🔹 Atualizar os dados da empresa
            empresaExistente.Nome = empresaDto.Nome;

            bool resultado = await _repository.AtualizarEmpresa(empresaExistente);

            if (!resultado)
                return new RespostaDTO(false, "Erro ao atualizar empresa");

            return new RespostaDTO(true, "Empresa atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            return new RespostaDTO(false, $"Erro interno: {ex.Message}");
        }
    }
    #endregion

    #region Buscar empresa por ID
    public async Task<Empresa> BuscarEmpresaPorId(int id)
    {
        try 
        {
            return await _repository.BuscarEmpresaPorId(id);
        } 
        catch (Exception) 
        {
            throw; 
        }
    }
    #endregion

    #region Buscar todas as empresas
    public async Task<List<Empresa>> BuscarTodasEmpresasAsync()
    {
        try
        {
            var empresas = await _repository.BuscarTodasEmpresas();

            return empresas;
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion

    #region excluir empresa
    public async Task<RespostaDTO> ExcluirEmpresa(int id)
    {
        try
        {
            if (id <= 0)
                return new RespostaDTO(false, "ID da empresa é obrigatório");

            var empresaExistente = await _repository.BuscarEmpresaPorId(id);
            if (empresaExistente == null)
                return new RespostaDTO(false, "Empresa não encontrada");

            bool resultado = await _repository.ExcluirEmpresa(id);

            return resultado
                ? new RespostaDTO(true, "Empresa excluída com sucesso!")
                : new RespostaDTO(false, "Erro ao excluir empresa");
        }
        catch (Exception ex)
        {
            return new RespostaDTO(false, $"Erro interno: {ex.Message}");
        }
    }
    #endregion

    #region Inserir empresa
    public async Task<RespostaDTO> InserirEmpresa(EmpresaDto empresaDto)
    {
        try
        {
            
            if (string.IsNullOrWhiteSpace(empresaDto.Nome))
                return new RespostaDTO(false, "O nome da empresa é obrigatório");

            // Verificar se já existe uma empresa com o mesmo nome
            var empresaExistente = await _repository.BuscarPorNome(empresaDto.Nome);
            if (empresaExistente != null)
                return new RespostaDTO(false, "Já existe uma empresa com este nome");

            // Criar entidade Empresa
            var empresa = new Empresa
            {
                Nome = empresaDto.Nome
            };

            // Inserir no banco
            bool resultado = await _repository.InserirEmpresa(empresa);

            if (!resultado)
                return new RespostaDTO(false, "Erro ao inserir empresa");

            return new RespostaDTO(true, "Empresa cadastrada com sucesso!");
        }
        catch (Exception ex)
        {
            return new RespostaDTO(false, $"Erro interno: {ex.Message}");
        }
    }
    #endregion
}
