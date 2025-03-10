using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos.TestePOO;
using RH.API.Domain.Entities.TestePOO;
using RH.API.Services.Interface.TestePOO;

namespace RH.API.Controllers.TestePOO;


[Route("api/[controller]")]
[ApiController]
public class EstudanteController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IEstudanteService _service;

    public EstudanteController(IMapper mapper, IEstudanteService service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPost("adicionar")]
    public async Task<IActionResult> InserirEstudante([FromBody] CreateEstudanteDto estudanteDto)
    {
        try
        {
            Estudante estudante = _mapper.Map<Estudante>(estudanteDto);

            bool estudanteAdicionado = await _service.InserirEstudante(estudante);

            if (estudanteAdicionado)
                return StatusCode(201, new { message = "Estudante inserido com sucesso!" });
            else
                return BadRequest(new { message = "Erro ao inserir estudante!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao processar a solicitação!", error = ex.Message });
        }
    }

    [HttpGet("retornar")]
    public async Task<IActionResult> ExibirEstudantes()
    {
        try
        {
            var estudantes = await _service.BuscarTodosEstudantes();

            if (estudantes != null)
                return Ok(estudantes);

            return NotFound(new { message = "Não há registros de estudantes!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao processar a solicitação!", error = ex.Message });
        }
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> AtualizarEstudante([FromBody] Estudante estudante)
    {
        try
        {
            var resultadoAtualizacao = await _service.AtualizarMatricula(estudante);

            if (resultadoAtualizacao) return Ok($"Estudante atualizado com sucesso! \n {estudante}");
            else return BadRequest(new { message = "A matrícula informada não está registrada!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro ao processar a solicitação!", error = ex.Message });
        }
    }
}
