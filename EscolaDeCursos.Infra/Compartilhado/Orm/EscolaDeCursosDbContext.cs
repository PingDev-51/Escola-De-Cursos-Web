using System.Reflection;
using Microsoft.EntityFrameworkCore;
using EscolaDeCursos.Dominio.Modulos.ModuloModulosCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloCursos;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutores;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;

namespace EscolaDeCursos.Infra.Compartilhado.Orm;

public sealed class EscolaDeCursosDbContext(
    DbContextOptions<EscolaDeCursosDbContext> options)
    : DbContext(options)
{
    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Modulo> Modulos => Set<Modulo>();
    public DbSet<Aluno> Alunos => Set<Aluno>();
    public DbSet<Instrutor> Instrutor => Set<Instrutor>();
    public DbSet<Categoria> Categoria => Set<Categoria>();
    public DbSet<Matricula> Matricula => Set<Matricula>();
    public DbSet<Turma> Turma => Set<Turma>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Assembly assembly = typeof(EscolaDeCursosDbContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(modelBuilder);
    }
}