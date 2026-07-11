using System;
using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria;

public class CategoriaController(ServicoCategoria servicoCategoria, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarCategoriaDto> dto = servicoCategoria.SelecionarTodos();

        List<ListarCategoriaViewModel> listarVm = mapeador.Map<List<ListarCategoriaViewModel>>(dto);

        return View(listarVm);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarCategoriaViewModel cadastrarVm = new CadastrarCategoriaViewModel(string.Empty);

        return View(cadastrarVm);
    }

    [HttpGet]
    public ActionResult Cadastrar(CadastrarCategoriaViewModel)
    {

    }
}
