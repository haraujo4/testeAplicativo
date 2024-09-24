using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class TriagemConfiguration: IEntityTypeConfiguration<Triagem>
{
    public void Configure(EntityTypeBuilder<Triagem> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasOne(t => t.Atendimento)
            .WithOne(a => a.Triagem)
            .HasForeignKey<Triagem>(t => t.AtendimentoId);
        builder.Property(t => t.Peso)
            .HasColumnType("decimal(10, 2)");
    }
}