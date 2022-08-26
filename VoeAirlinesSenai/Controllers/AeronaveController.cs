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
    [HttpPost]// - POST - > INSERIR ! INSERT INTO
    public IActionResult AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {

        var aeronave = _aeronaveService.AdicionarAeronave(dados);
        return Ok(aeronave);

    }
    [HttpGet]// - Get - > RETORNO ! - SELECT * FROM
    public IActionResult ListarAeronaves()
    {
        return Ok(_aeronaveService.ListarAeronaves());
    }
    [HttpGet("{id}")] // - Get - Retorno com Paramentro - no caso Buscar pelo "Id" . 
    public IActionResult ListarAeronavePeloId(int id)
    {
        var aeronave = _aeronaveService.ListarAeronavePeloId(id);
        if (aeronave != null)
        {
            return Ok(aeronave);
        }
        return NotFound();
    }
    [HttpPut("{id}")] // - Put - O recurso que descreve o resultado da ação é transmitido uma Atualização pelo Id dentro do parâmentro- UPDATE
    public IActionResult AtualizarAeronave(int id, AtualizarAeronaveViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest(" o Id Informado na URL é Diferente do id Informado no Corpo da Requisição");
        }
        var aeronave = _aeronaveService.AtualizarAeronave(dados);
        return Ok(aeronave);
    }
    [HttpDelete("{id}")] // - Delete - exclui o recurso especificado pelo Id dentro do paramento
    public IActionResult ExcluirAeronave(int id)
    {
        _aeronaveService.ExcluirAeronave(id);
        return NoContent();
    }

}