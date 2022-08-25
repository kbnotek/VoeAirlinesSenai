using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModels;
[Route("api/manutencoes")]
[ApiController]
public class ManutencaoController : ControllerBase
{
private readonly ManutencaoService _pilotoService;

    public ManutencaoController(ManutencaoService pilotoService)
    {
        _pilotoService = pilotoService;
    }
    [HttpPost]
    public IActionResult AdicionarManutencao(AdicionarManutencaoviewModel dados)
    {
        var manutencao = _pilotoService.AdicionarManutencao(dados);
        return Ok(manutencao);
    }
}