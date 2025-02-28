using Microsoft.AspNetCore.Mvc;
using rh.api.Domain;
using rh.api.Services.Interface;

namespace rh.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmpresasController : ControllerBase
{
    private readonly IEmpresaService _service;

    public EmpresasController(IEmpresaService service)
    {
        _service = service;
    }

    [HttpGet("buscar-paginado/{pagina}/{quantidade}")]


    public async Task<IActionResult> BuscarEmpresasPorPaginaAsync(int pagina, int quantidade)
    {
        try
        {
            var empresas = await _service.BuscarEmpresasPorPaginaAsync(pagina, quantidade);
           
            if (empresas == null)
            {
                return NotFound("Nenhuma empresa  localizada em nossa base de dados!");
            }

            else
            {
                return Ok(empresas);
            };
        }
        catch (Exception)
        {
            throw;
        }
    }


    [HttpGet("buscar-todas")]
    public async Task<IActionResult> BuscarTodas()
    {
        try
        {
            var empresas = await _service.BuscarTodasEmpresasAsync();
            if (empresas == null || !empresas.Any())
            {
                return NotFound("Nenhuma empresa não localizada!");
            }

            else 
            {
                return Ok(empresas);
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpGet("buscar-id/{id}")]    
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            var empresas = await _service.BuscarEmpresaPorId(id);

            if(empresas == null)
            {
                return NotFound($"Nenhuma empresa localizada com o id{id}.");
            }
            else 
            { 
                return Ok(empresas);
            }
            
        }
        catch (Exception)
        {
            throw;
        }
    } 
    [HttpPost("Inserir")]    
    public async Task<IActionResult> Inserir([FromBody] Empresa empresa)
    {
        try
        {
            var empresas = await _service.InserirEmpresa(empresa);
            return Ok(empresas);
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpPut("Atualizar")]    
    public async Task<IActionResult> Atualizar([FromBody] Empresa empresa)
    {
        try
        {
            var empresas = await _service.AtualizarEmpresa(empresa);
            return Ok(empresas);
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpDelete("Excluir/{id}")]    
    public async Task<IActionResult> Excluir(int id)
    {
        try
        {
            var empresas = await _service.ExcluirEmpresa(id);
            return Ok(empresas);
        }
        catch (Exception)
        {
            throw;
        }
    }
    
}
