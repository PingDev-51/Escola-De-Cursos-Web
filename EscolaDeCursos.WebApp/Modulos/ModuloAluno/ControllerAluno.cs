using System;
using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAluno;

public class ControllerAluno(ServicoAluno servicoAluno, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarAlunosDto> dtos = servicoAluno.SelecionarTodos();

        List<ListarAlunosViewModel> listarVm = mapeador.Map<List<ListarAlunosViewModel>>(dtos);

        return View(listarVm);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        Aluno cadastrarVm = new Aluno(
            string.Empty,
            string.Empty,
            string.Empty
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarAlunosViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarAlunosDto dto = mapeador.Map<CadastrarAlunosDto>(cadastrarVm);

        Result resultado = servicoAluno.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

}
