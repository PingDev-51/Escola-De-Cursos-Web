using EscolaDeCursos.Dominio.Modulos.ModuloModulosCurso;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModulosCurso;

public sealed class RepositorioModuloEmOrm(EscolaDeCursosDbContext dbContext)
    : IRepositorioModulo
{
    public void Cadastrar(Modulo entidade)
    {
        dbContext.Modulos.Add(entidade);

        dbContext.SaveChanges();
    }

    public bool Editar(Guid idSelecionado, Modulo entidadeAtualizada)
    {
        Modulo? moduloSelecionado = SelecionarPorId(idSelecionado);


        if (moduloSelecionado == null)
            return false;

        moduloSelecionado.Atualizar(entidadeAtualizada);

        dbContext.SaveChanges();

        return true;
    }

    public bool Excluir(Guid idSelecionado)
    {
        Modulo? moduloSelecionado = SelecionarPorId(idSelecionado);

        if (moduloSelecionado == null)
            return false;

        dbContext.Modulos.Remove(moduloSelecionado);

        dbContext.SaveChanges();

        return true;
    }

    public List<Modulo> Filtrar(Func<Modulo, bool> filtro)
    {
        return dbContext.Modulos.Where(filtro).ToList();
    }

    public Modulo? SelecionarPorId(Guid idSelecionado)
    {
        return dbContext.Modulos.SingleOrDefault(m => m.Id == idSelecionado);

    }

    public List<Modulo> SelecionarTodos()
    {
        return dbContext.Modulos.OrderBy(m => m.Nome).ToList();
    }
}