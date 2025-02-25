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

    [HttpGet("buscar-todas")]
    public async Task<IActionResult> BuscarTodas()
    {
        try
        {
            var empresas = await _service.BuscarTodasEmpresasAsync();
            return Ok(empresas);
        }
        catch (Exception ex) { throw; }
    }

    [HttpGet("buscar-id/{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            var empresas = await _service.BuscarEmpresaPorIdAsync(id);
            return Ok(empresas);
        }
        catch (Exception ex) { throw; }
    }

    [HttpPost("inserir")]
    public async Task<IActionResult> Inserir([FromBody] Empresa empresa)
    {
        try
        {
            var empresas = await _service.InserirEmpresaAsync(empresa);
            return Ok(empresas);
        }
        catch (Exception ex) { throw; }
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar([FromBody] Empresa empresa)
    {
        try
        {
            var empresas = await _service.AtualizarEmpresaAsync(empresa);
            return Ok(empresas);
        }
        catch (Exception ex) { throw; }
    }

    [HttpDelete("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            var empresas = await _service.ExcluirEmpresaAsync(id);
            return Ok(empresas);
        }
        catch (Exception ex) { throw; }
    }
}
