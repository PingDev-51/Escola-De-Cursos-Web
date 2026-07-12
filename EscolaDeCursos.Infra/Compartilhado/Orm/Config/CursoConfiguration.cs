using EscolaDeCursos.Dominio.Modulos.ModuloCursos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;


public sealed class CursoConfiguration : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable("TBCurso");

        builder.HasKey(c => c.Id)
            .HasName("PK_TBCurso");

        builder.Property(c => c.Id)
            .ValueGeneratedNever();

        builder.Property(c => c.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Nivel)
            .IsRequired();

        builder.Property(c => c.CargaHoraria)
            .IsRequired();


        builder.HasOne(c => c.Modulo)
            .WithMany()
            .HasForeignKey("ModuloId")
            .HasConstraintName("FK_TBCurso_TBModulo")
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.Categoria)
           .WithMany()
           .HasForeignKey("CategoriaId")
           .HasConstraintName("FK_TBCurso_TBCategoria")
           .OnDelete(DeleteBehavior.NoAction);
    }
}