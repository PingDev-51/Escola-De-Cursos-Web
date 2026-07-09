using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModulosCurso;

public record ListarModuloViewModel(
    Guid Id,
    string Nome,
    string Duracao

);

public record CadastrarModuloViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Duracao\" deve ser preenchido.")]
    string Duracao

);

public record EditarModuloViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Duracao\" deve ser preenchido.")]
    string Duracao

);

public record ExcluirModuloViewModel(
    Guid Id,
    string Nome,
    string Duracao
);