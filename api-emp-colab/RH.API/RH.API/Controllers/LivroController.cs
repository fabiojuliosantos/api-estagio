using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpPost("adicionar-livro")]
        public IActionResult AdicionarLivro([FromBody] Livro livro)
        {
            try
            {
                var resultado = _livroService.AdicionarLivro(livro);
                if (resultado.Sucesso)
                {
                    return Ok(resultado.Mensagem);
                }
                return BadRequest(resultado.Mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
            }
        }

        [HttpPost("emprestar-livro/{id}")]
        public IActionResult EmprestarLivro(int id)
        {
            try
            {
                var resultado = _livroService.EmprestarLivro(id);
                if (resultado.Sucesso)
                {
                    return Ok(resultado.Mensagem);
                }
                return BadRequest(resultado.Mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
            }
        }

        [HttpPost("devolver-livro/{id}")]
        public IActionResult DevolverLivro(int id)
        {
            try
            {
                var resultado = _livroService.DevolverLivro(id);
                if (resultado.Sucesso)
                {
                    return Ok(resultado.Mensagem);
                }
                return BadRequest(resultado.Mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
            }
        }

        [HttpGet("listar-livros")]
        public IActionResult ListarLivros()
        {
            try
            {
                List<Livro> livros = _livroService.ListarLivros();
                return Ok(livros);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
            }
        }
    }
}
