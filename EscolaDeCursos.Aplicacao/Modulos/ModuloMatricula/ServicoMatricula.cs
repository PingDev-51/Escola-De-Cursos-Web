using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;

public class ServicoMatricula : ServicoBase<Matricula>
{
    private readonly IRepositorioMatricula repositorioMatricula;
    private readonly IRepositorioAluno repositorioAluno;
    private readonly IRepositorioTurma repositorioTurma;

    public ServicoMatricula(
        IRepositorioMatricula repositorioMatricula,
        IRepositorioAluno repositorioAluno,
        IRepositorioTurma repositorioTurma)
    {
        this.repositorioMatricula = repositorioMatricula;
        this.repositorioAluno = repositorioAluno;
        this.repositorioTurma = repositorioTurma;
    }

    public Result Cadastrar(CadastrarMatriculaDto dto)
    {
        Aluno? alunoSelecionado = repositorioAluno.SelecionarPorId(dto.AlunosId);

        if (alunoSelecionado == null)
            return Falha(nameof(dto.AlunosId), "Selecione um aluno válido.");

        Turma? turmaSelecionada = repositorioTurma.SelecionarPorId(dto.TurmaId);

        if (turmaSelecionada == null)
            return Falha(nameof(dto.TurmaId), "Selecione uma turma válida.");

       Matricula novaMatricula = new Matricula(
        alunoSelecionado, 
        turmaSelecionada);

        Result resultadoValidacao = ValidarEntidade(novaMatricula);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioMatricula.Cadastrar(novaMatricula);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Matricula? matricula = repositorioMatricula.SelecionarPorId(id);

        if (matricula == null)
            return Falha(string.Empty, "Matrícula não encontrada.");

        repositorioMatricula.Excluir(id);

        return Result.Ok();
    }

    public List<ListarMatriculaDto> SelecionarTodos()
    {
        return repositorioMatricula
            .SelecionarTodos()
            .Select(m => new ListarMatriculaDto(
                m.Id,
                m.Aluno!.Id,
                m.Aluno.Nome,
                m.Turma!.Nome,
                m.MatriculaId
            ))
            .ToList();
    }

    public Result<DetalhesMatriculaDto> SelecionarPorId(Guid id)
    {
        Matricula? matricula = repositorioMatricula.SelecionarPorId(id);

        if (matricula == null)
            return Result.Fail("Matrícula não encontrada.");

        return Result.Ok(new DetalhesMatriculaDto(
            matricula.Id,
            matricula.Aluno!.Id,
            matricula.Aluno.Nome,
            matricula.Turma!.Nome,
            matricula.MatriculaId
        ));
    }

    public List<OpcaoAlunoDto> SelecionarAluno()
    {
        return repositorioAluno
            .SelecionarTodos()
            .Select(a => new OpcaoAlunoDto(a.Id, a.Nome))
            .ToList();
    }
}