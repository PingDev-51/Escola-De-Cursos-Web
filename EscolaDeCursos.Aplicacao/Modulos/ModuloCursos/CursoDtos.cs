using EscolaDeCursos.Dominio.Modulos.ModuloCursos;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCursos;

public record ListarCursosDto(
    Guid Id,
    string Nome,
    Nivel Nivel,
    int CargaHoraria,
    Guid ModuloId,
    string ModuloNome,
    Guid CategoriaId,
    string CategoriaNome
);

public record CadastrarCursosDto(
    string Nome,
    Nivel Nivel,
    int CargaHoraria,
    Guid ModuloId,
    Guid CategoriaId
);

public record EditarCursosDto(
    Guid Id,
    string Nome,
    Nivel Nivel,
    int CargaHoraria,
    Guid ModuloId,
    Guid CategoriaId
);

public record DetalhesCursosDto(
    Guid Id,
    string Nome,
    Nivel Nivel,
    int CargaHoraria,
    Guid ModuloId,
    string ModuloNome,
    Guid CategoriaId,
    string CategoriaNome
);

public record OpcaoModuloDto(Guid Id, string Nome);

public record OpcaoCategoriaDto(Guid Id, string Nome);