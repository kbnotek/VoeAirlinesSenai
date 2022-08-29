using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModels;
[Route("api/pilotos")]
[ApiController]
public class PilotoController : ControllerBase
{
private readonly PilotoService _pilotoService;

    public PilotoController(PilotoService pilotoService)
    {
        _pilotoService = pilotoService;
    }
    //Adicionar Piloto
    [HttpPost]
    public IActionResult AdicionarPiloto(AdicionarPilotoViewModel dados)
    {
        var piloto = _pilotoService.AdicionarPiloto(dados);
        return Ok(piloto);

    }
    //Listar Todos os  Pilotos
    [HttpGet]
    public IActionResult ListarPilotos()
    {
        return Ok(_pilotoService.ListarPilotos());
    }
    // Buscar Piloto Pelo Id
    [HttpGet("{id}")]
    public IActionResult BuscarPilotoPeloId(int id)
    {
        var piloto = _pilotoService.ListarPilotoPeloId(id);
        if(piloto != null)
        {
            return Ok(piloto);
        }
        return NotFound();
    }
    //Atualizar Piloto
    [HttpPut("{id}")]
    public IActionResult AtualizarPiloto(int id, AtualizarPilotoViewModel dados)
    {
        if(id != dados.Id)
        {
            return BadRequest("o Id Informado na URL é Diferente do id Informado no Corpo da Requisição");
        }
        var piloto = _pilotoService.AtualizarPiloto(dados);
        return Ok(piloto);
    }
    //Deletar Piloto
    [HttpDelete("{id}")]
    public IActionResult ExcluirPiloto(int id)
    {
        _pilotoService.ExcluirPiloto(id);
        return NoContent();
    }

}