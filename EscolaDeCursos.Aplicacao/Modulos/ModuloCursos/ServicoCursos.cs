using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCursos;
using EscolaDeCursos.Dominio.Modulos.ModuloModulosCurso;
using EscolaDeCursos.Infra.Modulos.ModuloCategoria;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCursos;

public class ServicoCurso : ServicoBase<Curso>
{
    private readonly IRepositorioCurso repositorioCurso;
    private readonly IRepositorioModulo repositorioModulo;
    private readonly IRepositorioCategoria repositorioCategoria;

    public ServicoCurso(
        IRepositorioCurso repositorioCurso,
        IRepositorioModulo repositorioModulo,
        IRepositorioCategoria repositorioCategoria
    )
    {
        this.repositorioCurso = repositorioCurso;
        this.repositorioModulo = repositorioModulo;
        this.repositorioCategoria = repositorioCategoria;
    }

    public Result Cadastrar(CadastrarCursosDto dto)
    {
        Modulo? moduloSelecionado = repositorioModulo.SelecionarPorId(dto.ModuloId);

        if (moduloSelecionado == null)
            return Falha(nameof(dto.ModuloId), "Selecione um modulo valido.");

        Categoria? categoriaSelecionada = repositorioCategoria.SelecionarPorId(dto.CategoriaId);

        if (moduloSelecionado == null)
            return Falha(nameof(dto.CategoriaId), "Selecione uma categoria valida.");

        Curso novoCurso = new Curso(
            dto.Nome,
            dto.Nivel,
            dto.CargaHoraria,
            moduloSelecionado,
            categoriaSelecionada
        );

        Result resultadoValidacao = ValidarEntidade(novoCurso);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioCurso.Cadastrar(novoCurso);

        return Result.Ok();
    }

    public Result Editar(EditarCursosDto dto)
    {
        Modulo? moduloSelecionado = repositorioModulo.SelecionarPorId(dto.ModuloId);
        Categoria? categoriaSelecionada = repositorioCategoria.SelecionarPorId(dto.CategoriaId);

        Curso cursoAtualizado = new Curso(
                dto.Nome,
                dto.Nivel,
                dto.CargaHoraria,
                moduloSelecionado,
                categoriaSelecionada
            );

        Result resultadoValidacao = ValidarEntidade(cursoAtualizado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioCurso.Editar(dto.Id, cursoAtualizado);

        if (!conseguiuEditar)
            return Falha(string.Empty, "Curso não encontrado.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Curso? Curso = repositorioCurso.SelecionarPorId(id);

        if (Curso == null)
            return Falha(string.Empty, "Curso não encontrado.");

        repositorioCurso.Excluir(id);

        return Result.Ok();
    }

    public List<ListarCursosDto> SelecionarTodos()
    {
        return repositorioCurso
            .SelecionarTodos()
            .Select(c => new ListarCursosDto(
                c.Id,
                c.Nome,
                c.Nivel,
                c.CargaHoraria,
                c.Modulo.Id,
                c.Modulo?.Nome,
                c.Categoria.Id,
                c.Categoria.Nome
            ))
            .ToList();
    }

    public Result<DetalhesCursosDto> SelecionarPorId(Guid id)
    {
        Curso? Curso = repositorioCurso.SelecionarPorId(id);

        if (Curso == null)
            return Result.Fail("Curso não encontrado.");

        return Result.Ok(new DetalhesCursosDto(
            Curso.Id,
            Curso.Nome,
            Curso.Nivel,
            Curso.CargaHoraria,
            Curso.Modulo.Id,
            Curso.Modulo?.Nome,
            Curso.Categoria.Id,
            Curso.Categoria.Nome
        ));
    }

    public List<OpcaoModuloDto> SelecionarModulo()
    {
        return repositorioModulo
            .SelecionarTodos()
            .Select(m => new OpcaoModuloDto(m.Id, m.Nome))
            .ToList();
    }

    public List<OpcaoCategoriaDto> SelecionarCategoria()
    {
        return repositorioCategoria
            .SelecionarTodos()
            .Select(m => new OpcaoCategoriaDto(m.Id, m.Nome))
            .ToList();
    }
}