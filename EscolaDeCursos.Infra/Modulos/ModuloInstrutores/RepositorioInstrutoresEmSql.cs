using System;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutores;

namespace EscolaDeCursos.Infra.Modulos.ModuloInstrutores;

public class RepositorioInstrutoresEmSql : IRepositorioInstrutores
{
    public void Cadastrar(Instrutores entidade)
    {
        throw new NotImplementedException();
    }

    public bool Editar(Guid idSelecionado, Instrutores entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public bool Excluir(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Instrutores> Filtrar(Func<Instrutores, bool> filtro)
    {
        throw new NotImplementedException();
    }

    public Instrutores? SelecionarPorId(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Instrutores> SelecionarTodos()
    {
        throw new NotImplementedException();
    }
}
