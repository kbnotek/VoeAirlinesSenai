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
}