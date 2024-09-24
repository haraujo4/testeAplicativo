using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class EspecialidadeConfiguration:IEntityTypeConfiguration<Especialidade>
{
    public void Configure(EntityTypeBuilder<Especialidade> builder)
    {
        
        builder.HasData(
            new Especialidade
            {
                Id = Guid.NewGuid(),
                TipoEspecialidade = "CARDIOLOGIA",
            },
            new Especialidade
            {
                Id = Guid.NewGuid(),
                TipoEspecialidade = "ORTOPEDIA",
            },
            new Especialidade
            {
                Id = Guid.NewGuid(),
                TipoEspecialidade = "PEDIATRIA",
            },
            new Especialidade
            {
                Id = Guid.NewGuid(),
                TipoEspecialidade = "NEUROLOGIA",
            },
            new Especialidade
            {
                Id = Guid.NewGuid(),
                TipoEspecialidade = "GINECOLOGIA",
            }
        );
    }
}