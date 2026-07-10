using System;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutores;

public record ListarInstrutoresDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Graduacao
);

public record CadastrarInstrutoresDto(
    string Nome,
    string Telefone,
    string Email,
    string Graduacao
);

public record EditarInstrutoresDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Graduacao
);

public record DetalheInstrutoresDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Graduacao
);

public record ExcluirInstrutoresDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Graduacao
);
