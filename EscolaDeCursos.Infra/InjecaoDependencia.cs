using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCursos;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutores;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloModulosCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using EscolaDeCursos.Infra.Comartilhado.Logging;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using EscolaDeCursos.Infra.Modulos.ModuloAluno;
using EscolaDeCursos.Infra.Modulos.ModuloCategoria;
using EscolaDeCursos.Infra.Modulos.ModuloCurso;
using EscolaDeCursos.Infra.Modulos.ModuloInstrutores;
using EscolaDeCursos.Infra.Modulos.ModuloMatricula;
using EscolaDeCursos.Infra.Modulos.ModulosCurso;
using EscolaDeCursos.Infra.Modulos.ModuloTurma;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;

namespace EscolaDeCursos.Infra;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(
        this IServiceCollection services,
        IConfiguration configuration,
        ILoggingBuilder logging
    )
    {
        // Injeta logs do Serilog
        Log.Logger = SerilogFactory.Create(configuration);

        logging.ClearProviders();

        services.AddSerilog(Log.Logger);

        // Injeta o DbContext do EF
        services.AddDbContext<EscolaDeCursosDbContext>(options =>
        {
            string? connectionString = configuration.GetConnectionString("SqlServerEF");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    $"A connection string \"SqlServerEF\" não foi encontrada."
                );
            }

            options.UseSqlServer(connectionString, opt =>
            {
                opt.EnableRetryOnFailure(3);
            });
        });

        services.AddIdentityCore<IdentityUser<Guid>>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireDigit = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;
        })
        .AddRoles<IdentityRole<Guid>>()
        .AddEntityFrameworkStores<EscolaDeCursosDbContext>()
        .AddSignInManager()
        .AddDefaultTokenProviders();

        services.AddScoped<IRepositorioCurso, RepositorioCursoEmOrm>();
        services.AddScoped<IRepositorioModulo, RepositorioModuloEmOrm>();
        services.AddScoped<IRepositorioInstrutores, RepositorioInstrutoresEmOrm>();
        services.AddScoped<IRepositorioAluno, RepositorioAlunoEmOrm>();
        services.AddScoped<IRepositorioTurma, RepositorioTurmaEmOrm>();
        services.AddScoped<IRepositorioMatricula, RepositorioMatriculaEmOrm>();
        services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmOrm>();
    }
}
