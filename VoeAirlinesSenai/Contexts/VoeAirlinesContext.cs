using Microsoft.EntityFrameworkCore;
using VoeAirlinesSenai.Entities;
namespace VoeAirlinesSenai.Contexts;

public class VoeAirlinesContext : DbContext
{ //============================================================================================
    //Conexão  somente para Leitura!
    private readonly IConfiguration _configuration;
    public VoeAirlinesContext(IConfiguration configuration)//Construtor !
    {
        _configuration = configuration;
    }
    //===========================================================================================     
    //DBContext -São o Banco !
    //DBSet - Tabela.  sinal de <> são Generic  formando DbSet<"Nome quer será tipado"> !
    public DbSet<Aeronave> Aeronaves => Set<Aeronave>();
    public DbSet<Manutencao> Manutencoes => Set<Manutencao>();
    public DbSet<Piloto> Pilotos => Set<Piloto>();
    public DbSet<Voo> Voos => Set<Voo>();
    public DbSet<Cancelamento> Cancelamentos => Set<Cancelamento>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("VoeAirlines"));
    }
}

