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

    public Result Editar(Guid id)
    {
        throw new NotImplementedException();
    }

    public Result Excluir(Guid id)
    {
        throw new NotImplementedException();
    }

    public Result SelecionarPorId(Guid id)
    {
        throw new NotImplementedException();
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
