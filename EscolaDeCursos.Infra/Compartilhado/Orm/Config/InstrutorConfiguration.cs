using EscolaDeCursos.Dominio.Modulos.ModuloCursos;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;


public sealed class InstrutorConfiguration : IEntityTypeConfiguration<Instrutor>
{
    public void Configure(EntityTypeBuilder<Instrutor> builder)
    {
        builder.ToTable("TBInstrutor");

        builder.HasKey(i => i.Id)
            .HasName("PK_TBInstruto");

        builder.Property(i => i.Id)
            .ValueGeneratedNever();

        builder.Property(i => i.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(i => i.Email)
                .HasMaxLength(255)
                .IsRequired();

        builder.Property(i => i.Telefone)
          .HasMaxLength(20)
          .IsRequired();

        builder.Property(i => i.Graduacao)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(i => i.Email)
       .IsUnique()
       .HasDatabaseName("UQ_TBInstrutores_Email");

        builder.HasIndex(i => i.Telefone)
            .IsUnique()
            .HasDatabaseName("UQ_TBInstrutores_Telefone");
    }
}
