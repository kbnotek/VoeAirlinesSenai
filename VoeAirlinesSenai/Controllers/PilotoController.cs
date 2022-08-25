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
    [HttpPost]
    public IActionResult AdicionarPiloto(AdicionarPilotoViewModel dados)
    {
        var piloto = _pilotoService.AdicionarPiloto(dados);
        return Ok(piloto);

    }
}