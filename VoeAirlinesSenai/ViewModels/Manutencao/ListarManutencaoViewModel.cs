using VoeAirlinesSenai.Entities.Enums;

namespace VoeAirlinesSenai.ViewModels;
public class ListarManutencaoViewModel
{
    public ListarManutencaoViewModel(int id, DateTime dataHora, string? observacoes, TipoManutencao tipo)
    {
        Id = id;
        DataHora = dataHora;
        Observacoes = observacoes;
        Tipo = tipo;
    }

    public int Id { get; set; }

    public DateTime DataHora { get; set; }
    public string? Observacoes { get; set; }

    public TipoManutencao Tipo { get; set; } //struct do tipo - TipoManutenção  que conecta com a "//Enum\\".


}