using Microsoft.AspNetCore.Mvc;
using RH.API.Domain.Validators;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioService _service;

    public FuncionarioController(IFuncionarioService service)
    {
        _service = service;
    }

    [HttpGet("media-salarial")]
    public async Task<IActionResult> CalcularMediaSalarial()
    {
        try
        {
            return Ok(_service.CalcularMediaSalarial());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        try
        {
            var Funcionario = await _service.ListarAsync();
            return Ok(Funcionario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Listar(int id)
    {
        try
        {
            var Funcionario = await _service.ListarAsync(id);
            return Ok(Funcionario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] CreateFuncionarioDTO dto)
    {
        try
        {
            return Ok(await _service.InserirAsync<CreateFuncionarioDTO, FuncionarioDTO, FuncionarioValidator>(dto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    public async Task<IActionResult> Atualizar([FromBody] FuncionarioDTO dto)
    {
        try
        {
            return Ok(await _service.AtualizarAsync<FuncionarioDTO, FuncionarioDTO, FuncionarioValidator>(dto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            return Ok(await _service.Excluir(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
