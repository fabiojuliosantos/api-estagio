using Microsoft.AspNetCore.Mvc;
using RHAPI.Infra.Dto;
using RHAPI.Service.Interfaces;

namespace RHAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class LivroController : ControllerBase
{
    private readonly ILivroService _livroService;

    public LivroController(ILivroService livroService)
    {
        _livroService = livroService;
    }

    [HttpPost("cadastrar-livro")]
    public IActionResult CadastrarLivro(CreateLivroDto livroDto)
    {
        try
        {
            var livro = _livroService.CadastraLivro(livroDto);
            return Ok(livro);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("devolver-livro")]
    public IActionResult DevolverLivro(string codigoDeBarra)
    {
        try
        {
            var livro = _livroService.DevolveLivro(codigoDeBarra);
            return Ok(livro);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("emprestar-livro")]
    public IActionResult EmprestarLivro(string codigoDeBarra)
    {
        try
        {
            var livro = _livroService.EmprestaLivro(codigoDeBarra);
            return Ok(livro);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("listar-livros")]
    public IActionResult ListarLivros()
    {
        try
        {
            return Ok(_livroService.ListaLivros());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}