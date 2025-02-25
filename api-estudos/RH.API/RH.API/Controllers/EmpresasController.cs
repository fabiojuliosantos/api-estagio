using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.API.Services.Interface;

namespace RH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaService _service;
        public EmpresasController(IEmpresaService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> BuscarTodas()
        {
            try
            {
                var empresas = await _service.BuscarTodasEmpresasAsync();
                return Ok(empresas);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
