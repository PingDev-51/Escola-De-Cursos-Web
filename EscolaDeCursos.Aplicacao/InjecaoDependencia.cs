using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCursos;
using EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutores;
using EscolaDeCursos.Aplicacao.Modulos.ModulosCurso;
using EscolaDeCursos.Aplicacao.Turmas.TurmaTurma;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCursos;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutores;
using EscolaDeCursos.Dominio.Modulos.ModuloModulosCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using EscolaDeCursos.Infra.Modulos.ModuloCategoria;
using EscolaDeCursos.Infra.Modulos.ModuloCurso;
using EscolaDeCursos.Infra.Modulos.ModuloInstrutores;
using EscolaDeCursos.Infra.Modulos.ModulosCurso;
using EscolaDeCursos.Infra.Modulos.ModuloTurma;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EscolaDeCursos.Aplicacao;

public static class InjecaoDependencia
{
    public static void AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddScoped<ServicoCurso>();
        services.AddScoped<ServicoModulo>();
        services.AddScoped<ServicoInstrutores>();
        services.AddScoped<ServicoTurma>();
        services.AddScoped<ServicoCategoria>();

        services.AddScoped<IRepositorioCurso, RepositorioCursoEmOrm>();
        services.AddScoped<IRepositorioModulo, RepositorioModuloEmOrm>();
        services.AddScoped<IRepositorioInstrutores, RepositorioInstrutoresEmOrm>();
        services.AddScoped<IRepositorioTurma, RepositorioTurmaEmOrm>();
        services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmOrm>();
        // ADDScped<ServicoIntrutor>
    }
}
