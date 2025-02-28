using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos;
using RH.API.Domain;
using RH.API.Services.Interface;

namespace RH.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmpresasController : ControllerBase
{
    private readonly IEmpresaService _service;

    public EmpresasController(IEmpresaService service)
    {
        _service = service;
    }

    #region Buscar todas

    [HttpGet("buscar-todas")]
    public async Task<IActionResult> BuscarTodas()
    {
        try
        {
            var empresas = await _service.BuscarTodasEmpresasAsync();
            return Ok(empresas);
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion

    #region buscar por id
    [HttpGet("buscar-id/{id}")]    
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            var empresas = await _service.BuscarEmpresaPorId(id);
            return Ok(empresas);
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion

    #region Inserir
    [HttpPost("Inserir")]    
    public async Task<IActionResult> Inserir([FromBody] EmpresaDto empresaDto)
    {
        try
        {
            var respostaDTO = await _service.InserirEmpresa(empresaDto);
            return respostaDTO.Sucesso ? Ok(respostaDTO) : BadRequest(respostaDTO);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }
    }

    #endregion

    #region atualizar
    [HttpPut("Atualizar")]    
    public async Task<IActionResult> Atualizar( [FromBody] AtualizarEmpresaDto empresaDto)
    {
        try
        {
            var respostaDTO = await _service.AtualizarEmpresa(empresaDto);

            return respostaDTO.Sucesso ? Ok(respostaDTO) : BadRequest(respostaDTO);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }
    }
    #endregion

    #region excluir
    [HttpDelete("Excluir/{id}")]    
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            if (id <= 0)
                return BadRequest(new RespostaDTO(false, "ID inválido"));

            var respostaDTO = await _service.ExcluirEmpresa(id);
            return respostaDTO.Sucesso ? Ok(respostaDTO) : NotFound(respostaDTO);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new RespostaDTO(false, $"Erro interno: {ex.Message}"));
        }
    }
    #endregion

    #region Buscar por pagina
    [HttpGet("Buscar-pagina/{pagina}/{quantidade}")]

    public async Task<IActionResult> BuscarPorPagina(int pagina, int quantidade)
    {
        try
        {
            int limiteMaximo = 50; 

            
            if (pagina < 1)
            {
                return BadRequest("O número da página deve ser maior que 0.");
            }

            if (quantidade < 1 || quantidade > limiteMaximo)
            {
                return BadRequest($"A quantidade por página deve estar entre 1 e {limiteMaximo}.");
            }

            var empresas = await _service.BuscarEmpresaPorPagina(pagina, quantidade);

            if (empresas is null) return NotFound("Não foram encontrados empresas");






            return Ok(empresas);
        }catch(Exception) { throw; }
    }

    #endregion



}
