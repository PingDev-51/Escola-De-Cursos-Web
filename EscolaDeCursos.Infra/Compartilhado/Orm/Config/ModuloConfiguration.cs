
using EscolaDeCursos.Dominio.Modulos.ModuloModulosCurso;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;

public sealed class ModuloCofiguration : IEntityTypeConfiguration<Modulo>
{
    public void Configure(EntityTypeBuilder<Modulo> builder)
    {
        builder.ToTable("TBModulos");

        builder.HasKey(c => c.Id)
            .HasName("PK_TBModulos");

        builder.Property(c => c.Id)
            .ValueGeneratedNever();

        builder.Property(c => c.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Duracao)
          .HasMaxLength(100)
          .IsRequired();
    }
}