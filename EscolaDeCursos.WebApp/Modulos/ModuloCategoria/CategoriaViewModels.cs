using System;
using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria;

public record ListarCategoriaViewModel(
    Guid Id,
    string Nome
);

public record CadastrarCategoriaViewModel(
    [Required(ErrorMessage = "O campo Nome é obriagtorio")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo Nome deve conter entre 2 a 100 caracteres")]
    string Nome
);

public record EditarCategoriaViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo Nome é obriagtorio")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo Nome deve conter entre 2 a 100 caracteres")]
    string Nome
);
public record ExcluirCategoriaViewModel(
    Guid Id,
    string Nome
);
