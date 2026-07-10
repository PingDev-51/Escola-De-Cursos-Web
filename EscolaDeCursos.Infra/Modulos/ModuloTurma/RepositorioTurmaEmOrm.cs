using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModuloTurma;

public sealed class RepositorioTurmaEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Turma>(dbContext), IRepositorioTurma
{
    public override Turma? SelecionarPorId(Guid idSelecionado)
    {
        return registros
            .Include(t => t.Curso)
            .Include(t => t.Instrutor)
            .SingleOrDefault(t => t.Id == idSelecionado);
    }

    public override List<Turma> SelecionarTodos()
    {
        return registros
            .Include(t => t.Curso)
            .Include(t => t.Instrutor)
            .ToList();
    }
}