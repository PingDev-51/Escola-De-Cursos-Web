using EscolaDeCursos.Dominio.Modulos.ModuloCursos;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModuloCurso;

public sealed class RepositorioCursoEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Curso>(dbContext), IRepositorioCurso
{
    public override Curso? SelecionarPorId(Guid idSelecionado)
    {
        return registros
            .Include(c => c.Modulo)
            .SingleOrDefault(c => c.Id == idSelecionado);
    }

    public override List<Curso> SelecionarTodos()
    {
        return registros
            .Include(c => c.Modulo)
            .ToList();
    }

    public override List<Curso> Filtrar(Func<Curso, bool> filtro)
    {
        return registros
            .Include(c => c.Modulo)
            .ToList();
    }
}