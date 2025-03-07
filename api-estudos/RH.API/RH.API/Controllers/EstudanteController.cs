using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;

namespace RH.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudanteController : ControllerBase
    {
        private static List<Estudante> estudantes = new List<Estudante>();

        [HttpPost]
        public ActionResult<Estudante> AdicionarEstudante([FromBody] Estudante estudante)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                // Adiciona estudante diretamente à lista
                estudantes.Add(estudante);

                return CreatedAtAction(nameof(ExibirEstudantes), new { matricula = estudante.Matricula }, estudante);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Estudante>> ExibirEstudantes()
        {
            try
            {
                return Ok(estudantes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPut("{matricula}")]
        public ActionResult AtualizarEstudante(int matricula, [FromBody] Estudante estudante)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var estudanteExistente = estudantes.FirstOrDefault(e => e.Matricula == matricula);
                if (estudanteExistente == null)
                    return NotFound("Estudante não encontrado.");

                // Atualiza diretamente os dados do estudante encontrado
                estudanteExistente.Nome = estudante.Nome;
                estudanteExistente.Idade = estudante.Idade;
                estudanteExistente.Curso = estudante.Curso;

                return Ok("Dados do estudante atualizados com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
