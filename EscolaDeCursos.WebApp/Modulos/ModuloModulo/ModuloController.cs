using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModulosCurso;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModulosCurso;

public class ModuloController(ServicoModulo servicoModulo, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarModulosDto> dtos = servicoModulo.SelecionarTodos();

        List<ListarModuloViewModel> listarVms = mapeador.Map<List<ListarModuloViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarModuloViewModel cadastrarVm = new CadastrarModuloViewModel(
            string.Empty,
            string.Empty
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarModuloViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarModulosDto dto = mapeador.Map<CadastrarModulosDto>(cadastrarVm);

        Result resultado = servicoModulo.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesModulosDto> resultado = servicoModulo.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        EditarModuloViewModel editarVm = mapeador.Map<EditarModuloViewModel>(resultado.Value);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarModuloViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        EditarModulosDto dto = mapeador.Map<EditarModulosDto>(editarVm);

        Result resultado = servicoModulo.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(editarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesModulosDto> resultado = servicoModulo.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        ExcluirModuloViewModel excluirVm = mapeador.Map<ExcluirModuloViewModel>(resultado.Value);

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirModuloViewModel excluirVm)
    {
        Result resultado = servicoModulo.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }
}