using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;
using EscolaDeCursos.Aplicacao.Turmas.TurmaTurma;
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
}
