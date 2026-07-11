using System;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;

public record OpcaoAlunoDto(
    Guid Id,
    string Nome
);

public record ListarMatriculaDto(
    Guid Id,
    Guid AlunosId,
    string AlunoNome,
    string TurmaId,
    Guid MatriculaId
);

public class CadastrarMatriculaDto
{
    public Guid AlunosId { get; set; }

    public Guid TurmaId { get; set; }

    public Guid MatriculaId { get; set; }
}

public record DetalhesMatriculaDto(
    Guid Id,
    Guid AlunosId,
    string AlunoNome,
    string TurmaId,
    Guid MatriculaId
);

public record ExcluirMatriculaDto(
    Guid Id,
    Guid AlunosId,
    string AlunoNome,
    string TurmaId,
    Guid MatriculaId
);