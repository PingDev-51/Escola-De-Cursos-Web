using EscolaDeCursos.Dominio.Modulos.ModuloCursos;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCursos;

public record ListarCursosDto(
    Guid Id,
    string Nome,
    Nivel Nivel,
    int CargaHoraria,
    Guid ModuloId,
    string ModuloNome
);

public record CadastrarCursosDto(
    string Nome,
    Nivel Nivel,
    int CargaHoraria,
    Guid ModuloId,
    string ModuloNome
);

public record EditarCursosDto(
    Guid Id,
    string Nome,
    Nivel Nivel,
    int CargaHoraria,
    Guid ModuloId,
    string ModuloNome
);

public record DetalhesCursosDto(
    Guid Id,
    string Nome,
    Nivel Nivel,
    int CargaHoraria,
    Guid ModuloI,
    string ModuloNome
);

public record OpcaoModuloDto(Guid Id, string Nome);

