using CursoEfAvancado.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEfAvancado.Configuration
{
    public class AtorFilmeConfiguration : IEntityTypeConfiguration<Ator>
    {
        public void Configure(EntityTypeBuilder<Ator> builder)
        {
            builder
                .HasMany(p=>p.Filmes)
                .WithMany(p=>p.Atores)
                .UsingEntity(p=>p.ToTable("AtoresFilmes"));
        }
    }
}