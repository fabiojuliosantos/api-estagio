// APENAS EXIBIR

using Microsoft.AspNetCore.Http;
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

    [HttpGet("retornar")]
    public async Task<IActionResult> BuscarTodas()
    {
        try
        {
            var empresas = await _service.BuscarTodasEmpresasAsync();
            return Ok(empresas);
        }
        catch (Exception ex) { throw; }
    }
    

    [HttpGet("retornar/{id}")]
    public async Task<IActionResult> BuscarPorId(int id) // Utilizar FromQUery quando for parametros opcionais
    {
        try
        {
            var empresas = await _service.BuscarEmpresaPorId(id);
            return Ok(empresas);
        }
        catch (Exception ex) { throw; }
    }

    [HttpPost("inserir")]
    public async Task<IActionResult> InserirEmpresa([FromBody] Empresa empresa)
    {
        try
        {
            var empresas = await _service.InserirEmpresa(empresa);
            return Ok(empresas);
        }
        catch (Exception ex) { throw; }
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> AtualizarEmpresa([FromBody] Empresa empresa)
    {
        try
        {
            var empresas = await _service.AtualizarEmpresa(empresa);
            return Ok(empresas);
        }
        catch (Exception ex) { throw; }
    }

    [HttpDelete("excluir/{id}")]
    public async Task<IActionResult> ExcluirEmpresa(int id)
    {
        try
        {
            var empresas = await _service.ExcluirEmpresa(id);
            return Ok(empresas);
        }
        catch (Exception ex) { throw; }
    }
}
