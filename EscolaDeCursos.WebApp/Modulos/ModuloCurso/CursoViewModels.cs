using System.ComponentModel.DataAnnotations;
using EscolaDeCursos.Dominio.Modulos.ModuloCursos;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public record OpcaoModuloViewModel(
    Guid Id,
    string Nome
);

public record OpcaoCategoriaViewModel(
    Guid Id,
    string Nome
);

public record ListarCursosViewModel(
    Guid Id,
    string Nome,
    Nivel Nivel,
    int CargaHoraria,
    Guid ModuloId,
    string ModuloNome,
    Guid CategoriaId,
    string CategoriaNome
);

public record CadastrarCursoViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Nivel\" deve ser preenchido.")]
    Nivel Nivel,

    [Required(ErrorMessage = "O campo \"Carga Horaria\" deve ser preenchido.")]
    [Range(1, 1000, ErrorMessage = "A carga horária deve estar entre 1 e 1000.")]
    int CargaHoraria,

    [Required(ErrorMessage = "O campo \"Modulo\" deve ser preenchido.")]
    Guid ModuloId,

    [ValidateNever]
    List<OpcaoModuloViewModel> Modulos,

    [Required(ErrorMessage = "O campo \"Modulo\" deve ser preenchido.")]
    Guid CategoriaId,

    [ValidateNever]
    List<OpcaoCategoriaViewModel> Categorias

);

public record EditarCursoViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Nivel\" deve ser preenchido.")]
    Nivel Nivel,

    [Required(ErrorMessage = "O campo \"Carga Horaria\" deve ser preenchido.")]
    [Range(1, 1000, ErrorMessage = "A carga horária deve estar entre 1 e 1000 horas.")]
    int CargaHoraria,

    [Required(ErrorMessage = "O campo \"Modulo\" deve ser preenchido.")]
    Guid ModuloId,

    [ValidateNever]
    List<OpcaoModuloViewModel> Modulos,

    [Required(ErrorMessage = "O campo \"Modulo\" deve ser preenchido.")]
    Guid CategoriaId,

    [ValidateNever]
    List<OpcaoCategoriaViewModel> Categorias
);

public record ExcluirCursoViewModel(
    Guid Id,
    string Nome,
    Nivel Nivel,
    int CargaHoraria,
    Guid ModuloId,
    string ModuloNome, 
    Guid CategoriaId,
    string CategoriaNome
);