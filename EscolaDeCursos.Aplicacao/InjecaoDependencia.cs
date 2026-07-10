using EscolaDeCursos.Aplicacao.Modulos.ModuloCursos;
using EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutores;
using EscolaDeCursos.Aplicacao.Modulos.ModulosCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloCursos;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutores;
using EscolaDeCursos.Dominio.Modulos.ModuloModulosCurso;
using EscolaDeCursos.Infra.Modulos.ModuloCurso;
using EscolaDeCursos.Infra.Modulos.ModuloInstrutores;
using EscolaDeCursos.Infra.Modulos.ModulosCurso;
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

        services.AddScoped<IRepositorioCurso, RepositorioCursoEmOrm>();
        services.AddScoped<IRepositorioModulo, RepositorioModuloEmOrm>();
        services.AddScoped<IRepositorioInstrutores, RepositorioInstrutoresEmOrm>();
        // ADDScped<ServicoIntrutor>
    }
}
