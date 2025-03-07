using Microsoft.AspNetCore.Mvc;
using RH.API.Domain.Validators;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstudanteController : ControllerBase
{
    private readonly IEstudanteService _service;

    public EstudanteController(IEstudanteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        try
        {
            var Estudante = await _service.ListarAsync();
            return Ok(Estudante);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{matricula}")]
    public async Task<IActionResult> Listar(int matricula)
    {
        try
        {
            var Estudante = await _service.ListarAsync(matricula);
            return Ok(Estudante);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] CreateEstudanteDTO dto)
    {
        try
        {
            return Ok(await _service.InserirAsync<CreateEstudanteDTO, EstudanteDTO, EstudanteValidator>(dto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    public async Task<IActionResult> Atualizar([FromBody] EstudanteDTO dto)
    {
        try
        {
            return Ok(await _service.AtualizarAsync<EstudanteDTO, EstudanteDTO, EstudanteValidator>(dto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{matricula}")]
    public async Task<IActionResult> Excluir(int matricula)
    {
        try
        {
            return Ok(await _service.Excluir(matricula));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
