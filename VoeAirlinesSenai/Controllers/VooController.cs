using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModels;
[Route("api/voos")]
[ApiController]
public class VooController : ControllerBase
{
    private readonly VooService _vooService;

    public VooController(VooService vooService)
    {
        _vooService = vooService;
    }
    //Adicionar Voo
    [HttpPost]
    public IActionResult AdicionarVoo(AdicionarVooViewModel dados)
    {
        var voo = _vooService.AdicionarVoo(dados);
        return Ok(voo);
    }
    // Listar voo
    [HttpGet]
    public IActionResult ListarVoos()
    {
        return Ok(_vooService.ListarVoos());
    }
    //Listar voo Pelo Id
    [HttpGet("{id}")]
    public IActionResult ListarVooPeloId(int id)
    {
        var voo = _vooService.ListarVooPeloId(id);
        if (voo != null)
        {
            return Ok(voo);
        }
        return NotFound();
    }
    //Atualizar Voo
    [HttpPut("{id}")]
    public IActionResult AtualizarVoo(int id, AtualizarVooViewModel dados)
    {
        if (id != dados.Id)
        {
            return BadRequest("o Id Informado na URL é Diferente do id Informado no Corpo da Requisição");
        }
        var voo = _vooService.AtualizarVoo(dados);
        return Ok(voo);
    }
    //Deletar Voo
    [HttpDelete("{id}")]
    public IActionResult ExcluirVoo(int id)
    {
        _vooService.ExcluirVoo(id);
        return NoContent();
    }
    // Gerar Ficar em PDF
    [HttpGet("ficha/{id}")]
    public IActionResult GerarFichaDoVoo(int id)
    {
        var conteudo = _vooService.GerarFichaDoVoo(id);

        if (conteudo != null)
            return File(conteudo, "application/pdf", "relatorio.pdf"); // Download ( swagger para PDF ("relatorio.pdf") 

        return NotFound();
    }

}