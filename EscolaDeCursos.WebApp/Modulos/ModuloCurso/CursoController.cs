using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCursos;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public class CursoController(ServicoCurso servicoCurso, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarCursosDto> dtos = servicoCurso.SelecionarTodos();
        List<ListarCursosViewModel> listarVms = mapeador.Map<List<ListarCursosViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarCursoViewModel cadastrarVm = new CadastrarCursoViewModel(
            string.Empty,
            Dominio.Modulos.ModuloCursos.Nivel.Facil,
            0,
            Guid.Empty,
            SelecionarModulo()
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarCursoViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm with { Modulos = SelecionarModulo() });

        CadastrarCursosDto dto = mapeador.Map<CadastrarCursosDto>(cadastrarVm);
        Result resultado = servicoCurso.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm with { Modulos = SelecionarModulo() });
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesCursosDto> resultado = servicoCurso.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        EditarCursoViewModel editarVm = new(
            resultado.Value.Id,
            resultado.Value.Nome,
            resultado.Value.Nivel,
            resultado.Value.CargaHoraria,
            resultado.Value.ModuloId,
            SelecionarModulo()
        );

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarCursoViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm with { Modulos = SelecionarModulo() });

        EditarCursosDto dto = mapeador.Map<EditarCursosDto>(editarVm);
        Result resultado = servicoCurso.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(editarVm with { Modulos = SelecionarModulo() });
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesCursosDto> resultado = servicoCurso.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        ExcluirCursoViewModel excluirVm = mapeador.Map<ExcluirCursoViewModel>(resultado.Value);

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirCursoViewModel excluirVm)
    {
        Result resultado = servicoCurso.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }

    private List<OpcaoModuloViewModel> SelecionarModulo()
    {
        List<OpcaoModuloDto> dtos = servicoCurso.SelecionarModulo();

        return mapeador.Map<List<OpcaoModuloViewModel>>(dtos);
    }
}