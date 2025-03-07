using Microsoft.AspNetCore.Mvc;
using Biblioteca.Domain;
using Biblioteca.Services.Interface;

namespace Biblioteca.Controllers
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

        [HttpGet("livros")]
        public ActionResult<List<Livro>> ListarLivros()
        {
            return _bibliotecaService.ListarLivros();
        }

        [HttpPost("livros")]
        public ActionResult<Livro> CadastrarLivro([FromBody] LivroDto livroDto)
        {
            try
            {
                return _bibliotecaService.CadastrarLivro(livroDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("livros/emprestar/{id}")]
        public ActionResult<Livro> EmprestarLivro(int id)
        {
            try
            {
                return _bibliotecaService.EmprestarLivro(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("livros/devolver/{id}")]
        public ActionResult<Livro> DevolverLivro(int id)
        {
            try
            {
                return _bibliotecaService.DevolverLivro(id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}