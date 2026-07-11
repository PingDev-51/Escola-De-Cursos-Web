using System;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Modulos.ModuloCategoria;

public class RepositorioCategoriaEmOrm(EscolaDeCursosDbContext dbContext)
: RepositorioBaseEmOrm<Categoria>(dbContext), IRepositorioCategoria;
