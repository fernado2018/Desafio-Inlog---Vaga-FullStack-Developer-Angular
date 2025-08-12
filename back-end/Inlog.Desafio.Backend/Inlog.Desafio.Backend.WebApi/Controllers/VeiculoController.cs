using AutoMapper;
using Inlog.Desafio.Backend.Application.Interfaces;
using Inlog.Desafio.Backend.Domain.Excecao;
using Inlog.Desafio.Backend.Domain.Models.Utils;
using Inlog.Desafio.Backend.Domain.Models.Veiculo;
using Inlog.Desafio.Backend.WebApi.Models.Veiculo;
using Inlog.Desafio.Backend.WebApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Inlog.Desafio.Backend.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VeiculoController : ControllerBase
{
    private readonly ILogger<VeiculoController> _logger;
    private readonly IVeiculoService _service;
    private readonly IMapper _mapper;

    private readonly ErrorContext _errorContext;


    public VeiculoController(ILogger<VeiculoController> logger, IVeiculoService service, IMapper mapper, ErrorContext errorContext)
    {
        _logger = logger;
        _service = service;
        _mapper = mapper;
        _errorContext = errorContext;

    }

    [HttpPost("Cadastrar")]
    public async Task<IActionResult> Cadastrar([FromBody] CriarVeiculoBindingModel dadosDoVeiculo)
    {
        
        var IdVeiculo = await _service.Criar(_mapper.Map<Veiculo>(dadosDoVeiculo));
        var erro = _errorContext.MensagemErro;
        if (IdVeiculo > 0) return Ok(new { mensagem = "Veículo cadastrado com sucesso." });

        return NotFound(erro);
    }

    [HttpGet("Listar")]
    public async Task<IActionResult> ListarVeiculosAsync([FromQuery] BuscaTodosVeiculosInputBindingModel buscaTodosVeiculos)
    {
       var listaDeVeiculo = await _service.BuscarTodosOsVeiculoPaginados(buscaTodosVeiculos.Filtro,
                                                                    buscaTodosVeiculos.OrderBy,
                                                                    buscaTodosVeiculos.OrderDesc,
                                                                    buscaTodosVeiculos.Page,
                                                                    buscaTodosVeiculos.PageSize);

        if (listaDeVeiculo.Results.Count > 0)
        {
            var resultVeiculo = _mapper.Map<List<BuscaTodosVeiculosOutputBindingModel>>(listaDeVeiculo.Results);

            var pagedResult = new PagedOutput<BuscaTodosVeiculosOutputBindingModel>

            {
                CurrentPage = listaDeVeiculo.CurrentPage,
                PageCount = listaDeVeiculo.PageCount,
                PageSize = listaDeVeiculo.PageSize,
                RowCount = listaDeVeiculo.RowCount,
                Results = resultVeiculo
            };

            return Ok(pagedResult);
        }
        
       
        return NotFound(new { mensagem = "Nenhum registro encontrado." });
    }
}

