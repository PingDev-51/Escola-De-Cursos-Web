using System;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;

public record ListarAlunosDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Email
);
