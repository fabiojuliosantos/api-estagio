using Microsoft.AspNetCore.Mvc;
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
}
