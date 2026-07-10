using System;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutores;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Modulos.ModuloInstrutores;

public class RepositorioInstrutoresEmOrm(EscolaDeCursosDbContext dbContext)
: RepositorioBaseEmOrm<Instrutor>(dbContext), IRepositorioInstrutores;
