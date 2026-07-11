using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;


public sealed class TurmaConfiguration : IEntityTypeConfiguration<Turma>
{
    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.ToTable("TBTurma");

        builder.HasKey(t => t.Id)
            .HasName("PK_TBTurma");

        builder.Property(f => f.Id)
            .ValueGeneratedNever();

        builder.Property(f => f.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(f => f.NumeroMaxDeAlunos)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.DataInicio)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(c => c.DataTermino)
           .HasColumnType("date")
           .IsRequired();


        builder.HasOne(c => c.Curso)
            .WithMany()
            .HasForeignKey("CursoId")
            .HasConstraintName("FK__TBTurma_TBCurso")
            .OnDelete(DeleteBehavior.NoAction);

        
        builder.HasOne(c => c.Instrutor)
            .WithMany()
            .HasForeignKey("InstrutorId")
            .HasConstraintName("FK__TBTurma_TBInstrutor")
            .OnDelete(DeleteBehavior.NoAction);
    }
}
