using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModels;
[Route("api/manutencoes")]
[ApiController]
public class ManutencaoController : ControllerBase
{
    private readonly ManutencaoService _manutencaoService;

    public ManutencaoController(ManutencaoService manutencaoService)
    {
        _manutencaoService = manutencaoService;
    }


    //Adicionar Manutencao
    [HttpPost]
    public IActionResult AdicionarManutencao(AdicionarManutencaoviewModel dados)
    {
        var manutencao = _manutencaoService.AdicionarManutencao(dados);
        return Ok(manutencao);
    }
    //Listar Manutencao
    [HttpGet]
    public IActionResult ListarManutencao()
    {
        return Ok(_manutencaoService.ListarManutencoes());
    }
    // Buscar Pelo ID
    [HttpGet("{id}")]
    public IActionResult BuscarManutencaoPeloId(int id)
    {
        var manutencao = _manutencaoService.ListarManutencaoPeloId(id);
        if(manutencao!= null)
        {
            return Ok(manutencao);
        }
        return NotFound();
    }
    //Buscar Manutencao pelo Id da Aeronave
    [HttpGet("PelaNave/{aeronaveId}")]
    public IActionResult ManutencaoDaAeronave(int aeronaveId)
    {
        var manutencaoAeronave = _manutencaoService.ManutencaoDaAeronave(aeronaveId);
       if(manutencaoAeronave != null)
       {
        return Ok(manutencaoAeronave);
       }
       return NotFound();
    }
    // Atualizar Manutenção
    [HttpPut("{id}")]
    public IActionResult AtualizarManutencao(int id, AtualizarManutencaoViewModel dados)
    {
        if(id != dados.Id)
        {
            return BadRequest("o Id Informado na URL é Diferente do id Informado no Corpo da Requisição");
        }
        var manutencao = _manutencaoService.AtualizarManutecao(dados);
        return Ok(manutencao);
    }
    //Deletar Manutenção
    [HttpDelete("{id}")]
    public IActionResult ExcluirManutencao(int id)
    {
        _manutencaoService.ExcluirManutencao(id);
        return NoContent();
    }
}