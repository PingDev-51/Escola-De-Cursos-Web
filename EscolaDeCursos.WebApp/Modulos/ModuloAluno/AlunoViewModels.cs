using System;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAluno;

public record ListarAlunosViewModel(
    Guid Id,
    string Nome,
    string Telefone,
    string Email
);


