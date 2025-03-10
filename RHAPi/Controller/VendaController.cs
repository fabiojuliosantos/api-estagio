using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RHAPi.Infra.Dto;
using RHAPI.Domain;
using RHAPI.Infra.Dto;
using RHAPI.Service.Interfaces;

namespace RHAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class VendaController : ControllerBase
{
    private readonly IVendaService _service;

    public VendaController(IVendaService service)
    {
        _service = service;
    }

    [HttpPost("cria-produto")]
    public IActionResult CadastraProduto(CreateProdutoDto produtoDto)
    {
        try
        {
            Produto produto = _service.CadastraProduto(produtoDto);
            return Ok(produto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("lista-produto")]
    public IActionResult ConsultaProdutoEstoque(int id)
    {
        try
        {
            Produto produto = _service.ConsultaProdutoEmEstoque(id);
            return Ok(produto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("gera-relatorio")]
    public IActionResult GeraRelatorioVenda()
    {
        try
        {
            return Ok(_service.GeraRelatorioVenda());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("cria-venda")]
    public IActionResult CriaVenda(CreateVendaDto vendaDto)
    {
        try
        {
            Venda venda = _service.VendaProduto(vendaDto);
            return Ok(venda);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}