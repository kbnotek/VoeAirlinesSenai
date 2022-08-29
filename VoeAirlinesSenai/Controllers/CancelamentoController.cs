using Microsoft.AspNetCore.Mvc;
using VoeAirlinesSenai.Services;
using VoeAirlinesSenai.ViewModels;
[Route("api/cancelamentos")]
[ApiController]
public class CancelamentoController : ControllerBase
{
    private readonly CancelamentoService _cancelamentoService;

    public CancelamentoController(CancelamentoService cancelamentoService)
    {
        _cancelamentoService = cancelamentoService;
    }
    //Adicionar Cancelamento
    [HttpPost]
    public IActionResult AdicionarCancelamento(AdicionarCancelamentoViewModel dados)
    {
        var cancelar = _cancelamentoService.AdicionarCancelamento(dados);
        return Ok(cancelar);
    }
    //Listar Todos os cancelamentos
    [HttpGet]
    public IActionResult ListarTodosCancelamentos()
    {
        return Ok(_cancelamentoService.ListarCancelamento());
    }
    //Listar Pelo Id
    [HttpGet("{id}")]
    public IActionResult ListarCancelamentoPeloId(int id)
    {
        var cancelamentos = _cancelamentoService.ListarCancelamentoPeloId(id);
        if(cancelamentos!= null)
        {
            return Ok(cancelamentos);
        }
        return NotFound();
    }
    //Atualizar Cancelamento
    [HttpPut("{id}")]
    public IActionResult AtualizarCancelamento(int id, AtualizarCancelamentoViewModel dados)
    {
        if( id != dados.Id)
        {
            return BadRequest("o Id Informado na URL é Diferente do id Informado no Corpo da Requisição");
        }
        var cancelamento = _cancelamentoService.AtualizarCancelamento(dados);
        return Ok(cancelamento);
    }
    //Deletar Cancelamento
    [HttpDelete("{id}")]
    public IActionResult ExcluirCancelamento(int id)
    {
        _cancelamentoService.ExcluirCancelmanto(id);
        return NoContent();
    }
}