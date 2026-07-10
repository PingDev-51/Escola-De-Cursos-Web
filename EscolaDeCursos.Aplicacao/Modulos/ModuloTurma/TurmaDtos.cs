namespace EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;

public record ListarTurmaDto(
    Guid Id,
    string Nome,
    Guid InstrutorId,
    string InstrutorNome,
    Guid CursoId,
    string CursoNome,
    string NumeroMaxDeAlunos,
    DateTime DataInicio,
    DateTime DataTermino
);

public record CadastrarTurmaDto(
    string Nome,
    Guid InstrutorId,
    string InstrutorNome,
    Guid CursoId,
    string CursoNome,
    string NumeroMaxDeAlunos,
    DateTime DataInicio,
    DateTime DataTermino
);

public record EditarTurmaDto(
    Guid Id,
    string Nome,
    Guid InstrutorId,
    string InstrutorNome,
    Guid CursoId,
    string CursoNome,
    string NumeroMaxDeAlunos,
    DateTime DataInicio,
    DateTime DataTermino
);

public record DetalhesTurmaDto(
    Guid Id,
    string Nome,
    Guid InstrutorId,
    string InstrutorNome,
    Guid CursoId,
    string CursoNome,
    string NumeroMaxDeAlunos,
    DateTime DataInicio,
    DateTime DataTermino
);

