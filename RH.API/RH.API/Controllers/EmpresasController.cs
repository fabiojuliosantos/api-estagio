using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos;
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
            var empresas = await _service.BuscarEmpresaPorId(id);
            return Ok(empresas);
        }
        catch (Exception)
        {
            throw;
        }
    } 
    [HttpPost("Inserir")]    
    public async Task<IActionResult> Inserir([FromBody] EmpresaDto empresaDto)
    {
        try
        {
            var respostaDTO = await _service.InserirEmpresa(empresaDto);
            return respostaDTO.Sucesso ? Ok(respostaDTO) : BadRequest(respostaDTO);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }
    }
    [HttpPut("Atualizar")]    
    public async Task<IActionResult> Atualizar( [FromBody] AtualizarEmpresaDto empresaDto)
    {
        try
        {
            var respostaDTO = await _service.AtualizarEmpresa(empresaDto);

            return respostaDTO.Sucesso ? Ok(respostaDTO) : BadRequest(respostaDTO);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }
    }
    [HttpDelete("Excluir/{id}")]    
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            if (id <= 0)
                return BadRequest(new RespostaDTO(false, "ID inválido"));

            var respostaDTO = await _service.ExcluirEmpresa(id);
            return respostaDTO.Sucesso ? Ok(respostaDTO) : NotFound(respostaDTO);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }
    }
    
}
