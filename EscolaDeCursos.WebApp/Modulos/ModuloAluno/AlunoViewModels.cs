using System;
using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAluno;

public record ListarAlunosViewModel(
    Guid Id,
    string Nome,
    string Telefone,
    string Email
);

public record CadastrarAlunosViewModel(
    [Required(ErrorMessage = "O campo Nome é obrigatorio")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo Nome deve conter entre 2 a 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo Telefone é obrigatorio")]
    [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "O campo \"Telefone\" deve estar no formato (DDD) 90000-0000.")]
    string Telefone,

    [Required(ErrorMessage = "O campo Email é obrigatorio")]
    [EmailAddress(ErrorMessage = "O campo Email deve ser valdio")]
    string Email
);


