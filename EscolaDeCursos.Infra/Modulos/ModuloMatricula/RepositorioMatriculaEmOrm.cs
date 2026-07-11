using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModuloMatricula;

public sealed class RepositorioMatriculaEmOrm(EscolaDeCursosDbContext dbContext) :
    RepositorioBaseEmOrm<Matricula>(dbContext), IRepositorioMatricula
{
    public override Matricula? SelecionarPorId(Guid idSelecionado)
    {
        return registros
            .Include(m => m.Aluno)
            .SingleOrDefault(m => m.Id == idSelecionado);
    }

    public override List<Matricula> SelecionarTodos()
    {
        return registros
            .Include(m => m.Aluno)
            .ToList();
    }
}