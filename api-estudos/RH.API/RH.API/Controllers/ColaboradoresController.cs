using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Dto;
using RH.API.Services.Interface;
using RH.API.Services.Services;

namespace RH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly IColaboradorService _service;
        private readonly IMapper _mapper;

        public ColaboradoresController(IColaboradorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
            try
            {
                var colaboradores = await _service.BuscarTodosColaboradores();

                var colaboradoresDto = _mapper.Map<List<ColaboradorGetDto>>(colaboradores);

                return Ok(colaboradoresDto); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Erro ao buscar colaboradores.", error = ex.Message });
            }
        }

        [HttpGet("buscar-id/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            try
            {
                var colaborador = await _service.BuscarColaboradorPorId(id);

                if (colaborador == null)
                {
                    return NotFound(new { message = "Colaborador não encontrado." });
                }

                var colaboradorDto = _mapper.Map<ColaboradorGetDto>(colaborador);

                return Ok(colaboradorDto); 
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Erro ao buscar colaborador.", error = "Erro desconhecido." });
            }
        }

        [HttpPost("inserir")]
        public async Task<IActionResult> Inserir([FromBody] ColaboradorDto colaboradorDTO)
        {
            try
            {
                var colaborador = new Colaborador
                {
                    Nome = colaboradorDTO.Nome,
                    Cpf = colaboradorDTO.Cpf,
                    Matricula = colaboradorDTO.Matricula,
                    EmpresaID = colaboradorDTO.EmpresaID
                };

                var erros = Validacoes.ValidarColaborador(colaborador);

                if (erros.Any())
                {
                    return BadRequest(new { mensagensDeErro = erros });
                }

                var sucesso = await _service.InserirColaborador(colaborador);

                if (!sucesso)
                {
                    return BadRequest(new { message = "Falha ao cadastrar colaborador." });
                }

                return CreatedAtAction(nameof(BuscarPorId), new { id = colaborador.ColaboradorID }, new { message = "Colaborador cadastrado com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Erro no servidor ao tentar cadastrar colaborador.", error = ex.Message });
            }
        }


        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] Colaborador colaborador)
        {
            try
            {
                var colaboradorAtualizado = await _service.AtualizarColaborador(colaborador);

                if (colaboradorAtualizado == null)
                {
                    return NotFound(new { message = "O colaborador não foi encontrado." });
                }

                return Ok(new { message = "Colaborador atualizado com sucesso.", colaborador = colaboradorAtualizado });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Erro ao atualizar colaborador.", error = ex.Message });
            }
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var colaboradorExcluido = await _service.ExcluirColaborador(id);

                if (colaboradorExcluido == null)
                {
                    return NotFound(new { message = "O colaborador não foi encontrado." });
                }

                return Ok(new { message = "Colaborador excluído com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Erro ao excluir colaborador.", error = ex.Message });
            }
        }
    }
}
