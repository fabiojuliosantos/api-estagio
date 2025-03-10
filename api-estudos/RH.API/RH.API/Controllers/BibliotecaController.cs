using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Dto;
using RH.API.Services.Interface;

namespace RH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private readonly IBibliotecaService _bibliotecaService;

        public BibliotecaController(IBibliotecaService bibliotecaService)
        {
            _bibliotecaService = bibliotecaService;
        }

        [HttpPost]
        public IActionResult CadastrarLivro([FromBody] BibliotecaDto livroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            try
            {
                // Mapeia o DTO para o modelo de domínio
                var livro = new Biblioteca
                {
                    Titulo = livroDto.Titulo,
                    Autor = livroDto.Autor,
                    AnoPublicacao = livroDto.AnoPublicacao,
                    CodigoDeBarras = livroDto.CodigoDeBarras
                };

                var (sucesso, mensagem) = _bibliotecaService.CadastrarLivro(livro);

                if (!sucesso)
                {
                    return BadRequest(mensagem);
                }

                return Ok(mensagem); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao cadastrar o livro: {ex.Message}");
            }
        }

        [HttpPost("emprestar/{codigoDeBarras}")]
        public IActionResult EmprestarLivro(int codigoDeBarras)
        {
            try
            {
                var (sucesso, mensagem) = _bibliotecaService.EmprestarLivro(codigoDeBarras);

                if (!sucesso)
                {
                    return BadRequest(mensagem);  
                }

                return Ok(mensagem); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao emprestar livro: {ex.Message}");
            }
        }

        [HttpPost("devolver/{codigoDeBarras}")]
        public IActionResult DevolverLivro(int codigoDeBarras)
        {
            try
            {
                var (sucesso, mensagem) = _bibliotecaService.DevolverLivro(codigoDeBarras);

                if (!sucesso)
                {
                    return BadRequest(mensagem);  
                }

                return Ok(mensagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao devolver livro: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult ListarLivros()
        {
            try
            {
                var (sucesso, mensagem, livros) = _bibliotecaService.ListarLivros();

                if (!sucesso || livros == null || !livros.Any())
                {
                    return NotFound("Nenhum livro cadastrado.");
                }

                return Ok(livros);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao listar livros: {ex.Message}");
            }
        }
    }
}
