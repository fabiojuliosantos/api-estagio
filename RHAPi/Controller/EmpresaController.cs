using Microsoft.AspNetCore.Mvc;
using RHAPi.Domain;
using RHAPi.Service.Interfaces;

namespace RHAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly IEmpresaService _service;

    public EmpresaController(IEmpresaService service)
    {
        _service = service;
    }

    [HttpGet("buscar-todas")]
    public async Task<IActionResult> BuscarTodos()
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
            var empresa = await _service.BuscarEmpresaPorID(id);
            return Ok(empresa);
        }
        catch (Exception)
        {
           throw;
        }
    }

    [HttpPost("inserir")]
    public async Task<IActionResult> Inserir(Empresa empresa)
    {
        try
        {
            var empresaInserida = await _service.InserirEmpresa(empresa);
            return Ok(empresaInserida);
        }
        catch (Exception)
        {
           throw;
        }
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Atualizar(Empresa empresa)
    {
        try
        {
            var empresaAtualizada = await _service.AtualizarEmpresa(empresa);
            return Ok(empresaAtualizada);
        }
        catch (Exception) { throw; }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        try
        {
            var empresaDeletado = await _service.DeletarEmpresa(id);
            return Ok(empresaDeletado);
        }
        catch (Exception) { throw; }
    }
}