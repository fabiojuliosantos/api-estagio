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
            if (empresas == null || !empresas.Any())
            {
                return NotFound("Não foi possível localizar nenhuma empresa.");
            }
            else
            {
                return Ok(empresas);
            }
        }
        catch (Exception ex) { throw; }
    }

    [HttpGet("buscar-id/{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            var empresas = await _service.BuscarEmpresaPorIdAsync(id);
            if (empresas == null)
            {
                return NotFound($"Não foi possível localizar a empresa com id {id}.");
            }
            else
            {
                return Ok(empresas);
            }
        }
        catch (Exception ex) { throw; }
    }

    [HttpPost("inserir")]
    public async Task<IActionResult> Inserir([FromBody] Empresa empresa)
    {
        try
        {
            var sucesso = await _service.InserirEmpresaAsync(empresa);
            if (sucesso)
            {
                return CreatedAtAction(nameof(BuscarPorId), new { id = empresa.EmpresaID }, empresa);
            }
            else 
            {
                return BadRequest("Não foi possível inserir a empresa.");
            }
        }
        catch (Exception ex) { throw; }
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar([FromBody] Empresa empresa)
    {
        try
        {
            var sucesso = await _service.AtualizarEmpresaAsync(empresa);
            if (sucesso)
            {
                return Ok("Empresa Atualizada com sucesso!");
            }
            else
            {
                return BadRequest("Não foi possível atualizar a empresa.");
            }
        }
        catch (Exception ex) { throw; }
    }

    [HttpDelete("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            var sucesso = await _service.ExcluirEmpresaAsync(id);
            if (sucesso)
            {
            return Ok("Empresa deletada com sucesso!");
            }
            else
            {
                return BadRequest("Não foi possível deletar a empresa.");
            }
        }
        catch (Exception ex) { throw; }
    }
}
