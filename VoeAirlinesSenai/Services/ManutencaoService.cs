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
}