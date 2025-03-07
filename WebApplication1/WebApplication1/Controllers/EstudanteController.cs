
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Dto;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstudanteController : Controller
{
    private readonly IEstudanteService _service;
    private readonly IMapper _mapper;

    public EstudanteController(IEstudanteService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("buscar-estudantes")]
    public IActionResult ExibirEstudantes()
    {
        try
        {
            var estudantes = _service.ListarEstudantes();
            return Ok(estudantes);
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }

    [HttpPost("adicionar-estudante")]
    public IActionResult AdicionarEstudante([FromBody] EstudanteDto estudanteDto)
    {
        try
        {
            var estudante = _mapper.Map<Estudante>(estudanteDto);
            var resposta = _service.AdicionarEstudante(estudante);
            return Ok(resposta);
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }
    [HttpPut("atualizar-estudante")]
    public IActionResult AtualizarEstudante([FromBody] EstudanteDto estudanteDto)
    {
        try
        {
            var estudante = _mapper.Map<Estudante>(estudanteDto);
            var resposta = _service.AtualizarEstudante(estudante);
            return Ok(resposta);
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }
}
