using VoeAirlinesSenai.Entities.Enums;

namespace AdicionarCancelamentoViewModel.Cancelamento.ViewModels;
public class AdicionarCancelamentoViewModel
{
    public AdicionarCancelamentoViewModel(DateTime dataHora, string? observacoes, TipoManutencao tipo, int aeronaveId)
    {
        DataHora = dataHora;
        Observacoes = observacoes;
        Tipo = tipo;
        AeronaveId = aeronaveId;
    }
    public DateTime DataHora { get; set; }
    public string? Observacoes { get; set; }
    public TipoManutencao Tipo { get; set; }
    public int AeronaveId { get; set; }
}