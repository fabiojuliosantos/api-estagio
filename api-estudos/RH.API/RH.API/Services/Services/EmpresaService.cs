using RH.API.Domain;
using RH.API.Infra.Interfaces;
using RH.API.Services.Interface;

namespace RH.API.Services.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaService _service;
        public EmpresaService(IEmpresaService service)
        {
            _service = service;
        }


        public Task<bool> AtualizarEmpresa(Empresa empresa)
        {
            throw new NotImplementedException();
        }

        public Task<Empresa> BuscarEmpresaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Empresa>> BuscarTodasEmpresasAsync()
        {
            try
            {
                var empresas = await _repository.BuscarTodasEmpresasAsync();
                return empresas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> ExcluirEmpresa(int id)
        {
            throw new NotImplementedException();
        }
        [HttpPost("Inserir")]
        public async Task<bool> InserirEmpresa(Empresa empresa)
        {
            throw new NotImplementedException();
        }
    }
}
