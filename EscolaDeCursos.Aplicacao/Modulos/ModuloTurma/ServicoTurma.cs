using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;
using EscolaDeCursos.Dominio.Modulos.ModuloCursos;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutores;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using FluentResults;


namespace EscolaDeCursos.Aplicacao.Turmas.TurmaTurma;

public class ServicoTurma : ServicoBase<Turma>
{
    private readonly IRepositorioTurma repositorioTurma;
    private readonly IRepositorioInstrutores repositorioInstrutores;
    private readonly IRepositorioCurso repositorioCurso;

    public ServicoTurma(
        IRepositorioTurma repositorioTurma,
        IRepositorioInstrutores repositorioInstrutores,
        IRepositorioCurso repositorioCurso

    )
    {
        this.repositorioTurma = repositorioTurma;
        this.repositorioInstrutores = repositorioInstrutores;
        this.repositorioCurso = repositorioCurso;
    }

    public Result Cadastrar(CadastrarTurmaDto dto)
    {
        Curso? cursoSelecionado = repositorioCurso.SelecionarPorId(dto.CursoId);
        Instrutor? instrutorSelecionado = repositorioInstrutores.SelecionarPorId(dto.InstrutorId);

        Turma novoTurma = new Turma(
            dto.Nome,
            cursoSelecionado,
            instrutorSelecionado,
            dto.NumeroMaxDeAlunos,
            dto.DataInicio,
            dto.DataTermino
        );


        Result resultadoValidacao = ValidarEntidade(novoTurma);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioTurma.Cadastrar(novoTurma);

        return Result.Ok();
    }

    public Result Editar(EditarTurmaDto dto)
    {

        Curso? cursoSelecionado = repositorioCurso.SelecionarPorId(dto.CursoId);
        Instrutor? instrutorSelecionado = repositorioInstrutores.SelecionarPorId(dto.InstrutorId);

        Turma TurmaAtualizado = new Turma(
             dto.Nome,
            cursoSelecionado,
            instrutorSelecionado,
            dto.NumeroMaxDeAlunos,
            dto.DataInicio,
            dto.DataTermino
        );

        Result resultadoValidacao = ValidarEntidade(TurmaAtualizado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioTurma.Editar(dto.Id, TurmaAtualizado);

        if (!conseguiuEditar)
            return Falha(string.Empty, "Turma não encontrado.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Turma? Turma = repositorioTurma.SelecionarPorId(id);

        if (Turma == null)
            return Falha(string.Empty, "Contato não encontrado.");

        repositorioTurma.Excluir(id);

        return Result.Ok();
    }

    public List<ListarTurmaDto> SelecionarTodos()
    {
        return repositorioTurma
            .SelecionarTodos()
             .Select(t => new ListarTurmaDto(
                t.Id,
                t.Nome,
                t.Instrutor.Id,
                t.Instrutor.Nome,
                t.Curso.Id,
                t.Curso.Nome,
                t.NumeroMaxDeAlunos,
                t.DataInicio,
                t.DataTermino
            ))
            .ToList();
    }

    public Result<DetalhesTurmaDto> SelecionarPorId(Guid id)
    {
        Turma? Turma = repositorioTurma.SelecionarPorId(id);

        if (Turma == null)
            return Result.Fail("Turma não encontrada.");

        return Result.Ok(new DetalhesTurmaDto(
                Turma.Id,
                Turma.Nome,
                Turma.Instrutor.Id,
                Turma.Instrutor.Nome,
                Turma.Curso.Id,
                Turma.Curso.Nome,
                Turma.NumeroMaxDeAlunos,
                Turma.DataInicio,
                Turma.DataTermino
        ));
    }

    public List<OpcaoInstrutorDto> SelecionarInstrutor()
    {
        return repositorioInstrutores
            .SelecionarTodos()
            .Select(i => new OpcaoInstrutorDto(i.Id, i.Nome))
            .ToList();
    }

    public List<OpcaoCursoDto> SelecionarCurso()
    {
        return repositorioCurso
            .SelecionarTodos()
            .Select(c => new OpcaoCursoDto(c.Id, c.Nome))
            .ToList();
    }
}