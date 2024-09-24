using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class AtendimentoConfiguration :IEntityTypeConfiguration<Atendimento> 
{
    public void Configure(EntityTypeBuilder<Atendimento> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Paciente)
            .WithMany(p => p.Atendimentos)
            .HasForeignKey(a => a.PacienteId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.Triagem)
            .WithOne(t => t.Atendimento)
            .HasForeignKey<Triagem>(t => t.AtendimentoId);

        builder.Property(a => a.NumeroSequencial)
            .ValueGeneratedOnAdd();
    }
}