using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;


public sealed class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        builder.ToTable("TBMatricula");

        builder.HasKey(t => t.Id)
            .HasName("PK_TBMatricula");

        builder.Property(f => f.Id)
            .ValueGeneratedNever();

        builder.HasKey(t => t.MatriculaId)
            .HasName("PK_TBMatriculaId");

        builder.Property(f => f.MatriculaId)
            .ValueGeneratedNever();

        builder.HasOne(c => c.Aluno)
            .WithMany()
            .HasForeignKey("AlunoId")
            .HasConstraintName("FK__TBMatricula_TBAluno")
            .OnDelete(DeleteBehavior.NoAction);
    
    }
}
