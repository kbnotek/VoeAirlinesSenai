using VoeAirlinesSenai.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VoeAirlinesSenai.EntityConfigurantions;

public class CancelamentoConfiguration : IEntityTypeConfiguration<Cancelamento>
{
    public void Configure(EntityTypeBuilder<Cancelamento> builder)
    {   //PROPRIEDADE DE CANCELAMENTO 
        builder.ToTable("Cancelamentos");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Motivo)
        .IsRequired()
        .HasMaxLength(100);
        builder.Property(c => c.DataHoraNotificacao)
        .IsRequired();

    }
}