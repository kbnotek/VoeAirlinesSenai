using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModels;
//A Controller é uma Classe, Porém, que permite trabalhar especificamente  com  HTTP
//Uma Classe 
//Herança no C# - ":"
//URL - Endereço  - Caminho 
// Rota é trecho - Sub Caminho 
//Anotations ou Anotações
[Route("api/aeronaves")]//Essa é a Anotations,
//O Controle pode trabalhar com
//AspNet MVC ou API ou Outros Recursos Web.
[ApiController]
public class AeronaveController : ControllerBase //Pesquise na documentação ControllerBase
{

    private readonly AeronaveService _aeronaveService;

    public AeronaveController(AeronaveService aeronaveService)
    {
        _aeronaveService = aeronaveService;
    }
    [HttpPost]
    public IActionResult AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {

        var aeronave = _aeronaveService.AdicionarAeronave(dados);
        return Ok(aeronave);

    }
}