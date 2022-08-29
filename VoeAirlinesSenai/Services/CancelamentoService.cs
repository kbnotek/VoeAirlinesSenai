using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Services;
public class CancelamentoService
{
    private readonly VoeAirlinesContext _context;

    public CancelamentoService(VoeAirlinesContext context)
    {
        _context = context;
    }
    //Adicionar Cancelamento
    public DetalhesCancelamentoViewModel AdicionarCancelamento(AdicionarCancelamentoViewModel dados)
    {
        var cancelar = new Cancelamento(dados.Motivo, dados.DataHoraNotificacao, dados.VooId);
        _context.Add(cancelar);
        _context.SaveChanges();
        return new DetalhesCancelamentoViewModel
        (
            cancelar.Id,
            cancelar.Motivo,
            cancelar.DataHoraNotificacao,
            cancelar.VooId
        );
    }
    // ListarCancelamento
    public IEnumerable<ListarCancelamentoViewModel> ListarCancelamento()
    {
        return _context.Cancelamentos.Select(c => new ListarCancelamentoViewModel(c.Id, c.Motivo, c.DataHoraNotificacao));
    }
    //Listar Cancelamento pelo Id
    public DetalhesCancelamentoViewModel? ListarCancelamentoPeloId(int id)
    {
        var cancelamento = _context.Cancelamentos.Find(id);
        if (cancelamento != null)
        {
            return new DetalhesCancelamentoViewModel
            (
                cancelamento.Id,
                cancelamento.Motivo,
                cancelamento.DataHoraNotificacao,
                cancelamento.VooId
            );
        }
        return null;
    }
    //Atualizar Cancelamento
    public DetalhesCancelamentoViewModel? AtualizarCancelamento(AtualizarCancelamentoViewModel dados)
    {
        var cancelamento = _context.Cancelamentos.Find(dados.Id);
        if(cancelamento!= null)
        {
            cancelamento.Motivo = dados.Motivo;
            cancelamento.DataHoraNotificacao = dados.DataHoraNotificacao;
            cancelamento.VooId = dados.VooId;
            _context.Update(cancelamento);
            _context.SaveChanges();
        }
        return null;
    }
    //Deletar Cancelamento
    public void ExcluirCancelmanto(int id)
    {
        var cancelamento = _context.Cancelamentos.Find(id);
        if(cancelamento != null)
        {
            _context.Remove(cancelamento);
            _context.SaveChanges();
        }

    }
}