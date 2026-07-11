using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EscolaDeCursos.WebApp.Modulos.ModuloMatricula;

public record OpcaoAlunoViewModel(
    Guid Id,
    string Nome
);

public record ListarMatriculaViewModel(
    Guid Id,
    Guid AlunosId,
    string AlunoNome,
    string TurmaId,
    Guid MatriculaId
);

public record CadastrarMatriculaViewModel(
    [Required(ErrorMessage = "O campo \"Aluno\" deve ser preenchido.")]
    Guid AlunosId,

    [Required(ErrorMessage = "O campo \"Turma\" deve ser preenchido.")]
    Guid TurmaId,

    [ValidateNever]
    List<OpcaoAlunoViewModel> Alunos
);

public record DetalhesMatriculaViewModel(
    Guid Id,
    Guid AlunosId,
    string AlunoNome,
    string TurmaId,
    Guid MatriculaId
);

public record ExcluirMatriculaViewModel(
    Guid Id,
    Guid AlunosId,
    string AlunoNome,
    string TurmaId,
    Guid MatriculaId
);