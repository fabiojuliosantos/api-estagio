using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivrosController : ControllerBase
{
    private readonly ILivroService _service;

    public LivrosController(ILivroService service)
    {
        _service = service;
    }

    [HttpPost("CadastrarLivro")]
    public async Task<IActionResult> CadastrarLivro([FromBody] Livro livro)
    {
        try
        {
            var resposta = _service.CadastrarLivro(livro);
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
    [HttpPost("EmprestarLivro")]
    public async Task<IActionResult> EmprestarLivro(int codigoBarras)
    {
        try
        {
            var resposta = _service.EmprestaLivro(codigoBarras);
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
    [HttpPost("DevolveLivro")]
    public async Task<IActionResult> DevolveLivro(int codigoBarras)
    {
        try
        {
            var resposta = _service.DevolveLivros(codigoBarras);
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
    [HttpGet("Exibir livros")]

    public async Task<IActionResult> ExibirLivros()
    {
        try
        {
            var resposta = _service.ListarLivros();
            return Ok(resposta);
        }
        catch (Exception)
        {
            throw;
        }


    }
}
