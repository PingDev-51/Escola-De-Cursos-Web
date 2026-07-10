using System;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;

public class ServicoAluno : ServicoBase<Aluno>
{
    private readonly IRepositorioAluno repositorioAluno;

    public ServicoAluno(IRepositorioAluno repositorioAluno)
    {
        this.repositorioAluno = repositorioAluno;
    }

    public Result Cadastrar(CadastrarAlunosDto dto)
    {
        Aluno novoAluno = new Aluno(
            dto.Nome,
            dto.Telefone,
            dto.Email
        );

        Result resultadoValidacao = ValidarEntidade(novoAluno);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioAluno.Cadastrar(novoAluno);

        return Result.Ok();
    }

    public Result Editar(EditarAlunosDto dto)
    {
        Aluno alunoAtualizado = new Aluno(
            dto.Nome,
            dto.Telefone,
            dto.Email
        );

        Result resultadoValidacao = ValidarEntidade(alunoAtualizado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioAluno.Editar(dto.Id, alunoAtualizado);

        if (!conseguiuEditar)
            return Falha(string.Empty, "Aluno não encontrado.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Aluno? aluno = repositorioAluno.SelecionarPorId(id);

        if (aluno == null)
            return Falha(string.Empty, "Instrutor não encontrado.");

        repositorioAluno.Excluir(id);

        return Result.Ok();
    }

    public Result<DetalhesAlunosDto> SelecionarPorId(Guid id)
    {
        Aluno? aluno = repositorioAluno.SelecionarPorId(id);

        if (aluno == null)
            return Result.Fail("Instrutor não encontrado.");

        return Result.Ok(new DetalhesAlunosDto(
            aluno.Id,
            aluno.Nome,
            aluno.Telefone,
            aluno.Email
        ));
    }

    public List<ListarAlunosDto> SelecionarTodos()
    {
        return repositorioAluno.SelecionarTodos().Select(a => new ListarAlunosDto(
            a.Id,
            a.Nome,
            a.Telefone,
            a.Email
        )).ToList();
    }
}
