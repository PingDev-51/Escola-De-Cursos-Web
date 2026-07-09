using System;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutores;

public record ListarInstrutoresDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Graducao
);

public record CadastrarInstrutoresDto(
    string Nome,
    string Telefone,
    string Email,
    string Graducao
);

public record EditarInstrutoresDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Graducao
);

public record DetalheInstrutoresDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Graducao
);

public record ExcluirInstrutoresDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email,
    string Graducao
);
