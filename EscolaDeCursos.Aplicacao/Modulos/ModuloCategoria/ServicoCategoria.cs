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

    public Result Editar()
    {
        throw new NotImplementedException();
    }

    public Result Excluir()
    {
        throw new NotImplementedException();
    }

    public Result SelecionarPorId()
    {
        throw new NotImplementedException();
    }

    public List<ListarCategoriaDto> SelecionarTodos()
    {
        return repositorioCategoria.SelecionarTodos().Select(c => new ListarCategoriaDto(
            c.Id,
            c.Nome
        )).ToList();
    }
}
