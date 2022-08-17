using VoeAirlinesSenai.Entities.Enums;

namespace VoeAirlinesSenai.Entities;
public class Manutencao
{
    public Manutencao(DateTime dataHora, TipoManutencao tipo, int aeronaveId, string? observacoes = null)
    {
        DataHora = dataHora;
        Observacoes = observacoes;
        Tipo = tipo;
        AeronaveId = aeronaveId;
    }

    public int Id { get; set; }

    public DateTime DataHora { get; set; }
    public string? Observacoes { get; set; }

    public TipoManutencao Tipo { get; set; } //struct do tipo - TipoManutenção  que conecta com a "//Enum\\".

    public int AeronaveId { get; set; }

    public Aeronave Aeronave { get; set; } = null!;
}