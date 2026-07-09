using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloModulosCurso;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModulosCurso;

public class ServicoModulo : ServicoBase<Modulo>
{
    private readonly IRepositorioModulo repositorioModulo;

    public ServicoModulo(
        IRepositorioModulo repositorioModulo
    )
    {
        this.repositorioModulo = repositorioModulo;
    }

    public Result Cadastrar(CadastrarModulosDto dto)
    {
        Modulo novoModulo = new Modulo(
            dto.Nome,
            dto.Duracao
        );

        Result resultadoValidacao = ValidarEntidade(novoModulo);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioModulo.Cadastrar(novoModulo);

        return Result.Ok();
    }

    public Result Editar(EditarModulosDto dto)
    {
        Modulo moduloAtualizado = new Modulo(
             dto.Nome,
             dto.Duracao
        );

        Result resultadoValidacao = ValidarEntidade(moduloAtualizado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioModulo.Editar(dto.Id, moduloAtualizado);

        if (!conseguiuEditar)
            return Falha(string.Empty, "Modulo não encontrado.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Modulo? modulo = repositorioModulo.SelecionarPorId(id);

        if (modulo == null)
            return Falha(string.Empty, "Contato não encontrado.");

        repositorioModulo.Excluir(id);

        return Result.Ok();
    }

    public List<ListarModulosDto> SelecionarTodos()
    {
        return repositorioModulo
            .SelecionarTodos()
            .Select(m => new ListarModulosDto(m.Id, m.Nome, m.Duracao))
            .ToList();
    }

    public Result<DetalhesModulosDto> SelecionarPorId(Guid id)
    {
        Modulo? modulo = repositorioModulo.SelecionarPorId(id);

        if (modulo == null)
            return Result.Fail("Contato não encontrado.");

        return Result.Ok(new DetalhesModulosDto(
            modulo.Id,
            modulo.Nome,
            modulo.Duracao
        ));
    }
}