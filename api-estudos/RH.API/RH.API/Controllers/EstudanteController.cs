using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Services.Interface;

[ApiController]
[Route("api/[controller]")]
public class EstudanteController : ControllerBase
{
    private readonly IEstudanteService _estudanteService;

    public EstudanteController(IEstudanteService estudanteService)
    {
        _estudanteService = estudanteService;
    }

    [HttpPost]
    public ActionResult AdicionarEstudante([FromBody] Estudante estudante)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = _estudanteService.AdicionarEstudante(estudante);
            if (!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);

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
            var resultado = _estudanteService.ListarEstudantes();
            return Ok(resultado.Estudantes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    [HttpPut("{matricula}")]
    public ActionResult AtualizarEstudante(int matricula, [FromBody] EstudantePutDto estudante)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = _estudanteService.AtualizarEstudante(matricula, estudante);
            if (!resultado.Sucesso)
                return NotFound(resultado.Mensagem);

            return Ok(resultado.Mensagem);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }
}
