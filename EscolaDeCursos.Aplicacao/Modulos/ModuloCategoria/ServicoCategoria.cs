using System;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;

public class ServicoCategoria : ServicoBase<Categoria>
{
    private readonly IRepositorioCategoria repositorioCategoria;

    public ServicoCategoria(IRepositorioCategoria repositorioCategoria)
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    public Result Cadastrar(CadastrarCategoriaDto dto)
    {
        //validação duplicado

        Categoria novaCategoria = new Categoria(
            dto.Nome
        );

        Result resultadoValidacao = ValidarEntidade(novaCategoria);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioCategoria.Cadastrar(novaCategoria);

        return Result.Ok();
    }

    public Result Editar(EditarCategoriaDto dto)
    {
        Categoria categoriaAtualizado = new Categoria(
           dto.Nome
       );

        Result resultadoValidacao = ValidarEntidade(categoriaAtualizado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioCategoria.Editar(dto.Id, categoriaAtualizado);

        if (!conseguiuEditar)
            return Falha(string.Empty, "Categoria não encontrada.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Categoria? categoria = repositorioCategoria.SelecionarPorId(id);

        if (categoria == null)
            return Falha(string.Empty, "Categoria não encontrada.");

        repositorioCategoria.Excluir(id);

        return Result.Ok();
    }

    public Result<DetalheCategoriaDto> SelecionarPorId(Guid id)
    {
        Categoria? categoria = repositorioCategoria.SelecionarPorId(id);

        if (categoria == null)
            return Result.Fail("Categoria não encontrada.");

        return Result.Ok(new DetalheCategoriaDto(
            categoria.Id,
            categoria.Nome
        ));
    }

    public List<ListarCategoriaDto> SelecionarTodos()
    {
        return repositorioCategoria.SelecionarTodos().Select(c => new ListarCategoriaDto(
            c.Id,
            c.Nome
        )).ToList();
    }
}
