using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos;
using RH.API.Domain;
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

    [HttpPost("Adicionar-Estudante")]

    public async Task<IActionResult> AdicionarEstudante([FromBody] AdicionarEstudanteDto estudanteDto)
    {

        try
        {
            var resposta = _service.AdicionarEstudante(estudanteDto);
            if (!resposta.Sucesso)
            {
                return BadRequest(resposta);
            }

            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }

    }

    [HttpPut("Atualizar-Estudante")]

    public async Task<IActionResult> AtualizarEstudante(int matricula, Estudante estudante)
    {

        try
        {
            var resposta = _service.AtualizarMatriculaEstudante(matricula, estudante);
            if (!resposta.Sucesso)
            {
                return BadRequest(resposta);
            }

            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }



    }
    [HttpGet("Exibir Alunos")]

    public async Task<IActionResult> ExibirAlunos()
    {
        try
        {
            var estudantes = _service.ExibirEstudantes();
            return Ok(estudantes);
        }
        catch (Exception)
        {
            throw;
        }


    }
}
