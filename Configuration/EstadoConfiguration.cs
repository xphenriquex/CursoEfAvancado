using CursoEfAvancado.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEfAvancado.Configuration
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Estado> builder)
        {
            builder.HasOne(p => p.Governador)
            .WithOne(p => p.Estado)
            .HasForeignKey<Governador>(p => p.EstadoReference);

            builder.Navigation(p => p.Governador).AutoInclude();
        }
    }
}