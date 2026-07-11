using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutores;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;
using EscolaDeCursos.Aplicacao.Turmas.TurmaTurma;
using EscolaDeCursos.Dominio.Modulos.ModuloCursos;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public class TurmaController(ServicoTurma servicoTurma, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarTurmaDto> dtos = servicoTurma.SelecionarTodos();

        List<ListaTurmaViewModel> listarVms = mapeador.Map<List<ListaTurmaViewModel>>(dtos);

        return View(listarVms);
    }


    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarTurmaViewModel cadastrarVm = new CadastrarTurmaViewModel(
         string.Empty,
         string.Empty,
         Guid.Empty,
         string.Empty,
         SelecionarInstrutor(),
         Guid.Empty,
         string.Empty,
         SelecionarCurso(),
         DateTime.Now,
         DateTime.Now
     );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarTurmaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm with { Instrutor = SelecionarInstrutor(), Curso = SelecionarCurso() });

        CadastrarTurmaDto dto = mapeador.Map<CadastrarTurmaDto>(cadastrarVm);
        Result resultado = servicoTurma.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm with { Instrutor = SelecionarInstrutor(), Curso = SelecionarCurso() });
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        Result<DetalhesTurmaDto> resultado = servicoTurma.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        EditarTurmaViewModel editarVm = new(
                resultado.Value.Id,
                resultado.Value.Nome,
                resultado.Value.NumeroMaxDeAlunos,
                resultado.Value.InstrutorId,
                resultado.Value.InstrutorNome,
                SelecionarInstrutor(),
                resultado.Value.CursoId,
                resultado.Value.CursoNome,
                SelecionarCurso(),
                resultado.Value.DataInicio,
                resultado.Value.DataTermino
             );

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarTurmaViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm with { Instrutor = SelecionarInstrutor(), Curso = SelecionarCurso() });

        EditarTurmaDto dto = mapeador.Map<EditarTurmaDto>(editarVm);
        Result resultado = servicoTurma.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(editarVm with { Instrutor = SelecionarInstrutor(), Curso = SelecionarCurso() });
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        Result<DetalhesTurmaDto> resultado = servicoTurma.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        ExcluirTurmaViewModel excluirVm = mapeador.Map<ExcluirTurmaViewModel>(resultado.Value);

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirTurmaViewModel excluirVm)
    {
        Result resultado = servicoTurma.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }

    public List<OpcaoInstrutorViewModel> SelecionarInstrutor()
    {
        List<OpcaoInstrutorDto> dtos = servicoTurma.SelecionarInstrutor();

        return mapeador.Map<List<OpcaoInstrutorViewModel>>(dtos);
    }

    public List<OpcaoCursoViewModel> SelecionarCurso()
    {
        List<OpcaoCursoDto> dtos = servicoTurma.SelecionarCurso();

        return mapeador.Map<List<OpcaoCursoViewModel>>(dtos);
    }

}
