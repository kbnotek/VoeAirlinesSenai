using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Services;

public class PilotoService
{
    private readonly VoeAirlinesContext _context;

    public PilotoService(VoeAirlinesContext context)
    {
        _context = context;
    }
    //Adicionar Piloto
    public DetalhesPilotoViewModel AdicionarPiloto(AdicionarPilotoViewModel dados)
    {
        var piloto = new Piloto(dados.Nome, dados.Matricula);
        _context.Add(piloto);
        _context.SaveChanges();

        return new DetalhesPilotoViewModel
        (
            piloto.Id,
            piloto.Nome,
            piloto.Matricula
        );
    }
    //Lista Piloto
    public IEnumerable<ListarPilotoViewModel> ListarPilotos()
    {
        return _context.Pilotos.Select(p => new ListarPilotoViewModel(p.Id, p.Nome));
    }
    //Buscar pelo ID 
    public DetalhesPilotoViewModel? ListarPilotoPeloId(int id)
    {
        var piloto = _context.Pilotos.Find(id);
        if (piloto != null)
        {
            return new DetalhesPilotoViewModel
            (
                piloto.Id,
                piloto.Matricula,
                piloto.Nome
            );
        }
        return null;
    }
    //Atualizar Piloto
    public DetalhesPilotoViewModel? AtualizarPiloto(AtualizarPilotoViewModel dados)
    {
        var piloto = _context.Pilotos.Find(dados.Id);
        if(piloto!=null)
        {
            piloto.Nome = dados.Nome;
            piloto.Matricula = dados.Matricula;
            _context.Update(piloto);
            _context.SaveChanges();
            return new DetalhesPilotoViewModel(piloto.Id,piloto.Matricula,piloto.Nome);
        }return null;
    }
    //Deletar Piloto
    public void ExcluirPiloto(int id)
    {
        var piloto = _context.Pilotos.Find(id);
        if(piloto != null)
        {
            _context.Remove(piloto);
            _context.SaveChanges();
        }
    }
}