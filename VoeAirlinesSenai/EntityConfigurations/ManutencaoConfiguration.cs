using VoeAirlinesSenai.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VoeAirlinesSenai.EntityConfigurantions;

public class ManutencaoConfiguration : IEntityTypeConfiguration<Manutencao>
{
    public void Configure(EntityTypeBuilder<Manutencao> builder)
    {   //PROPRIEDADES DE MANUTENÇÃO
        builder.ToTable("Manutencoes");
        builder.HasKey(m => m.Id); //- chame primaria 
        builder.Property(m => m.DataHora)
        .IsRequired();
        builder.Property(m => m.Tipo)
        .IsRequired();
        builder.Property(m => m.Observacoes)
        .HasMaxLength(100);

    }
}