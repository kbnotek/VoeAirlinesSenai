namespace ListarCancelamentoViewModel.Cancelamento.ViewModels;
public class ListarCancelamentoViewModel
{
    public ListarCancelamentoViewModel(int id, string motivo, DateTime dataHoraNotificacao)
    {
        Id = id;
        Motivo = motivo;
        DataHoraNotificacao = dataHoraNotificacao;
    }
    public int Id { get; set; }
    public string Motivo { get; set; }
    public DateTime DataHoraNotificacao { get; set; }

}