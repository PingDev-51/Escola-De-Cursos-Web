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
