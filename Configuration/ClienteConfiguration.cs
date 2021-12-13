using CursoEfAvancado.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEfAvancado.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.OwnsOne(x => x.Endereco, end => 
            {
                end.Property(p => p.Bairro).HasColumnName("Bairro");
                end.ToTable("Enderecos");
            });
        }
    }
}