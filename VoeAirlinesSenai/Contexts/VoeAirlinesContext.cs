using Microsoft.EntityFrameworkCore;
using VoeAirlinesSenai.Entities;
namespace VoeAirlinesSenai.Contexts;

public class VoeAirlinesContext : DbContext
{
    public DbSet<Aeronave> Aeronaves => Set<Aeronave>();
    public DbSet<Manutencao> Manutencoes => Set<Manutencao>();
    public DbSet<Piloto> Pilotos =>Set<Piloto>();
    public DbSet<Voo> Voos =>Set<Voo>();
    public DbSet<Cancelamento> Cancelamentos => Set<Cancelamento>();
}
//private readonly IConfiguration _configuration;
//public VoeAirlinesContext(IConfiguration configuration){
//   _configuration = configuration;
//}