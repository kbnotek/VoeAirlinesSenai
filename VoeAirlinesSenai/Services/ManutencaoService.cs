using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Services;

public class ManutencaoService
{
    private readonly VoeAirlinesContext _context;

    public ManutencaoService(VoeAirlinesContext context)
    {
        _context = context;
    }
    //Adicionar Manutencão!
    public DetalhesManutencaoViewModel AdicionarManutencao(AdicionarManutencaoviewModel dados)
    {
        var manutencao = new Manutencao(dados.DataHora, dados.Tipo, dados.AeronaveId, dados.Observacoes);
        _context.Add(manutencao);
        _context.SaveChanges();
        return new DetalhesManutencaoViewModel
        (
            manutencao.Id,
            manutencao.DataHora,
            manutencao.Observacoes,
            manutencao.Tipo,
            manutencao.AeronaveId

        );
    }
    // Listar Manutenções 
    public IEnumerable<ListarManutencaoViewModel> ListarManutencoes()
    {
        return _context.Manutencoes.Select(m => new ListarManutencaoViewModel(m.Id, m.DataHora, m.Observacoes, m.Tipo));
    }
    //Listar pelo ID
    public DetalhesManutencaoViewModel? ListarManutencaoPeloId(int id)
    {
        var Manutencao = _context.Manutencoes.Find(id);
        if (Manutencao != null)
        {
            return new DetalhesManutencaoViewModel
            (
                Manutencao.Id,
                Manutencao.DataHora,
                Manutencao.Observacoes,
                Manutencao.Tipo,
                Manutencao.AeronaveId
            );
        }
        return null;
    }
    //Listar Manutencao Aeronave 
    public IEnumerable<ListarManutencaoViewModel> ManutencaoDaAeronave(int AeronaveId)
    {
        return _context.Manutencoes.Where(m=>m.AeronaveId == AeronaveId).Select(m=> new ListarManutencaoViewModel(m.Id,m.DataHora,m.Observacoes,m.Tipo));
    }
    //Atualizar Manutencao
    public DetalhesManutencaoViewModel? AtualizarManutecao(AtualizarManutencaoViewModel dados)
    {
        var manutencao = _context.Manutencoes.Find(dados.Id);
        if(manutencao != null)
        {
            manutencao.DataHora = dados.DataHora;
            manutencao.Observacoes = dados.Observacoes;
            manutencao.Tipo = dados.Tipo;
            manutencao.AeronaveId = dados.AeronaveId;
            _context.Update(manutencao);
            _context.SaveChanges();
        }
        return null;
    }
    //Deletar Manutencão 
    public void ExcluirManutencao(int id)
    {
        var manutencao = _context.Manutencoes.Find(id);
        if(manutencao != null)
        {
            _context.Remove(manutencao);
            _context.SaveChanges();
        }      
    }
}