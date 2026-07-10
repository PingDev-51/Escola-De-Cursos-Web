using System;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutores;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutores;

public class ServicoInstrutores : ServicoBase<Instrutores>
{
    private readonly IRepositorioInstrutores repositorioInstrutores;

    public ServicoInstrutores(IRepositorioInstrutores repositorioInstrutores)
    {
        this.repositorioInstrutores = repositorioInstrutores;
    }

    public Result Cadastrar(CadastrarInstrutoresDto dto)
    {
        // fazer validação de duplicação

        Instrutores novoinstrutor = new Instrutores(
            dto.Nome,
            dto.Telefone,
            dto.Email,
            dto.Graducao
        );

        Result resultadoValidacao = ValidarEntidade(novoinstrutor);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioInstrutores.Cadastrar(novoinstrutor);

        return Result.Ok();
    }

    public Result Editar(EditarInstrutoresDto dto)
    {
        //validar duplicacao

        Instrutores instrutorAtualizado = new Instrutores(
            dto.Nome,
            dto.Telefone,
            dto.Email,
            dto.Graducao
        );

        Result resultadoValidacao = ValidarEntidade(instrutorAtualizado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioInstrutores.Editar(dto.Id, instrutorAtualizado);

        if (!conseguiuEditar)
            return Falha(string.Empty, "Instrutor não encontrado.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Instrutores? instrutores = repositorioInstrutores.SelecionarPorId(id);

        if (instrutores == null)
            return Falha(string.Empty, "Instrutor não encontrado.");

        repositorioInstrutores.Excluir(id);

        return Result.Ok();
    }

    public Result<DetalheInstrutoresDto> SelecionarPorId(Guid id)
    {
        Instrutores? instrutor = repositorioInstrutores.SelecionarPorId(id);

        if (instrutor == null)
            return Result.Fail("Instrutor não encontrado.");

        return Result.Ok(new DetalheInstrutoresDto(
            instrutor.Id,
            instrutor.Nome,
            instrutor.Telefone,
            instrutor.Email,
            instrutor.Graducao
        ));
    }

    public List<ListarInstrutoresDto> SelecionarTodos()
    {
        return repositorioInstrutores.SelecionarTodos().Select(c => new ListarInstrutoresDto(
            c.Id,
            c.Nome,
            c.Telefone,
            c.Email,
            c.Graducao
        )).ToList();
    }
}

