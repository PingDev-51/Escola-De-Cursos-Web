using System;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;

public record ListarCategoriaDto(
    Guid Id,
    string Nome
);
public record CadastrarCategoriaDto(
    string Nome
);
