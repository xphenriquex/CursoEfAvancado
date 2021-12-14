using CursoEfAvancado.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEfAvancado.Configuration
{
    public class DocumentoConfiguration : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
             builder.Property("_cpf").HasColumnName("CPF").HasMaxLength(11);
                //.HasField("_cpf");
        }
    }
}