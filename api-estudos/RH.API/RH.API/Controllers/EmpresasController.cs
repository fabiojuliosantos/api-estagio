using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmpresasController : ControllerBase
{
    private readonly IEmpresaService _service;

    public EmpresasController(IEmpresaService service)
    {
        _service = service;
    }

    [HttpGet("buscar-paginado/{pagina}/{quantidade}")]
    public async Task<IActionResult> BuscarEmpresasPorPagina(int pagina, int quantidade)
    {
        try
        {
            var empresas = await _service.BuscarEmpresasPorPaginaAsync(pagina, quantidade);
            if (empresas == null) return NotFound("Não foram encontradas empresas na base de dados.");

            if (empresas.Empresas == null || !empresas.Empresas.Any())
            {
                return NotFound("Não foram encontradas empresas para esta página.");
            }
            return Ok(empresas);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    [HttpGet("buscar-todas")]
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
    [HttpGet("buscar-id/{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            var empresa = await _service.BuscarEmpresaPorId(id);

            if (empresa == null)
            {
                return NotFound(new { message = "Empresa não encontrada." });
            }

            return Ok(empresa);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPost("Inserir")]
    public async Task<IActionResult> Inserir([FromBody] Empresa empresa)
    {
        try
        {
            var empresas = await _service.InserirEmpresa(empresa);
            return Ok(empresas);
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpPut("Atualizar")]
    public async Task<IActionResult> Atualizar([FromBody] Empresa empresa)
    {
        try
        {
            var empresas = await _service.AtualizarEmpresa(empresa);
            return Ok(empresas);
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpDelete("Excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            var empresas = await _service.ExcluirEmpresa(id);
            return Ok(empresas);
        }
        catch (Exception)
        {
            throw;
        }
    }

}