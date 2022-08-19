using VoeAirlinesSenai.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VoeAirlinesSenai.EntityConfigurantions;

public class AeronaveConfiguration : IEntityTypeConfiguration<Aeronave>
{
    public void Configure(EntityTypeBuilder<Aeronave> builder)
    {
        builder.ToTable("Aeronaves"); // Selecionar o nome da Tabela
        builder.HasKey(a => a.Id); // Selecionar uma Lambda a para aeronave com lambda a. (Id)  --- chave primaria !
        builder.Property(a => a.Fabricante) // Propriedade  do Fabricante ...
        .IsRequired() //- Requerimento 
        .HasMaxLength(50); // Tamanho do caractere .
        builder.Property(a => a.Modelo)
        .IsRequired()
        .HasMaxLength(50);
        builder.Property(a => a.Codigo)
        .IsRequired()
        .HasMaxLength(10);
        //=================================================================================================================
        //Agora é Sério ... Relacionamento.
        //Many One
        builder.HasMany(a => a.Manutencoes)
        .WithOne(m => m.Aeronave)
        .HasForeignKey(m => m.AeronaveId); //chave estrangeira 
    }
}