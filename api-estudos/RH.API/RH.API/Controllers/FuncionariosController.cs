using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Services.Interface;
using System;
using System.Collections.Generic;

namespace RH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioService _service;

        public FuncionariosController(IFuncionarioService service)
        {
            _service = service;
        }

        [HttpGet("listar")]
        public IActionResult ListarFuncionarios()
        {
            try
            {
                var funcionarios = _service.ListarFuncionarios();
                return Ok(funcionarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao buscar funcionários.");
            }
        }

        [HttpPost("adicionar")]
        public IActionResult AdicionarFuncionario([FromBody] Funcionario funcionario)
        {
            try
            {
                var resultado = _service.AdicionarFuncionario(funcionario);

                if (!resultado.Sucesso)
                {
                    return BadRequest(resultado.Mensagem);
                }

                return CreatedAtAction(nameof(AdicionarFuncionario), new { mensagem = resultado.Mensagem, funcionario });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao adicionar funcionário.");
            }
        }

        [HttpGet("media-salarial")]
        public IActionResult CalcularMediaSalarial()
        {
            try
            {
                var media = _service.CalcularMediaSalarial();

                if (double.IsNaN(media))
                {
                    return NotFound("Nenhum funcionário cadastrado para calcular a média salarial.");
                }

                return Ok(new { MediaSalarial = media });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao calcular média salarial.");
            }
        }
    }
}
