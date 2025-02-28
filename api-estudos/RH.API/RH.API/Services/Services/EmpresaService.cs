using System.Data.SqlClient;
using RH.API.Domain;
using RH.API.Infra.Interfaces;
using RH.API.Services.Interface;

namespace RH.API.Services.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _repository;
        public EmpresaService(IEmpresaRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> AtualizarEmpresa(Empresa empresa)
        {
            return await _repository.AtualizarEmpresa(empresa);
        }

        public async Task<Empresa> BuscarEmpresaPorId(int id)
        {
            return await _repository.BuscarEmpresaPorId(id);
        }

        public async Task<List<Empresa>> BuscarTodasEmpresasAsync()
        {

                var empresas = await _repository.BuscarTodasEmpresasAsync();
                return empresas;

        }

        public async Task<bool> ExcluirEmpresa(int id)
        {
            return await _repository.ExcluirEmpresa(id);
        }

        public async Task<bool> InserirEmpresa(Empresa empresa)
        {
            return await _repository.InserirEmpresa(empresa);
        }
    }
}
