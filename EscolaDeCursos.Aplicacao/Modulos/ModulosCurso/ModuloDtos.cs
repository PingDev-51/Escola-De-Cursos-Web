
namespace EscolaDeCursos.Aplicacao.Modulos.ModulosCurso;

public record ListarModulosDto(
    Guid Id,
    string Nome,
    int Duracao
);

public record CadastrarModulosDto(
    string Nome,
    int Duracao
);

public record EditarModulosDto(
    Guid Id,
    string Nome,
    int Duracao
);

public record DetalhesModulosDto(
    Guid Id,
    string Nome,
    int Duracao
);

