using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Dto;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivroController : Controller
{
    private readonly ILivroService _service;
    private readonly IMapper _mapper;

    public LivroController(ILivroService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("buscar-livros")]
    public IActionResult ExibirLivros()
    {
        try
        {
            var livros = _service.ListarLivros();
            return Ok(livros);
        }
        catch (Exception e) { throw; }
    }

    [HttpPost("adicionar-livro")]
    public IActionResult AdicionarLivro([FromBody] CreateLivroDto livroDto)
    {
        try
        {
            var livro = _mapper.Map<Livro>(livroDto);
            var resposta = _service.AdicionarLivro(livro);
            return Ok(resposta);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("emprestar-livro")]
    public IActionResult EmprestarLivro([FromQuery] int codigoDeBarras)
    {
        try
        {
            _service.EmprestarLivro(codigoDeBarras);
            return Ok("Livro emprestado com sucesso!");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPut("devolver-livro")]
    public IActionResult DevolverLivro([FromQuery] int codigoDeBarras)
    {
        try
        {
            _service.DevolverLivro(codigoDeBarras);
            return Ok("Livro devolvido!");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
