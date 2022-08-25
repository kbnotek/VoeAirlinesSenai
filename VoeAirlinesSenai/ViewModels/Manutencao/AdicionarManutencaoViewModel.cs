using VoeAirlinesSenai.Entities.Enums;

namespace VoeAirlinesSenai.ViewModels;
public class AdicionarManutencaoviewModel
{
    public AdicionarManutencaoviewModel(DateTime dataHora, string? observacoes, TipoManutencao tipo, int aeronaveId)
    {
        DataHora = dataHora;
        Observacoes = observacoes;
        Tipo = tipo;
        AeronaveId = aeronaveId;
    }

    public DateTime DataHora { get; set; }
    public string? Observacoes { get; set; }

    public TipoManutencao Tipo { get; set; } //struct do tipo - TipoManutenção  que conecta com a "//Enum\\".

    public int AeronaveId { get; set; }
}