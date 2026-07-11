using System;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria;

public record ListarCategoriaViewModel(
    Guid Id,
    string Nome
);

public record CadastrarCategoriaViewModel(
    string Nome
);

public record EditarCategoriaViewModel(
    Guid Id,
    string Nome
);
