using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloMatricula;

public class MatriculaController(
    ServicoMatricula servicoMatricula,
    IMapper mapeador
) : Controller
{
    [HttpGet]
    public ActionResult Listar(Guid id)
    {

    List<ListarMatriculaDto> dtos = servicoMatricula.SelecionarTodos(id);

        List<ListarMatriculaViewModel> listarVms =
            mapeador.Map<List<ListarMatriculaViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar(Guid id)
    {
        CadastrarMatriculaViewModel cadastrarVm = new(
            Guid.Empty,
            id,
            SelecionarAluno()
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarMatriculaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
        {
            cadastrarVm = cadastrarVm with
            {
                Alunos = SelecionarAluno()
            };

            return View(cadastrarVm);
        }

        CadastrarMatriculaDto dto =
        mapeador.Map<CadastrarMatriculaDto>(cadastrarVm);

        Result resultado = servicoMatricula.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            cadastrarVm = cadastrarVm with
            {
                Alunos = SelecionarAluno()
            };

            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar), new { id = cadastrarVm.TurmaId });
    }


    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesMatriculaDto> resultado =
            servicoMatricula.SelecionarPorId(id);


        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        ExcluirMatriculaViewModel excluirVm =
            mapeador.Map<ExcluirMatriculaViewModel>(resultado.Value);


        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirMatriculaViewModel excluirVm)
    {
        Result resultado =
            servicoMatricula.Excluir(excluirVm.Id);


        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);


        return RedirectToAction(nameof(Listar));
    }


    private List<OpcaoAlunoViewModel> SelecionarAluno()
    {
        List<OpcaoAlunoDto> dtos =
            servicoMatricula.SelecionarAluno();


        return mapeador.Map<List<OpcaoAlunoViewModel>>(dtos);
    }
}