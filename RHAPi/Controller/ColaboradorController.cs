using Microsoft.AspNetCore.Mvc;
using RHAPi.Domain;
using RHAPI.Infra.Dto;
using RHAPI.Service.Interfaces;
using RHAPI.Utils;

namespace RHAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class ColaboradorController : ControllerBase
{
    private readonly IColaboradorService _service;

    public ColaboradorController(IColaboradorService service)
    {
        _service = service;
    }


    [HttpGet("buscar-paginado/{pagina}/{quantidade}")]
    public async Task<IActionResult> BuscarEmpresasPaginadas(int pagina, int quantidade)
    {
        try
        {
            var Colaboradores = await _service.BuscarColaboradorPorPagina(pagina, quantidade);
            
            if (Colaboradores == null) return NotFound("Não foram encontradas empresas");
            
            return Ok(Colaboradores);
        }
        catch (Exception)
        {
           throw;
        }
    }

    [HttpGet("buscar-colaboradores")]
    public async Task<IActionResult> BuscarTodos()
    {
        try
        {
            var colaboradores = await _service.BucarTodosColaboradores();
            return Ok(colaboradores);
        }
        catch (Exception ex) 
        {            
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("buscar-colarborador/{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            var colaborador = await _service.BucarColaboradorPorId(id);
            return Ok(colaborador);
        }
        catch (CustomerException ce) 
        {
            return NotFound(ce.Message);
        }
        catch (Exception ex) 
        { 
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("inserir-colaborador")]
    public async Task<IActionResult> Inserir(CreateColaboradorDto colaborador)
    {
        try
        {
            var colaboradorInserido = await _service.InserirColaborador(colaborador);
            return Ok(colaboradorInserido);
        }
        catch (Exception ex) 
        {            
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("atualiza-colaborador")]
    public async Task<IActionResult> Atualizar(Colaborador colaborador)
    {
        try
        {
            var colaboradorAtualizado = await _service.AtualizarColaborador(colaborador);
            return Ok(colaboradorAtualizado);
        }
        catch (Exception ex) 
        {            
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        try
        {
            var colaboradorDeletado = await _service.DeletarColaborador(id);
            return Ok(colaboradorDeletado);
        }
        catch (Exception ex) 
        {            
            return BadRequest(ex.Message);
        }
    }
}