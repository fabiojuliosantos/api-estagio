using Microsoft.AspNetCore.Mvc;
using RH.API.Data.Dtos.TestePOO;
using RH.API.Domain.Validators;
using RH.API.Services.Interface.TestePOO;

namespace RH.API.Controllers.TestePOO;

[Route("api/[controller]")]
[ApiController]
public class Produto2Controller : ControllerBase
{
    private readonly IProduto2Service _service;

    public Produto2Controller(IProduto2Service service)
    {
        _service = service;
    }

    [HttpGet("consultar-estoque")]
    public async Task<IActionResult> ConsultarEstoque()
    {
        try
        {
            var Produtos = await _service.ConsultarEstoque();
            return Ok(Produtos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("relatorio-vendas")]
    public async Task<IActionResult> RelatorioVendas()
    {
        try
        {
            var Vendas = await _service.RelatorioVendas();
            return Ok(Vendas);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar([FromBody] CreateProduto2DTO dto)
    {
        try
        {
            return Ok(await _service.Cadastrar<CreateProduto2DTO, Produto2DTO, Produto2Validator>(dto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("vender")]
    public async Task<IActionResult> Vender(int id, int quantidade)
    {
        try
        {
            Task<bool> resultadoVenda = _service.Vender(id, quantidade);

            if (resultadoVenda == Task.FromResult(true))
                return Ok("Venda processada com sucesso!");
            else
                throw new Exception("Não foi possível processar a venda!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
