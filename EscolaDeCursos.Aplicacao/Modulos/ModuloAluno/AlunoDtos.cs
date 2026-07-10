using System;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;

public record ListarAlunosDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email
);
public record CadastrarAlunosDto(
    string Nome,
    string Telefone,
    string Email
);

public record EditarAlunosDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email
);

public record DetalhesAlunosDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email
);

public record ExcluirAlunosDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email
);
