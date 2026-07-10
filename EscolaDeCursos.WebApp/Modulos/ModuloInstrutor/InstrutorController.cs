using System;
using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutores;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloInstrutores;

public class InstrutorController(ServicoInstrutores servicoInstrutores, IMapper mapeador) : Controller
{

    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarInstrutoresDto> dtos = servicoInstrutores.SelecionarTodos();

        List<ListarInstrutorViewModel> listarVms = mapeador.Map<List<ListarInstrutorViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarInstrutorViewModel cadastrarVm = new CadastrarInstrutorViewModel(
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarInstrutorViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarInstrutoresDto dto = mapeador.Map<CadastrarInstrutoresDto>(cadastrarVm);

        Result resultado = servicoInstrutores.Cadastrar(dto);

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
        Result<DetalheInstrutoresDto> resultado = servicoInstrutores.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        EditarInstrutorViewModel editarVm = mapeador.Map<EditarInstrutorViewModel>(resultado.Value);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarInstrutorViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        EditarInstrutoresDto dto = mapeador.Map<EditarInstrutoresDto>(editarVm);

        Result resultado = servicoInstrutores.Editar(dto);

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
        Result<DetalheInstrutoresDto> resultado = servicoInstrutores.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        ExcluirInstrutorViewModel excluirVm = mapeador.Map<ExcluirInstrutorViewModel>(resultado.Value);

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirInstrutorViewModel excluirVm)
    {
        Result resultado = servicoInstrutores.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }
}
