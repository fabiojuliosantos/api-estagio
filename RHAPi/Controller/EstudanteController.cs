using Microsoft.AspNetCore.Mvc;
using RHAPI.Infra.Dto;
using RHAPI.Service.Interfaces;

namespace RHAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class EstudanteController : ControllerBase
{
    private readonly IEstudanteService _service;

    public EstudanteController(IEstudanteService service)
    {
        _service = service;
    }

    [HttpPost("inserir")]
    public IActionResult InserirEstudante(CreateEstudanteDto createEstudanteDto)
    {
        try
        {
            var estudante = _service.AdicionarEstudante(createEstudanteDto);
            return Ok(estudante);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("atualizar-estudante")]
    public IActionResult AtualizarEstudante(UpdateEstudanteDto updateEstudanteDto)
    {
        try
        {
            var estudante = _service.AtualizarMatriculaEstudante(updateEstudanteDto);
            return Ok(estudante);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("listar-estudante")]
    public IActionResult ListarEstudante()
    {
        try
        {
            return Ok(_service.ListarEstudante());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}