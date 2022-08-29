using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Services;
public class VooService
{
    private readonly VoeAirlinesContext _context;

    public VooService(VoeAirlinesContext context)
    {
        _context = context;
    }
    //Adicionar Voo
    public DetalhesVooViewModel AdicionarVoo(AdicionarVooViewModel dados)
    {
        var voo = new Voo(dados.Origem, dados.Destino, dados.DataHoraPartida, dados.DataHoraChegada, dados.AeronaveId, dados.PilotoId);
        _context.Add(voo);
        _context.SaveChanges();
        return new DetalhesVooViewModel
        (
            voo.Id,
            voo.Origem,
            voo.Destino,
            voo.DataHoraPartida,
            voo.DataHoraChegada,
            voo.AeronaveId,
            voo.PilotoId
        );
    }
    // Listar Todos voo
    public IEnumerable<ListarVooViewModel> ListarVoos()
    {
        return _context.Voos.Select(v => new ListarVooViewModel(v.Id, v.Origem, v.Destino, v.DataHoraPartida, v.DataHoraChegada));
    }
    //Listar Voo Pelo Id
    public DetalhesVooViewModel? ListarVooPeloId(int id)
    {
        var voo = _context.Voos.Find(id);
        if (voo != null)
        {
            return new DetalhesVooViewModel
            (
                voo.Id,
                voo.Origem,
                voo.Destino,
                voo.DataHoraPartida,
                voo.DataHoraChegada,
                voo.AeronaveId,
                voo.PilotoId
            );
        }
        return null;
    }
    //Atualizar Voo
    public DetalhesVooViewModel? AtualizarVoo(AtualizarVooViewModel dados)
    {
        var voo = _context.Voos.Find(dados.Id);
        if (voo != null)
        {
            voo.Origem = dados.Origem;
            voo.Destino= dados.Destino;
            voo.DataHoraPartida = dados.DataHoraPartida;
            voo.DataHoraChegada = dados.DataHoraChegada;
            voo.AeronaveId = dados.AeronaveId;
            voo.PilotoId = dados.PilotoId;
            _context.Update(voo);
            _context.SaveChanges();
        }
        return null;
    }
    //Deletar Voo
    public void ExcluirVoo(int id)
    {
        var voo = _context.Voos.Find(id);
        if(voo != null){
        _context.Remove(voo);
        _context.SaveChanges();
        }
    }

}