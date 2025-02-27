using RHAPi.Domain;
using RHAPI.Infra.Dto;
using RHAPI.Infra.Interfaces;
using RHAPI.Service.Interfaces;
using RHAPI.Utils;

namespace RHAPI.Service.Service;

public class ColaboradorService : IColaboradorService
{
    private readonly IColaboradorRepository _repository;

    public ColaboradorService(IColaboradorRepository repository)
    {
        _repository = repository;
    }
    public async Task<Colaborador> BucarColaboradorPorId(int id)
    {
        Colaborador colaborador = await _repository.BuscarPorId(id);

        if (colaborador is null) 
        {
            throw new CustomerException("Colaborador não encontrado", 404);
        }

        return colaborador;
    }

    public async Task<List<Colaborador>> BucarTodosColaboradores()
    {
        return await _repository.BuscarTodos();
    }

    public async Task<bool> InserirColaborador(CreateColaboradorDto colaborador)
    {
        var cpfEhValido = Validator.ValidaCPF(colaborador.Cpf!);

        if (!cpfEhValido)
        {
            throw new CustomerException("Cpf está no formato inválido", 400);
        }

        return await _repository.Inserir(colaborador);
    }

    public Task<bool> AtualizarColaborador(Colaborador colaborador)
    {
        return _repository.Atualizar(colaborador);
    }

    public async Task<bool> DeletarColaborador(int id)
    {
        return await  _repository.Deletar(id);
    }
}