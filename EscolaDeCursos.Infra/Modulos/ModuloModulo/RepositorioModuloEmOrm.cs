using EscolaDeCursos.Dominio.Modulos.ModuloModulosCurso;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModulosCurso;

public sealed class RepositorioModuloEmOrm(EscolaDeCursosDbContext dbContext)
: RepositorioBaseEmOrm<Modulo>(dbContext), IRepositorioModulo
{
}