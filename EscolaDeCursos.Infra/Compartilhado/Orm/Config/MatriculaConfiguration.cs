using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;

public sealed class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        builder.ToTable("TBMatricula");

        builder.HasKey(m => m.Id)
            .HasName("PK_TBMatricula");


        builder.Property(m => m.Id)
            .ValueGeneratedNever();


        builder.HasOne(m => m.Aluno)
            .WithMany()
            .HasForeignKey("AlunoId")
            .HasConstraintName("FK_TBMatricula_TBAluno")
            .OnDelete(DeleteBehavior.NoAction);


        builder.HasOne(m => m.Turma)
            .WithMany()
            .HasForeignKey("TurmaId")
            .HasConstraintName("FK_TBMatricula_TBTurma")
            .OnDelete(DeleteBehavior.NoAction);


        builder.Property(m => m.MatriculaId)
            .IsRequired();
    }
}