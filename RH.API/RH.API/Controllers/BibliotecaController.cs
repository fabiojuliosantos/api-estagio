using Microsoft.AspNetCore.Mvc;
using RH.API.DTOs;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BibliotecaController : ControllerBase
{
    private readonly IBibliotecaService _bibliotecaService;

    public BibliotecaController(IBibliotecaService bibliotecaService)
    {
        _bibliotecaService = bibliotecaService;
    }

    [HttpGet("listar-todos")]
    public ActionResult<IEnumerable<LivroDTO>> ListarLivros()
    {
        try
        {
            var livros = _bibliotecaService.ListarLivros();
            return Ok(livros);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao listar livros: {ex.Message}");
        }
    }

    [HttpGet("buscar-por-cod-barras/{codigoBarras}")]
    public ActionResult<LivroDTO> BuscarLivroPorCodigoBarras(string codigoBarras)
    {
        try
        {
            var livro = _bibliotecaService.BuscarLivroPorCodigoBarras(codigoBarras);
            if (livro == null)
            {
                return NotFound("Livro nao encontrado");
            }
            return Ok(livro);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao buscar cod.Barras: {ex.Message}");
        }
    }

    [HttpPost("adicionar")]
    public ActionResult<LivroDTO> AdicionarLivro([FromBody] LivroDTO livroDTO)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var livro = _bibliotecaService.AdicionarLivro(livroDTO);
            return Ok(livro);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao adicionar livro: {ex.Message}");
        }
    }

    [HttpPut("emprestar/{codigoBarras}")]
    public IActionResult EmprestarLivro(string codigoBarras)
    {
        try
        {
            if (_bibliotecaService.EmprestarLivro(codigoBarras))
            {
                return Ok();
            }
            return BadRequest("nao foi possivel emprestar o livro");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao emprestar livro: {ex.Message}");
        }
    }

    [HttpPut("devolver/{codigoBarras}")]
    public IActionResult DevolverLivro(string codigoBarras)
    {
        try
        {
            if (_bibliotecaService.DevolverLivro(codigoBarras))
            {
                return Ok();
            }
            return BadRequest("Nao foi possivel devolver o livro");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao devolver o livro: {ex.Message}");
        }
    }

    [HttpDelete("remover/{codigoBarras}")]
    public IActionResult RemoverLivro(string codigoBarras)
    {
        try
        {
            if (_bibliotecaService.RemoverLivro(codigoBarras))
            {
                return Ok();
            }
            return NotFound("Livro nao encontrado");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao remover livro: {ex.Message}");
        }
    }
}
