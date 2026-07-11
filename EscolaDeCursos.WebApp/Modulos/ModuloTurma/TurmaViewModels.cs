using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public record OpcaoInstrutorViewModel(
    Guid Id,
    string Nome
);

public record OpcaoCursoViewModel(
    Guid Id,
    string Nome
);

public record ListaTurmaViewModel(
    Guid Id,
    string Nome,
    Guid InstrutorId,
    string InstrutorNome,
    Guid CursoId,
    string CursoNome,
    string NumeroMaxDeAlunos,
    DateTime DataInicio,
    DateTime DataTermino
);

public record CadastrarTurmaViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"NumeroMaxDeAlunos\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo \"NumeroMaxDeAlunos\" deve conter entre 1 e 100 caracteres.")]
    string NumeroMaxDeAlunos,

    [Required(ErrorMessage = "O campo \"Instrutor\" deve ser preenchido.")]
    Guid InstrutorId,

    [ValidateNever]
    string InstrutorNome,

    [ValidateNever]
    List<OpcaoInstrutorViewModel> Instrutor,

    [Required(ErrorMessage = "O campo \"Curso\" deve ser preenchido.")]
    Guid CursoId,

    [ValidateNever]
    string CursoNome,

    [ValidateNever]
    List<OpcaoCursoViewModel> Curso,

    [Required(ErrorMessage = "O campo \"DataInicio\" deve ser preenchido.")]
    DateTime DataInicio,

    [Required(ErrorMessage = "O campo \"DataTermino\" deve ser preenchido.")]
    DateTime DataTermino
);

public record EditarTurmaViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"NumeroMaxDeAlunos\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo \"NumeroMaxDeAlunos\" deve conter entre 1 e 100 caracteres.")]
    string NumeroMaxDeAlunos,

    [Required(ErrorMessage = "O campo \"Instrutor\" deve ser preenchido.")]
    Guid InstrutorId,

    [ValidateNever]
    string InstrutorNome,

    [ValidateNever]
    List<OpcaoInstrutorViewModel> Instrutor,

    [Required(ErrorMessage = "O campo \"Curso\" deve ser preenchido.")]
    Guid CursoId,

    [ValidateNever]
    string CursoNome,

    [ValidateNever]
    List<OpcaoCursoViewModel> Curso,

    [Required(ErrorMessage = "O campo \"DataInicio\" deve ser preenchido.")]
    DateTime DataInicio,

    [Required(ErrorMessage = "O campo \"DataTermino\" deve ser preenchido.")]
    DateTime DataTermino
);

public record ExcluirTurmaViewModel(
    Guid Id,
    string Nome,
    Guid InstrutorId,
    string InstrutorNome,
    Guid CursoId,
    string CursoNome,
    string NumeroMaxDeAlunos,
    DateTime DataInicio,
    DateTime DataTermino
);