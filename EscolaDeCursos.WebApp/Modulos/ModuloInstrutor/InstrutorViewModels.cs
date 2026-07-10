using System;
using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloInstrutores;

public record ListarInstrutorViewModel(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Graduacao
);


public record CadastrarInstrutorViewModel(
    [Required(ErrorMessage = "O campo Nome é obrigatorio")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo Nome deve conter entre 2 a 100 caracteres.")]
    string Nome,


    string Telefone,
    string Email,
    string Graduacao
);

public record EditarInstrutorViewModel(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Graduacao
);

public record ExcluirInstrutorViewModel(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Graduacao
);
