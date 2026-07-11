using System;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;

public record OpcaoAlunoDto(Guid Id, string Nome);

public record ListarMatriculaDto(
    Guid Id,
    Guid AlunosId,
    string AlunoNome,
    Guid MatriculaId
);
public record CadastrarMatriculaDto(
    Guid AlunosId,
    string AlunoNome,
    Guid MatriculaId
);

public record DetalhesMatriculaDto(
    Guid Id,
    Guid AlunosId,
    string AlunoNome,
    Guid MatriculaId
);

public record ExcluirMatriculaDto(
    Guid Id,
    Guid AlunosId,
    string AlunoNome,
    Guid MatriculaId
);
