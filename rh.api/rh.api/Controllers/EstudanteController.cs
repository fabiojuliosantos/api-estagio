using Microsoft.AspNetCore.Mvc;
using rh.api.Domain;
using rh.api.Services.Interface;

namespace rh.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudanteController : ControllerBase
    {
        private readonly IEstudanteService _estudanteService;

        public EstudanteController(IEstudanteService estudanteService)
        {
            _estudanteService = estudanteService;
        }

        [HttpGet("buscar-todos")]
        public ActionResult<List<Estudante>> ListarEstudantes()
        {
            return _estudanteService.ListarEstudantes();
        }

        [HttpPost]
        public ActionResult<Estudante> AdicionarEstudante([FromBody] EstudanteDto estudanteDto)
        {
            try
            {
                return _estudanteService.AdicionarEstudante(estudanteDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("atualizar-id/{id}")]
        public ActionResult<Estudante> AtualizarEstudante(int id, [FromBody] EstudanteDto estudanteAtualizado)
        {
            try
            {
                return _estudanteService.AtualizarEstudante(id, estudanteAtualizado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
