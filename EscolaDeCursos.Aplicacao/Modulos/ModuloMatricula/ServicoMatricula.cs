using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using FluentResults;


namespace EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;

public class ServicoMatricula : ServicoBase<Matricula>
{
    private readonly IRepositorioMatricula repositorioMatricula;
    private readonly IRepositorioAluno repositorioAluno;

    public ServicoMatricula(
        IRepositorioMatricula repositorioMatricula,
        IRepositorioAluno repositorioAluno)
    {
        this.repositorioMatricula = repositorioMatricula;
        this.repositorioAluno = repositorioAluno;
    }

    public Result Cadastrar(CadastrarMatriculaDto dto)
    {
        Aluno? alunoSelecionado = repositorioAluno.SelecionarPorId(dto.AlunosId);

        if (alunoSelecionado == null)
            return Falha(nameof(dto.AlunosId), "Selecione um aluno valido.");

        Matricula novaMatricula = new Matricula(
            alunoSelecionado,
           dto.MatriculaId
        );

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
            return Falha(string.Empty, "matricula não encontrado.");

        repositorioMatricula.Excluir(id);

        return Result.Ok();
    }

    public List<ListarMatriculaDto> SelecionarTodos()
    {
        return repositorioMatricula
            .SelecionarTodos()
            .Select(c => new ListarMatriculaDto(
                c.Id,
                c.Aluno.Id,
                c.Aluno.Nome,
                c.MatriculaId
            ))
            .ToList();
    }

    public Result<DetalhesMatriculaDto> SelecionarPorId(Guid id)
    {
        Matricula? matricula = repositorioMatricula.SelecionarPorId(id);

        if (matricula == null)
            return Result.Fail("Matricula não encontrado.");

        return Result.Ok(new DetalhesMatriculaDto(
            matricula.Id,
            matricula.Aluno.Id,
            matricula.Aluno.Nome,
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