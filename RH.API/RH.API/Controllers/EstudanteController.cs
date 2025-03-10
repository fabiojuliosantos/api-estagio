using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstudanteController : ControllerBase
{
    private readonly IEstudanteService _estudanteService;

    public EstudanteController(IEstudanteService estudanteService)
    {
        _estudanteService = estudanteService;
    }

    [HttpGet("listar-todos")]
    public ActionResult<IEnumerable<EstudanteDTO>> ListarEstudantes()
    {
        try
        {
            var estudantes = _estudanteService.ListarEstudantes();
            return Ok(estudantes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao listar estudantes: {ex.Message}");
        }
    }

    [HttpGet("buscar-por-matricula/{matricula}")]
    public ActionResult<EstudanteDTO> BuscarEstudantePorMatricula (string matricula)
    {
        try
        {
            var estudante = _estudanteService.BuscarEstudantePorMatricula(matricula);
            if (estudante == null)
            {
                return NotFound("Estudante nao encontrado");
            }
            return Ok(estudante);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao listar estudantes: {ex.Message}");
        }
    }

    [HttpPost("inserir")]
    public ActionResult<EstudanteDTO> AdicionarEstudante([FromBody] EstudanteDTO estudanteDTO)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var novoEstudante = _estudanteService.AdicionarEstudante(estudanteDTO);
            return CreatedAtAction(nameof(BuscarEstudantePorMatricula),
                new { matricula = novoEstudante.Matricula }, novoEstudante);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao inserir estudante: {ex.Message}");
        }
    }

    [HttpPut("atualizar-matricula/{matriculaAntiga}")]
    public IActionResult AtualizarMatricula(string matriculaAntiga, [FromBody] string matriculaNova)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_estudanteService.AtualizarMatricula(matriculaAntiga, matriculaNova))
            {
                return NotFound("Matrícula não encontrada para atualizar");
            }
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao atualizar matrícula: {ex.Message}");
        }
    }

    [HttpDelete("remover/{matricula}")]
    public IActionResult RemoverEstudante(string matricula)
    {
        try
        {
            if (!_estudanteService.RemoverEstudante(matricula))
            {
                return NotFound("matricula nao encontrada");
            }
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao remover matricula: {ex.Message}");
        }
    }
}
