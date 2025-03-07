using Microsoft.AspNetCore.Mvc;
using RH.API.Domain;
using RH.API.Dto;
using RH.API.Services.Interface;
using System;
using System.Collections.Generic;

namespace RH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost("adicionar-aluno")]
        public IActionResult AdicionarAluno([FromBody] Aluno aluno)
        {
            try
            {
                var resultado = _alunoService.AdicionarAluno(aluno);
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

        [HttpPut("atualizar-matricula/{matricula}")]
        public IActionResult AtualizarMatricula(int matricula, [FromBody] UpdateAlunoDto alunoDto)
        {
            try
            {
                var resultado = _alunoService.AtualizarMatricula(matricula, alunoDto);
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

        [HttpGet("listar-alunos")]
        public IActionResult ListarAlunos()
        {
            try
            {
                List<Aluno> alunos = _alunoService.ListarAlunos();
                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex.Message}");
            }
        }
    }
}
